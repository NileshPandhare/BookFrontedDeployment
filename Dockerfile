# Stage 1: Build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything and restore
COPY . .
RUN dotnet restore

# Publish app to /app folder
RUN dotnet publish -c Release -o /app

# Stage 2: Create runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy published app from build stage
COPY --from=build /app .

# Expose port 10000 (you can change if needed)
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# Run your app
ENTRYPOINT ["dotnet", "BookEcommerceNET.dll"]
