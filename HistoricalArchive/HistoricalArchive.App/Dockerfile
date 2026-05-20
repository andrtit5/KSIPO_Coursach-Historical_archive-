# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем .csproj файлы и восстанавливаем пакеты (кэширование слоёв)
COPY ["HistoricalArchive.App/HistoricalArchive.App.csproj", "HistoricalArchive.App/"]
COPY ["HistoricalArchive.Domain/HistoricalArchive.Domain.csproj", "HistoricalArchive.Domain/"]
COPY ["HistoricalArchive.Infrastructure/HistoricalArchive.Infrastructure.csproj", "HistoricalArchive.Infrastructure/"]
RUN dotnet restore "HistoricalArchive.App/HistoricalArchive.App.csproj"

# Копируем исходный код и публикуем
COPY . .
WORKDIR "/src/HistoricalArchive.App"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Переменные окружения и порт
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "HistoricalArchive.App.dll"]