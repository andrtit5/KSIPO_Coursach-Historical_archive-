using System.Collections.Generic;

namespace HistoricalArchive.Domain.Models;

/// <summary>
/// Документ, хранящийся в архиве.
/// </summary>
public class Document
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public int ArchiveId { get; set; }
    public virtual Archive Archive { get; set; } = null!;
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}