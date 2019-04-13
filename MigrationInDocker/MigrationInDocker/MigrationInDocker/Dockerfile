FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY MigrationInDocker/MigrationInDocker.csproj MigrationInDocker/
RUN dotnet restore MigrationInDocker/MigrationInDocker.csproj
COPY . .
WORKDIR /src/MigrationInDocker
RUN dotnet build MigrationInDocker.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MigrationInDocker.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MigrationInDocker.dll"]
