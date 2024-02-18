FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out ./

# Expose port 80 for HTTP traffic
EXPOSE 80

ENTRYPOINT ["dotnet", "sewa.dll"]
