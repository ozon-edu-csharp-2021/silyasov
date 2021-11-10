FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MerchandiseService.Api/MerchandiseService.Api.csproj", "src/MerchandiseService.Api/"]
COPY ["MerchandiseService.Grpc/MerchandiseService.Grpc.csproj", "src/MerchandiseService.Grpc/"]
COPY ["MerchandiseService.HttpClient/MerchandiseService.HttpClient.csproj", "src/MerchandiseService.HttpClient/"]
COPY ["MerchandiseService.Infrastructure/MerchandiseService.Infrastructure.csproj", "src/MerchandiseService.Infrastructure/"]

RUN dotnet restore "src/MerchandiseService.Api/MerchandiseService.Api.csproj"
RUN dotnet restore "src/MerchandiseService.Grpc/MerchandiseService.Grpc.csproj"
RUN dotnet restore "src/MerchandiseService.HttpClient/MerchandiseService.HttpClient.csproj"
RUN dotnet restore "src/MerchandiseService.Infrastructure/MerchandiseService.Infrastructure.csproj"

COPY ../../ .
WORKDIR /src
RUN dotnet build "MerchandiseService.Infrastructure/MerchandiseService.Infrastructure.csproj" -c Release -o /app/build
RUN dotnet build "MerchandiseService.HttpClient/MerchandiseService.HttpClient.csproj" -c Release -o /app/build
RUN dotnet build "MerchandiseService.Grpc/MerchandiseService.Grpc.csproj" -c Release -o /app/build
RUN dotnet build "MerchandiseService.Api/MerchandiseService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MerchandiseService.Api/MerchandiseService.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80
EXPOSE 443

FROM runtime AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MerchandiseService.Api.dll"]

