using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCo.TaxiManager9000.Domain;

namespace TaxiCo.TaxiManager9000.Services.Services.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetSingle(int id);
        void Add(T item);
        void Remove(int id);
        void Seed(List<T> items);
    }
}
