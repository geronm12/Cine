<<<<<<< HEAD
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["PracticaAsp.Net/PracticaAsp.Net.sln", "PracticaAsp.Net/"]
RUN dotnet restore "PracticaAsp.Net/PracticaAsp.Net.sln"
COPY . .
WORKDIR "/src/PracticaAsp.Net"
RUN dotnet build "PracticaAsp.Net.sln" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PracticaAsp.Net.sln" -c Release -o /app/publish
=======
#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["ApiAdministrador/ApiAdministrador.csproj", "ApiAdministrador/"]
RUN dotnet restore "ApiAdministrador/ApiAdministrador.csproj"
COPY . .
RUN dotnet build "ApiAdministrador.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiAdministrador.csproj" -c Release -o /app/publish
>>>>>>> master

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PracticaAsp.Net.dll"]
<<<<<<< HEAD
=======
       
>>>>>>> master
