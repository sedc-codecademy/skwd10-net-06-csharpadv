using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager9000.DataAccess.Interface;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public class DriverDatabase : Database<Driver>, IDriverDatabase
    {
        public DriverDatabase() : base()
        {

        }
    }
}
