FROM armutcom/dotnet-core-runtime:2.1-xenial AS base
WORKDIR /app

FROM armutcom/dotnet-core-sdk:2.1-xenial AS build
WORKDIR /src
COPY Armut.Api/Armut.Api.csproj Armut.Api/
RUN dotnet restore Armut.Api/Armut.Api.csproj
COPY . .
WORKDIR /src/Armut.Api
RUN dotnet build Armut.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Armut.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Armut.Api.dll"]