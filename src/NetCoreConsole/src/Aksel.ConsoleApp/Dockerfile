FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/Aksel.ConsoleApp/Aksel.ConsoleApp.csproj", "src/Aksel.ConsoleApp/"]
COPY ["src/Aksel.Service/Aksel.Service.csproj", "src/Aksel.Service/"]
COPY ["src/Aksel.ModelValidators/Aksel.ModelValidators.csproj", "src/Aksel.ModelValidators/"]
COPY ["src/Aksel.Models/Aksel.Models.csproj", "src/Aksel.Models/"]
COPY ["src/Aksel.Repository/Aksel.Repository.csproj", "src/Aksel.Repository/"]
RUN dotnet restore "src/Aksel.ConsoleApp/Aksel.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/src/Aksel.ConsoleApp"
RUN dotnet build "Aksel.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aksel.ConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aksel.ConsoleApp.dll"]