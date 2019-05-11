FROM armutcom/aspnet-core:2.2.3-bionic AS base
WORKDIR /app

FROM armutcom/aspnet-core:2.2.3-sdk-2.2.105-build-bionic AS build
WORKDIR /src
COPY Aksel.Api/Aksel.Api.csproj Aksel.Api/
COPY Aksel.Service/Aksel.Service.csproj Aksel.Service/
COPY Aksel.Repository/Aksel.Repository.csproj Aksel.Repository/
RUN dotnet restore Aksel.Api/Aksel.Api.csproj
COPY . .
WORKDIR /src/Aksel.Api
RUN dotnet build Aksel.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Aksel.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Aksel.Api.dll"]