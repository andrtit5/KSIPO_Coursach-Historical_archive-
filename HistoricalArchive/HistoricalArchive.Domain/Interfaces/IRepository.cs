namespace HistoricalArchive.Domain.Interfaces;

/// <summary>
/// Базовый интерфейс репозитория для работы с сущностями.
/// </summary>
public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}