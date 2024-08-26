FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/BackendTestTask.DatabaseMigrator/BackendTestTask.DatabaseMigrator.csproj", "src/BackendTestTask.DatabaseMigrator/"]
COPY ["src/BackendTestTask.DataAccess/BackendTestTask.DataAccess.csproj", "src/BackendTestTask.DataAccess/"]
RUN dotnet restore "./src/BackendTestTask.DatabaseMigrator/BackendTestTask.DatabaseMigrator.csproj"
COPY . .
WORKDIR "/src/src/BackendTestTask.DatabaseMigrator"
RUN dotnet build "./BackendTestTask.DatabaseMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BackendTestTask.DatabaseMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
