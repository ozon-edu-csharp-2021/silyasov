﻿FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/MerchandiseService/MerchandiseService.csproj", "src/MerchandiseService/"]
RUN dotnet restore "src/MerchandiseService/MerchandiseService.csproj"

COPY . .
WORKDIR "src/MerchandiseService"
RUN dotnet build "MerchandiseService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MerchandiseService.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80
EXPOSE 443

FROM runtime AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MerchandiseService.dll"]

