FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["MigrationInRuntime/MigrationInRuntime.csproj", "MigrationInRuntime/"]
RUN dotnet restore "MigrationInRuntime/MigrationInRuntime.csproj"
COPY . .
WORKDIR "/src/MigrationInRuntime"
RUN dotnet build "MigrationInRuntime.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MigrationInRuntime.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MigrationInRuntime.dll"]