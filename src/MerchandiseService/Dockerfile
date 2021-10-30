FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MerchandiseService/MerchandiseService.csproj", "src/MerchandiseService/"]
COPY ["MerchandiseService.Grpc/MerchandiseService.Grpc.csproj", "src/MerchandiseService.Grpc/"]
COPY ["MerchandiseService.HttpClient/MerchandiseService.HttpClient.csproj", "src/MerchandiseService.HttpClient/"]

RUN dotnet restore "src/MerchandiseService/MerchandiseService.csproj"
RUN dotnet restore "src/MerchandiseService.Grpc/MerchandiseService.Grpc.csproj"
RUN dotnet restore "src/MerchandiseService.HttpClient/MerchandiseService.HttpClient.csproj"

COPY ../../ .
WORKDIR /src
RUN dotnet build "MerchandiseService.HttpClient/MerchandiseService.HttpClient.csproj" -c Release -o /app/build
RUN dotnet build "MerchandiseService.Grpc/MerchandiseService.Grpc.csproj" -c Release -o /app/build
RUN dotnet build "MerchandiseService/MerchandiseService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MerchandiseService/MerchandiseService.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80
EXPOSE 443

FROM runtime AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MerchandiseService.dll"]

