# Imagen base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

# Imagen para build
FROM mcr.microsoft.com/dotnet/sdk:9.0-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Api/TaskManager.Api/TaskManager.Api.csproj", "Api/TaskManager.Api/"]
COPY ["Api/ClassLibrary1/TaskManager.Infrastructure.csproj", "Api/ClassLibrary1/"]
COPY . .
WORKDIR "/src/Api/TaskManager.Api"
RUN dotnet restore "TaskManager.Api.csproj"
RUN dotnet build "TaskManager.Api.csproj" -c %configuration% -o /app/build

# Publicar la app
FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TaskManager.Api.csproj" -c %configuration% -o /app/publish /p:UseAppHost=false

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManager.Api.dll"]