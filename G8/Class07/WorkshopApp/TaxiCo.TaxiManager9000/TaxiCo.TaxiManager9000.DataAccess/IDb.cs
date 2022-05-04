using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCo.TaxiManager9000.Domain;

namespace TaxiCo.TaxiManager9000.DataAccess
{
    public interface IDb<T> where T : BaseEntity
    {
        //C -> Create -> Insert
        //R -> Read -> GetAll / GetById
        //U -> Update -> Update
        //D -> Delete -> RemoveById

        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void RemoveById(int id);
        void Update(T entity);
    }
}
