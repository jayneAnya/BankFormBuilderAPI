# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CustomerFields.API/CustomerFields.API.csproj", "CustomerFields.API/"]
RUN dotnet restore "CustomerFields.API/CustomerFields.API.csproj"
COPY . .
WORKDIR "/src/CustomerFields.API"
RUN dotnet build "CustomerFields.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerFields.API.csproj" -c Release -o /app/publish

# Copy the published files from the publish stage to the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerFields.API.dll"]
