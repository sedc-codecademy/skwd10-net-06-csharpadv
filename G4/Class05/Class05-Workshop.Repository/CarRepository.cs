namespace Class05_Workshop.Repository
{
    using System;
    using Domain;

    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public void CheckLicenses()
        {
            throw new NotImplementedException();
        }

        public void ListAllCars(bool operationalOnly)
        {
            throw new NotImplementedException();
        }
    }
}
