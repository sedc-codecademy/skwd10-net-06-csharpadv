using Class13.TaxiManager9000.DataAccess;
using Class13.TaxiManager9000.DataAccess.Interfaces;
using Class13.TaxiManager9000.Domain.Entities;
using Class13.TaxiManager9000.Services.Interfaces;

namespace Class13.TaxiManager9000.Services.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected IDb<T> _db;

        public BaseService()
        {
            _db = new LocalDb<T>();
        }
        public bool Add(T entity)
        {
            try
            {
                _db.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<T> GetAll()
        {
            return _db.GetAll();
        }

        public List<T> GetAll(Func<T, bool> wherePredicate)
        {
            return _db.GetAll().Where(wherePredicate).ToList();
        }

        public T GetById(int id)
        {
            return _db.GetById(id);
        }

        public bool Remove(int id)
        {
            return _db.RemoveById(id);
        }

        public void Seed(List<T> items)
        {
            if (_db.GetAll().Count > 0) return;
            items.ForEach(x => _db.Add(x));
        }
    }
}
