using Class04.TaxiManager9000.Domain.Entities;

namespace Class04.TaxiManager9000.Services.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        bool Add(T user);
        bool Remove(int id);
        T GetById(int id);
        List<T> GetAll();
    }
}
