FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ClienteProject.Api/ClienteProject.Api.csproj", "ClienteProject.Api/"]
COPY ["ClienteProject.Domain/ClienteProject.Domain.csproj", "ClienteProject.Domain/"]
COPY ["ClienteProject.Application/ClienteProject.Application.csproj", "ClienteProject.Application/"]
COPY ["ClienteProject.Infra/ClienteProject.Infra.csproj", "ClienteProject.Infra/"]

RUN dotnet restore "ClienteProject.Api/ClienteProject.Api.csproj"

COPY . .

WORKDIR "/src/ClienteProject.Api"
RUN dotnet build "ClienteProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClienteProject.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClienteProject.Api.dll"]
