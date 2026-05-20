using HistoricalArchive.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HistoricalArchive.Infrastructure.Data;

/// <summary>
/// Контекст базы данных для системы "Исторический архив".
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Инициализирует новый экземпляр контекста с указанными параметрами.
    /// </summary>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Archive> Archives => Set<Archive>();
    public DbSet<Document> Documents => Set<Document>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<ArchiveStatistics> ArchiveStatistics => Set<ArchiveStatistics>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // 1:1 Архив <-> Статистика
        builder.Entity<Archive>()
            .HasOne(a => a.Statistics)
            .WithOne(s => s.Archive)
            .HasForeignKey<ArchiveStatistics>(s => s.ArchiveId);

        // 1:N Архив -> Документы
        builder.Entity<Document>()
            .HasOne(d => d.Archive)
            .WithMany(a => a.Documents)
            .HasForeignKey(d => d.ArchiveId)
            .OnDelete(DeleteBehavior.Cascade);

        // N:N Документы <-> Категории
        builder.Entity<Document>()
            .HasMany(d => d.Categories)
            .WithMany(c => c.Documents)
            .UsingEntity(j => j.ToTable("DocumentCategories"));
    }
}