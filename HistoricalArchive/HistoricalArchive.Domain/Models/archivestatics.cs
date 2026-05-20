namespace HistoricalArchive.Domain.Models;

/// <summary>
/// Статистика архива (документы, последнее обновление).
/// </summary>
public class ArchiveStatistics
{
    public int Id { get; set; }
    public int ArchiveId { get; set; }
    public int DocumentsCount { get; set; }
    public DateTime LastUpdated { get; set; }
    public virtual Archive Archive { get; set; } = null!;
}