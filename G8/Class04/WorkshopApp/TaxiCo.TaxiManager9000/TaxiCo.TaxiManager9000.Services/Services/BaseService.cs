using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCo.TaxiManager9000.DataAccess;
using TaxiCo.TaxiManager9000.Domain;
using TaxiCo.TaxiManager9000.Services.Services.Interfaces;

namespace TaxiCo.TaxiManager9000.Services.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected IDb<T> _db;

        public BaseService()
        {
            _db = new LocalDb<T>();
        }

        public void Add(T item)
        {
            _db.Insert(item);
        }

        public List<T> GetAll()
        {
            return _db.GetAll();
        }

        public T GetSingle(int id)
        {
            return _db.GetById(id);
        }

        public void Remove(int id)
        {
            _db.RemoveById(id);
        }

        public void Seed(List<T> items)
        {
            if (_db.GetAll().Count > 0) return;
            items.ForEach(x => _db.Insert(x));

            //foreach (T x in items)
            //{
            //    _db.Insert(x);
            //}
        }
    }
}
