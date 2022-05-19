using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public interface IFileDatabase<T> where T : BaseEntity
    {
        T GetById(int id);

        Task InsertAsync(T item);

        Task RemoveAsync(T item);

        Task UpdateAsync(T item);

        List<T> GetAll();
    }
}
