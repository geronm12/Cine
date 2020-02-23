#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CineApi/CineApi.csproj", "CineApi/"]
COPY ["Cine.Implementacion/Cine.Implementacion.csproj", "Cine.Implementacion/"]
COPY ["HelpersServicios/HelpersServicios.csproj", "HelpersServicios/"]
COPY ["Cine.Infraestructura/Cine.Infraestructura.csproj", "Cine.Infraestructura/"]
COPY ["Cine.Interfaces/Cine.Interfaces.csproj", "Cine.Interfaces/"]
COPY ["Cine.Dominio/Cine.Dominio.csproj", "Cine.Dominio/"]
COPY ["Cine.Constantes/Cine.Constantes.csproj", "Cine.Constantes/"]
COPY ["ConexionSql/Cine.ConexionSql.csproj", "ConexionSql/"]
COPY ["Mapper/Mapper.csproj", "Mapper/"]
COPY ["IoC/IoC.csproj", "IoC/"]
RUN dotnet restore "CineApi/CineApi.csproj"
COPY . .
WORKDIR /src/CineApi
RUN dotnet build "CineApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CineApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CineApi.dll"]