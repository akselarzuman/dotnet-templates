FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Aksel.ConsoleApp/Aksel.ConsoleApp.csproj", "Aksel.ConsoleApp/"]
COPY ["Aksel.Service/Aksel.Service.csproj", "Aksel.Service/"]
COPY ["Aksel.ModelValidators/Aksel.ModelValidators.csproj", "Aksel.ModelValidators/"]
COPY ["Aksel.Models/Aksel.Models.csproj", "Aksel.Models/"]
COPY ["Aksel.Repository/Aksel.Repository.csproj", "Aksel.Repository/"]
RUN dotnet restore "Aksel.ConsoleApp/Aksel.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/Aksel.ConsoleApp"
RUN dotnet build "Aksel.ConsoleApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Aksel.ConsoleApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Aksel.ConsoleApp.dll"]