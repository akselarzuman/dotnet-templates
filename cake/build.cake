#addin "Cake.Incubator&version=5.0.1"

using System;
using System.Diagnostics;

var target = Argument("target", "Default");
var projects = GetFiles("../src/**/*.csproj");
string version = "1.0.0";


Task("Default")
    .IsDependentOn("Build");

Task("Restore-Projects")
    .Does(() =>
    {
        Information($"Restoring projects");
        foreach(var project in projects)
        {
            DotNetCoreRestore(project.ToString());
        }
    });

Task("Build")
    .IsDependentOn("Restore-Projects")
    .Does(() =>
{
    DotNetCoreBuildSettings settings = new DotNetCoreBuildSettings
    {
        NoRestore = true,
        Configuration = "Release"
    };

    Information($"Building projects");
    foreach(var project in projects)
    {
        DotNetCoreBuild(project.ToString(), settings);
    }
});

Task("Nuget-Pack")
    .Description("Publish to nuget")
    .Does(() =>
    {
        var settings = new NuGetPackSettings
        {
            Version = version,
            OutputDirectory = "./artifacts"
        };

        string nuspecFile = GetFiles("../nuspec/AkselArzuman.Dotnet.Templates.nuspec").FirstOrDefault().FullPath;

        Information(nuspecFile);

        NuGetPack(nuspecFile, settings);
    });


RunTarget(target);