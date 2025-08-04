# Use .NET 9 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set working directory inside container
WORKDIR /src

# Copy only .csproj files first (for restore step)
COPY src/MicroX.API/MicroX.API.csproj MicroX.API/
COPY src/MicroX.Application/MicroX.Application.csproj MicroX.Application/
COPY src/MicroX.Contracts/MicroX.Contracts.csproj MicroX.Contracts/
COPY src/MicroX.Domain/MicroX.Domain.csproj MicroX.Domain/
COPY src/MicroX.Infrastructure/MicroX.Infrastructure.csproj MicroX.Infrastructure/
COPY src/MicroX.Shared/MicroX.Shared.csproj MicroX.Shared/

# Restore NuGet packages
RUN dotnet restore MicroX.API/MicroX.API.csproj

# Copy full source code from src/ only
COPY src/ .

# Build and publish
RUN dotnet publish MicroX.API/MicroX.API.csproj -c Release -o /app/publish

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Set environment
ENV ASPNETCORE_ENVIRONMENT=Production

# Copy published app from build stage
COPY --from=build /app/publish .

# Run the app
ENTRYPOINT ["dotnet", "MicroX.API.dll"]
