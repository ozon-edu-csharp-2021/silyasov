﻿FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/MerchApi/MerchApi.csproj", "src/MerchApi/"]
RUN dotnet restore "src/MerchApi/MerchApi.csproj"

COPY . .
WORKDIR "src/MerchApi"
RUN dotnet build "MerchApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MerchApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80
EXPOSE 443

FROM runtime AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MerchApi.dll"]

