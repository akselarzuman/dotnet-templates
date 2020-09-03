#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Aksel.Api/Aksel.Api.csproj", "src/Aksel.Api/"]
COPY ["src/Models/Aksel.ModelValidators.Module/Aksel.ModelValidators.Module.csproj", "src/Models/Aksel.ModelValidators.Module/"]
COPY ["src/Models/Aksel.ModelValidators/Aksel.ModelValidators.csproj", "src/Models/Aksel.ModelValidators/"]
COPY ["src/Models/Aksel.Models/Aksel.Models.csproj", "src/Models/Aksel.Models/"]
COPY ["src/Database/Aksel.Repository.Entities/Aksel.Repository.Entities.csproj", "src/Database/Aksel.Repository.Entities/"]
COPY ["src/Database/Aksel.Repository.Module/Aksel.Repository.Module.csproj", "src/Database/Aksel.Repository.Module/"]
COPY ["src/Database/Aksel.Repository/Aksel.Repository.csproj", "src/Database/Aksel.Repository/"]
COPY ["src/Service/Aksel.Service.Modules/Aksel.Service.Module.csproj", "src/Service/Aksel.Service.Modules/"]
COPY ["src/Service/Aksel.Service/Aksel.Service.csproj", "src/Service/Aksel.Service/"]
COPY ["src/Models/Aksel.AutomapperMappings/Aksel.AutomapperMappings.csproj", "src/Models/Aksel.AutomapperMappings/"]
RUN dotnet restore "src/Aksel.Api/Aksel.Api.csproj"
COPY . .
WORKDIR "/src/src/Aksel.Api"
RUN dotnet build "Aksel.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aksel.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aksel.Api.dll"]