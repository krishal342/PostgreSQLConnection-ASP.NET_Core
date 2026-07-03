
# Stage 1: Runtime base image (lightweight)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Stage 2: SDK image to compile and build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
# Copy the csproj file and restore dependencies (doing this first caches layers)
COPY ["PostgreSQLConnection.csproj", "."]
RUN dotnet restore "PostgreSQLConnection.csproj"

# Copy the remaining source code and build
COPY . .
RUN dotnet build "PostgreSQLConnection.csproj" -c Release -o /app/build

# Stage 3: Publish the compiled app
FROM build AS publish
RUN dotnet publish "PostgreSQLConnection.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 4: Final container image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PostgreSQLConnection.dll"]