using System.Collections.Generic;

namespace HistoricalArchive.Domain.Models;

/// <summary>
/// Сущность исторического архива.
/// </summary>
public class Archive
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    public virtual ArchiveStatistics? Statistics { get; set; }
}