#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/ApiOpenDota/OpenDota.Api/OpenDota.Api.csproj", "Services/ApiOpenDota/OpenDota.Api/"]
RUN dotnet restore "Services/ApiOpenDota/OpenDota.Api/OpenDota.Api.csproj"
COPY . .
WORKDIR "/src/Services/ApiOpenDota/OpenDota.Api"
RUN dotnet build "OpenDota.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenDota.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenDota.Api.dll"]
