#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["PocDapperFluentMigration.Api.Service.Endpoint/PocDapperFluentMigration.Api.Service.Endpoint.csproj", "PocDapperFluentMigration.Api.Service.Endpoint/"]
COPY ["PocDapperFluentMigration.Api.Application/PocDapperFluentMigration.Api.Application.csproj", "PocDapperFluentMigration.Api.Application/"]
COPY ["PocDapperFluentMigration.Api.Core/PocDapperFluentMigration.Api.Core.csproj", "PocDapperFluentMigration.Api.Core/"]
COPY ["PocDapperFluentMigration.Shared.Core/PocDapperFluentMigration.Shared.Core.csproj", "PocDapperFluentMigration.Shared.Core/"]
COPY ["PocDapperFluentMigration.Shared.Api.Infrastructure/PocDapperFluentMigration.Shared.Api.Infrastructure.csproj", "PocDapperFluentMigration.Shared.Api.Infrastructure/"]
RUN dotnet restore "PocDapperFluentMigration.Api.Service.Endpoint/PocDapperFluentMigration.Api.Service.Endpoint.csproj"
COPY . .
WORKDIR "/src/PocDapperFluentMigration.Api.Service.Endpoint"
RUN dotnet build "PocDapperFluentMigration.Api.Service.Endpoint.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PocDapperFluentMigration.Api.Service.Endpoint.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PocDapperFluentMigration.Api.Service.Endpoint.dll"]