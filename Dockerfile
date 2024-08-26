FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

WORKDIR /build

COPY . .

RUN dotnet publish LinkCutter -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine

WORKDIR /app

COPY --from=build /build/out .

CMD ["dotnet", "LinkCutter.dll"]