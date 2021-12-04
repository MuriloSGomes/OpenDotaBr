#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebApp/OpenDota.FrontEnd/OpenDota.FrontEnd.csproj", "WebApp/OpenDota.FrontEnd/"]
RUN dotnet restore "WebApp/OpenDota.FrontEnd/OpenDota.FrontEnd.csproj"
COPY . .
WORKDIR "/src/WebApp/OpenDota.FrontEnd"
RUN dotnet build "OpenDota.FrontEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenDota.FrontEnd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenDota.FrontEnd.dll"]