namespace Class08_Workshop.Services
{
    using System.Collections.Generic;
    using Domain;
    using Interfaces;
    using Repository;

    /// <summary>
    /// Implementation of <see cref="IDriverService"/> that uses any type
    /// of instance of <see cref="IGenericRepository{T}"/>. This allows
    /// abstraction over the type of repository we use.
    ///
    /// Note that this implementation has an additional dependency of <see cref="IGenericRepository{T}"/>
    /// <see cref="Car"/> repository. This is intentional and completely legal, and
    /// it comes from the need to manage both drivers and cars for some "driver" business
    /// requirements.
    /// </summary>
    public class DriverService : EntityServiceBase<Driver>, IDriverService
    {
        private IGenericRepository<Car> _carRepository;

        public DriverService(IGenericRepository<Driver> repository, IGenericRepository<Car> carRepository) : base(repository)
        {
            _carRepository = carRepository;
        }

        public List<Driver> GetAllDrivers()
        {
            return Repository.GetAll();
        }

        public List<Driver> GetAvailableDrivers()
        {
            return Repository.Filter(driver => driver.IsAvailable);
        }

        public List<Driver> GetAssignedDrivers()
        {
            return Repository.Filter(driver => driver.IsAssigned);
        }

        public bool AssignDriverToCar(int driverId, int carId, Shift shift)
        {
            Driver driverToBeAssigned = Repository.FindById(driverId);

            if (driverToBeAssigned == null)
            {
                return false;
            }

            Car carToAssignDriverTo = _carRepository.FindById(carId);

            if (carToAssignDriverTo == null)
            {
                return false;
            }

            bool assignResult = driverToBeAssigned.AssignCar(carToAssignDriverTo, shift);

            if (!assignResult)
            {
                return false;
            }

            Repository.Update(driverToBeAssigned);
            _carRepository.Update(carToAssignDriverTo);
            return true;
        }

        public bool UnassignDriver(int driverId)
        {
            Driver driverToBeAssigned = Repository.FindById(driverId);

            if (driverToBeAssigned == null)
            {
                return false;
            }

            driverToBeAssigned.UnassignCar();

            Repository.Update(driverToBeAssigned);

            return true;
        }
    }
}
