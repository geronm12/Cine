FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY *.sln .
COPY ApiAdministrador/*.csproj ./ApiAdministrador/
COPY Cine.Constantes/*.csproj ./Cine.Constantes/
COPY Cine.Dominio/*.csproj ./Cine.Dominio/
COPY Cine.Implementacion/*.csproj ./Cine.Implementacion/
COPY Cine.Infraestructura/*.csproj ./Cine.Infraestructura/
COPY Cine.Interfaces/*.csproj ./Cine.Interfaces/
COPY ConexionSql/*.csproj ./ConexionSql/
COPY HelpersServicios/*.csproj ./HelpersServicios/
COPY IoC/*.csproj  ./IoC/
COPY MetaDatos/*csproj ./MetaDatos
COPY Servicios/*.csproj ./Servicios
COPY Mapper/*.csproj ./Mapper
RUN dotnet restore
 
COPY ApiAdministrador/. ./ApiAdministrador/
COPY Cine.Constantes/. ./Cine.Constantes/
COPY Cine.Dominio/. ./Cine.Dominio/
COPY Cine.Implementacion/. ./Cine.Implementacion/
COPY Cine.Infraestructura/. ./Cine.Infraestructura/
COPY Cine.Interfaces/. ./Cine.Interfaces/
COPY ConexionSql/.  ./ConexionSql/
COPY HelpersServicios/.  ./HelpersServicios/
COPY IoC/. ./IoC/
COPY Mapper/.  ./Mapper
COPY MetaDatos/. ./MetaDatos
COPY Servicios/.  ./Servicios
WORKDIR /app/PracticaAsp.Net
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "PracticaAsp.Net.dll" ]

