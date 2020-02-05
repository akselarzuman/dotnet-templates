# AkselArzuman.Dotnet.Templates

dotnet new cli templates to make your life easier.

[![NuGet](https://img.shields.io/nuget/v/AkselArzuman.Dotnet.Templates.svg)](https://www.nuget.org/packages/AkselArzuman.Dotnet.Templates)

## Why to use these templates?

By creating you project with these templates, you get :

* Layers (Service, Repository and Models)
* Swagger (for WebApi project)
* Entity Framework Core Support (only need to pass your connection string in appsettings file)
* Dependency Injection (Microsoft)
* AutoMapper Configuration
* Fluent Validation
* Docker Support
* Test Project

## Continuous integration

| Build server                | Platform      | Build status                                                                                                                                                        | 
|-----------------------------|---------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Azure Pipelines             | Ubuntu        | [![Build status](https://dev.azure.com/arzumanaksel/dotnet-templates/_apis/build/status/dotnet-templates%20-%20Ubuntu)](https://dev.azure.com/arzumanaksel/dotnet-templates/_build/latest?definitionId=5) | |
| Azure Pipelines             | Mac Os        | [![Build status](https://dev.azure.com/arzumanaksel/dotnet-templates/_apis/build/status/dotnet-templates%20-%20Mac%20OS)](https://dev.azure.com/arzumanaksel/dotnet-templates/_build/latest?definitionId=6) | |
| Azure Pipelines             | Windows       | [![Build status](https://dev.azure.com/arzumanaksel/dotnet-templates/_apis/build/status/dotnet-templates%20-%20Windows)](https://dev.azure.com/arzumanaksel/dotnet-templates/_build/latest?definitionId=7) | |

## Installation

Install with :

`dotnet new -i AkselArzuman.Dotnet.Templates`

### dotnet new netcore-api

Creates a web api with Service,Repository and Models layers and Test project. It also includes docker support.

You need to pass project name in order to create the application.

`dotnet new netcore-api --projectname=HelloWorld`

To see what parameters you can pass :

`dotnet new netcore-api --help`

### dotnet new netcore-auth

Creates an authentication api that gives JWT tokens with Service,Repository and Models layers and Test project. It also includes docker support.

You need to pass project name in order to create the application.

`dotnet new netcore-auth --projectname=HelloWorld`

To see what parameters you can pass :

`dotnet new netcore-auth --help`

### dotnet new netcore-console

Creates a console application with Service,Repository and Models layers and Test project. It also includes docker support.

You need to pass project name in order to create the application.

`dotnet new netcore-console --projectname=HelloWorld`

To see what parameters you can pass :

`dotnet new netcore-console --help`
