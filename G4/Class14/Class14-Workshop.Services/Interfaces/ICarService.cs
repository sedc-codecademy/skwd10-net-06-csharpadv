namespace Class14_Workshop.Services.Interfaces
{
    using System.Collections.Generic;
    using Domain;

    /// <summary>
    /// Abstraction over a service that exposes operations over the
    /// <see cref="Car"/> entity.
    /// </summary>
    public interface ICarService
    {
        /// <summary>
        /// Returns all vehicles.
        /// </summary>
        /// <param name="operationalOnly">If <c>true</c>, returns operational vehicles only; otherwise returns all vehicles.</param>
        /// <returns>List of vehicles.</returns>
        List<Car> GetAllVehicles(bool operationalOnly = false);
        /// <summary>
        /// Returns all available vehicles with no drivers assigned for the provided shift.
        /// </summary>
        /// <param name="shift">Shift that the vehicle should be available for.</param>
        /// <returns>List of vehicles available for a shift.</returns>
        List<Car> GetAvailableVehiclesForShift(Shift shift);
    }
}