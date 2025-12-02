# -----------------------------
# 1) Build da aplicação
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY *.csproj ./
RUN dotnet restore


COPY . ./

# Publica em Release
RUN dotnet publish -c Release -o /app/publish

# -----------------------------
# 2) Runtime 
# -----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia resultados do publish
COPY --from=build /app/publish .

# Render usa a variável PORT 
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "SpotifyAlbumRequestBackEnd.dll"]
