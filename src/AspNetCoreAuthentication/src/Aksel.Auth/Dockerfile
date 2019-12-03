FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Aksel.Auth/Aksel.Auth.csproj", "Aksel.Auth/"]
COPY ["Aksel.Service/Aksel.Service.csproj", "Aksel.Service/"]
COPY ["Aksel.ModelValidators/Aksel.ModelValidators.csproj", "Aksel.ModelValidators/"]
COPY ["Aksel.Models/Aksel.Models.csproj", "Aksel.Models/"]
COPY ["Aksel.Repository/Aksel.Repository.csproj", "Aksel.Repository/"]
RUN dotnet restore "Aksel.Auth/Aksel.Auth.csproj"
COPY . .
WORKDIR "/src/Aksel.Auth"
RUN dotnet build "Aksel.Auth.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Aksel.Auth.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Aksel.Auth.dll"]