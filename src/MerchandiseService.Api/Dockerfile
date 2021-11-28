FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src
COPY ["src/MerchandiseService.Api/MerchandiseService.Api.csproj", "src/MerchandiseService.Api/"]
RUN dotnet restore "src/MerchandiseService.Api/MerchandiseService.Api.csproj"

COPY . .
WORKDIR /src/src
RUN dotnet build "MerchandiseService.Api/MerchandiseService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MerchandiseService.Api/MerchandiseService.Api.csproj" -c Release -o /app/publish
COPY "entrypoint.sh" "/app/publish/."

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS runtime

WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80
EXPOSE 443

FROM runtime AS final
WORKDIR /app

COPY --from=publish /app/publish .

RUN chmod +x entrypoint.sh
CMD /bin/bash entrypoint.sh
