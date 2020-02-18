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

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PracticaAsp.Net.dll"]
