FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/Aksel.Api/Aksel.Api.csproj", "src/Aksel.Api/"]
COPY ["src/Aksel.Service/Aksel.Service.csproj", "src/Aksel.Service/"]
COPY ["src/Aksel.ModelValidators/Aksel.ModelValidators.csproj", "src/Aksel.ModelValidators/"]
COPY ["src/Aksel.Models/Aksel.Models.csproj", "src/Aksel.Models/"]
COPY ["src/Aksel.Repository/Aksel.Repository.csproj", "src/Aksel.Repository/"]
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