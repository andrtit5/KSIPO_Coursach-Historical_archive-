using System.Collections.Generic;

namespace HistoricalArchive.Domain.Models;

/// <summary>
/// Категория документа (тег/классификация).
/// </summary>
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}