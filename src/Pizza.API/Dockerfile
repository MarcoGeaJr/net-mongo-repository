FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Pizza.API/Pizza.API.csproj", "src/Pizza.API/"]
COPY ["src/Pizza.Domain/Pizza.Domain.csproj", "src/Pizza.Domain/"]
COPY ["src/Pizza.Infra.Mongo/Pizza.Infra.Mongo.csproj", "src/Pizza.Infra.Mongo/"]
RUN dotnet restore "./src/Pizza.API/./Pizza.API.csproj"
COPY . .
WORKDIR "/src/src/Pizza.API"
RUN dotnet build "./Pizza.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Pizza.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pizza.API.dll"]