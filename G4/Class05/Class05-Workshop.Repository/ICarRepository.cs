namespace Class05_Workshop.Repository
{
    using Domain;

    /// <summary>
    /// Interface for a repository for the <see cref="Car"/> entity.
    ///
    /// Usually, the repository only does data operations (read, modify, delete),
    /// not things like <see cref="CheckLicenses"/> and <see cref="ListAllCars"/>,
    /// and methods like these are offloaded to an additional layer of classes.
    /// Don't worry, we'll get there.
    /// </summary>
    public interface ICarRepository : IGenericRepository<Car>
    {
        /// <summary>
        /// Checks and prints license validity statuses.
        /// </summary>
        void CheckLicenses();

        /// <summary>
        /// Prints all cars.
        /// </summary>
        /// <param name="operationalOnly">If <c>true</c>, prints only operational cars; otherwise, prints all cars.</param>
        void ListAllCars(bool operationalOnly);
    }
}