
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-env
WORKDIR /src

# Copiar csproj e restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

RUN pwsh -Command Write-Host "jusbrasil: Gerando uma nova imagem Docker com Alpine e testando o PowerShell Core"

# Build da aplicacao
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /src
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "jusbrasil.dll"]