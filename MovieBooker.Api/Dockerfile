# =========================
# BUILD STAGE
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files (for restore)
COPY MovieBooker.Api/MovieBooker.Api.csproj MovieBooker.Api/
COPY MovieBooker.Application/MovieBooker.Application.csproj MovieBooker.Application/
COPY MovieBooker.Domain/MovieBooker.Domain.csproj MovieBooker.Domain/
COPY MovieBooker.Infrastructure/MovieBooker.Infrastructure.csproj MovieBooker.Infrastructure/

# Restore dependencies
RUN dotnet restore MovieBooker.Api/MovieBooker.Api.csproj

# Copy everything else
COPY . .

# Build & publish
RUN dotnet publish MovieBooker.Api/MovieBooker.Api.csproj -c Release -o /app/publish

# =========================
# RUNTIME STAGE
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MovieBooker.Api.dll"]
