#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SpotifyLite.Api/SpotifyLite.Api.csproj", "SpotifyLite.Api/"]
COPY ["SpotifyLite.Application/SpotifyLite.Application.csproj", "SpotifyLite.Application/"]
COPY ["SpotifyLite.Domain/SpotifyLite.Domain.csproj", "SpotifyLite.Domain/"]
COPY ["SpotifyLite.CrossCutting/SpotifyLite.CrossCutting.csproj", "SpotifyLite.CrossCutting/"]
COPY ["SpotifyLite.Infra/SpotifyLite.Infra.csproj", "SpotifyLite.Infra/"]
RUN dotnet restore "SpotifyLite.Api/SpotifyLite.Api.csproj"
COPY . .
WORKDIR "/src/SpotifyLite.Api"
RUN dotnet build "SpotifyLite.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpotifyLite.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpotifyLite.Api.dll"]