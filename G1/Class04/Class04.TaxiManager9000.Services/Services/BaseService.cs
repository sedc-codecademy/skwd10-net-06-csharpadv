using Class04.TaxiManager9000.DataAccess;
using Class04.TaxiManager9000.DataAccess.Interfaces;
using Class04.TaxiManager9000.Domain.Entities;
using Class04.TaxiManager9000.Services.Interfaces;

namespace Class04.TaxiManager9000.Services.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected IDb<T> Db;

        public BaseService()
        {
            Db = new LocalDb<T>();
        }
        public bool Add(T entity)
        {
            try
            {
                Db.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<T> GetAll()
        {
            return Db.GetAll();
        }

        public T GetById(int id)
        {
            return Db.GetById(id);
        }

        public bool Remove(int id)
        {
            return Db.RemoveById(id);
        }
    }
}
