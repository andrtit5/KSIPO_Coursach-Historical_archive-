# ️ Historical Archive

> Курсовой проект: веб-система управления историческими архивами и документами. Выполнен Титовым Андреем ББСО-03-24 (псевдоним AntonRyakhov)

Описание
Веб-приложение для учёта и управления историческими архивами, документами и категориями. Реализовано по принципам Clean Architecture с разделением на Domain, Infrastructure и App слои. Приложение контейнеризировано и готово к развёртыванию через Docker Compose.

Стек технологий
- **.NET 8** / ASP.NET Core Blazor Server
- **Entity Framework Core** (CodeFirst, PostgreSQL, Fluent API)
- **Repository Pattern** + Dependency Injection (`IServiceCollection`)
- **FluentValidation** / DataAnnotations (валидация входных данных)
- **Docker** + **docker-compose** (multi-stage build, healthcheck, volumes)
- **Git** (система контроля версий)

Структура проекта
HistoricalArchive/
├── HistoricalArchive.Domain/ # Модели сущностей, интерфейсы (IRepository), валидаторы
── HistoricalArchive.Infrastructure/ # EF Core, AppDbContext, реализация Repository, миграции
└── HistoricalArchive.App/ # Blazor UI, DI, Program.cs, настройки приложения

Локально (.NET 8 + PostgreSQL)
1. Убедитесь, что PostgreSQL запущен и создана БД `historical_archive`.
2. Примените миграции:
   ```bash
   dotnet ef database update --project HistoricalArchive.Infrastructure --startup-project HistoricalArchive.App

   Затем
   dotnet run --project HistoricalArchive.App
   
Примечание
Некоторые UI-компоненты упрощены. Архитектурные паттерны (Repository, DI, EF Core, валидация) полностью реализованы в коде и могут быть активированы раскомментированием соответствующих строк в Program.cs.
