FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY temis.sln ./
COPY temis.core/temis.core.csproj ./temis.core/
COPY temis.data/temis.data.csproj ./temis.data/
COPY temis.api/temis.api.csproj ./temis.api/

RUN dotnet restore
COPY . .
WORKDIR /src/temis.data
RUN dotnet build -c Release -o /app

RUN dotnet restore
COPY . .
WORKDIR /src/temis.core
RUN dotnet build -c Release -o /app

WORKDIR /src/temis.api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TemisAPIProject.dll"]