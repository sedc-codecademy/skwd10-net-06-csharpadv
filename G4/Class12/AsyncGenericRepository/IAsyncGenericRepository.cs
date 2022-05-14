namespace AsyncGenericRepository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAsyncGenericRepository<T> where T: BaseEntity
    {
        Task<List<T>> GetAllAsync();

        Task InsertAsync(T entity);
    }
}