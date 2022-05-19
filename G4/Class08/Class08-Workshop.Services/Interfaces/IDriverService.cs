namespace Class08_Workshop.Services.Interfaces
{
    using System.Collections.Generic;
    using Domain;

    /// <summary>
    /// Abstraction over a service that exposes operations over the
    /// <see cref="Driver"/> entity.
    /// </summary>
    public interface IDriverService
    {
        /// <summary>
        /// Gets all drivers.
        /// </summary>
        /// <returns>Driver list.</returns>
        List<Driver> GetAllDrivers();
        /// <summary>
        /// Gets available drivers (non-expired license & no car assigned).
        /// </summary>
        /// <returns>List of available drivers.</returns>
        List<Driver> GetAvailableDrivers();
        /// <summary>
        /// Gets currently-assigned drivers (have a car assigned).
        /// </summary>
        /// <returns>List of assigned drivers.</returns>
        List<Driver> GetAssignedDrivers();

        /// <summary>
        /// Assigns the driver with the provided driver id to the car with the provided car id.
        /// </summary>
        /// <param name="driverId">The driver id.</param>
        /// <param name="carId">The car id.</param>
        /// <param name="shift">The shift to assign the driver to.</param>
        /// <returns><c>true</c> if assignment was successful; otherwise <c>false</c>.</returns>
        bool AssignDriverToCar(int driverId, int carId, Shift shift);
        /// <summary>
        /// Unassigns the driver with the provided driver id from his/hers assigned car, making
        /// the car available.
        /// </summary>
        /// <param name="driverId">The driver id.</param>
        /// <returns><c>true</c> if unassignment was successful; otherwise <c>false</c>.</returns>
        bool UnassignDriver(int driverId);
    }
}