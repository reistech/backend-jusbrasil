FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

COPY *.csproj ./src/
RUN dotnet restore "src/src.csproj"

COPY . ./GitHubWebApp/
WORKDIR /src/GitHubWebApp
RUN dotnet publish -c Release -o publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /src/src/publish ./
ENTRYPOINT ["dotnet", "src.dll"]