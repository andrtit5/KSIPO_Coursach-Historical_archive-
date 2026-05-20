using HistoricalArchive.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HistoricalArchive.Infrastructure.Factories;

/// <summary>
/// Фабрика для создания AppDbContext на этапе проектирования (миграции).
/// </summary>
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    /// <summary>
    /// Создаёт экземпляр AppDbContext с хардкод-строкой подключения (только для миграций!).
    /// </summary>
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        // Строка подключения ТОЛЬКО для дизайна/миграций. В рантайме используется из Program.cs
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=historical_archive;Username=postgres;Password=postgres");

        return new AppDbContext(optionsBuilder.Options);
    }
}