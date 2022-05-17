namespace Class08_Workshop.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using Interfaces;
    using Repository;

    /// <summary>
    /// Implementation of <see cref="ICarService"/> that uses any type
    /// of instance of <see cref="IGenericRepository{T}"/>. This allows
    /// abstraction over the type of repository we use.
    /// </summary>
    public class CarService : EntityServiceBase<Car>, ICarService
    {
        public CarService(IGenericRepository<Car> repository) : base(repository)
        {
        }

        public List<Car> GetAllVehicles(bool operationalOnly = false)
        {
            if (operationalOnly)
                return Repository.Filter(car => car.IsOperational);

            return Repository.GetAll();
        }

        public List<Car> GetAvailableVehiclesForShift(Shift shift)
        {
            return Repository.Filter(car =>
                car.IsAvailable && car.AssignedDrivers.All(driver => driver.Shift != shift));
        }
    }
}
