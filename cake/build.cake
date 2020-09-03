#addin "Cake.Incubator&version=5.0.1"

using System;
using System.Diagnostics;

var sourceDir = "../src";
var solutions = GetFiles(sourceDir + "/**/*.sln");
var files = GetFiles(sourceDir + "/**/*.*");

var target = Argument("target", "Default");
var publishDir = "../publishdir";
string version = "1.4.0";

Task("Default")
    .IsDependentOn("Copy-Files");

Task("Restore")
    .Does(() =>
    {
        foreach(var sln in solutions)
        {
            DotNetCoreRestore(sln.ToString());
        }
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetCoreBuildSettings settings = new DotNetCoreBuildSettings
    {
        NoRestore = true,
        Configuration = "Release"
    };

    foreach(var sln in solutions)
    {
        DotNetCoreBuild(sln.ToString(), settings);
    }
});

Task("Create-Directory")
    .IsDependentOn("Build")
    .Does(() =>
    {
        CreateDirectory(publishDir);
    });

Task("Copy-Templates")
    .IsDependentOn("Create-Directory")
    .Does(() =>
    {
        CopyFiles(files, publishDir, true);
    });

Task("Copy-Nuspec")
    .IsDependentOn("Create-Directory")
    .Does(() =>
    {
        var nuspecFile = GetFiles("../nuspec/AkselArzuman.Dotnet.Templates.nuspec");
        CopyFiles(nuspecFile, publishDir, true);
    });

Task("Copy-Files")
    .IsDependentOn("Copy-Templates")
    .IsDependentOn("Copy-Nuspec");

Task("Nuget-Pack")
    .Description("Publish to nuget")
    .Does(() =>
    {
        var settings = new NuGetPackSettings
        {
            Version = version,
            OutputDirectory = "../artifacts"
        };

        string nuspecFile = GetFiles(publishDir + "/AkselArzuman.Dotnet.Templates.nuspec").FirstOrDefault().FullPath;

        Information(nuspecFile);

        NuGetPack(nuspecFile, settings);
    });


RunTarget(target);