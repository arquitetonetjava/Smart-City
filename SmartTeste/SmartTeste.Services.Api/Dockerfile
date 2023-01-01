#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SmartTeste.Services.Api/SmartTeste.Services.Api.csproj", "SmartTeste.Services.Api/"]
RUN dotnet restore "SmartTeste.Services.Api/SmartTeste.Services.Api.csproj"
COPY . .
WORKDIR "/src/SmartTeste.Services.Api"
RUN dotnet build "SmartTeste.Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartTeste.Services.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartTeste.Services.Api.dll"]