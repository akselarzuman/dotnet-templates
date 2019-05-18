# AkselArzuman.Dotnet.Templates

dotnet new cli templates to make your life easier.

## Why to use these templates?

By creating you project with these templates, you get :

* Layers (Service, Repository and Models)
* Entity Framework Core Support (only need to pass your connection string in appsettings file)
* Dependency Injection (Microsoft)
* AutoMapper Configuration
* Fluent Validation
* Docker Support
* Test Project

## Installation

Install with :

`dotnet new -i AkselArzuman.Dotnet.Templates`

### dotnet new netcore-api

Creates a web api with Service,Repository and Models layers and Test project. It also includes docker support.

You need to pass project name in order to create the application.

`dotnet new netcore-api --projectname=HelloWorld`

To see what parameters you can pass :

`dotnet new netcore-api --help`

### dotnet new netcore-console

Creates a console application with Service,Repository and Models layers and Test project. It also includes docker support.

You need to pass project name in order to create the application.

`dotnet new netcore-console --projectname=HelloWorld`

To see what parameters you can pass :

`dotnet new netcore-console --help`