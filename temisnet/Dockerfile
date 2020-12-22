FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app 
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS http://+:80
EXPOSE 8080 8081 80 5000-5001

#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY temis.api/*.csproj ./temis.api/
COPY temis.core/*.csproj ./temis.core/
COPY temis.data/*.csproj ./temis.data/
COPY temis.unitTest/*.csproj ./temis.unitTest/ 
#
RUN dotnet restore 
#

# copy everything else and build app
COPY temis.api/. ./temis.api/
COPY temis.core/. ./temis.core/
COPY temis.data/. ./temis.data/
 
#
WORKDIR /app/temis.api
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS runtime
WORKDIR /app 
#
COPY --from=build /app/temis.api/out ./
ENTRYPOINT ["dotnet", "temis.api.dll"]