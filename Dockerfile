#FROM promact/docker-dotnet-nodejs AS build-env
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
# Setup NodeJs
RUN apt-get update -y
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash --debug
RUN apt-get install nodejs -yq
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
EXPOSE 52554
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "DotNetVuetify.dll"]