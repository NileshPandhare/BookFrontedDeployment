# Use SDK image to build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the csproj and restore first (leveraging Docker cache)
COPY BookEcommerceNET/BookEcommerceNET.csproj BookEcommerceNET/
RUN dotnet restore BookEcommerceNET/BookEcommerceNET.csproj

# Copy the rest of the files
COPY . .

# Publish the project
RUN dotnet publish BookEcommerceNET/BookEcommerceNET.csproj -c Release -o /app/publish

# Use runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published output
COPY --from=build /app/publish .

# Set entrypoint
ENTRYPOINT ["dotnet", "BookEcommerceNET.dll"]

