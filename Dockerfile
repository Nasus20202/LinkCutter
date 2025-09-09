FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build

WORKDIR /build

COPY LinkCutter.sln .

COPY LinkCutter/LinkCutter.csproj LinkCutter/

RUN dotnet restore

COPY LinkCutter/ LinkCutter/

RUN dotnet publish LinkCutter -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine

WORKDIR /app

COPY --from=build /build/out .

CMD ["dotnet", "LinkCutter.dll"]