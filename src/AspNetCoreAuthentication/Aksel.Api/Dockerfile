FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Aksel.Api/Aksel.Api.csproj", "Aksel.Api/"]
COPY ["Aksel.Service/Aksel.Service.csproj", "Aksel.Service/"]
COPY ["Aksel.Repository/Aksel.Repository.csproj", "Aksel.Repository/"]
COPY ["Aksel.Models/Aksel.Models.csproj", "Aksel.Models/"]
RUN dotnet restore "Aksel.Api/Aksel.Api.csproj"
COPY . .
WORKDIR "/src/Aksel.Api"
RUN dotnet build "Aksel.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Aksel.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Aksel.Api.dll"]