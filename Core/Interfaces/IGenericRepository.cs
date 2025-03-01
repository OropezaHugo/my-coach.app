using Core.Entities;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> ListAllAsync();
    Task<T?> GetEntityWithSpec(ISpecification<T> spec);
    Task<IEnumerable<T>> ListAllAsync(ISpecification<T> spec);
    
    Task<TResult?> GetEntityWithSpec<TResult>(ISpecification<T, TResult> spec);
    Task<IEnumerable<TResult>> ListAllAsync<TResult>(ISpecification<T, TResult> spec);
    T AddAsync(T entity);
    void UpdateAsync(T entity);
    void DeleteAsync(T entity);
    Task<bool> SaveChangesAsync();
    bool Exists(int id);
    
    Task<int> CountAsync(ISpecification<T> spec);
}
