# -----------------------------
# 1) Build da aplicação
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o /app

# -----------------------------
# 2) Runtime
# -----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app .

EXPOSE 8080
EXPOSE 80

ENTRYPOINT ["dotnet", "SpotifyAPI.dll"]
