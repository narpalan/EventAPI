namespace EventAPI.Data.Repositories
{
    public interface IRepository<T> where T: class
    {        
        Task<bool> ExistsAsync(int id);
    }

    public interface IReadableRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
    }

    public interface IWritableRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}