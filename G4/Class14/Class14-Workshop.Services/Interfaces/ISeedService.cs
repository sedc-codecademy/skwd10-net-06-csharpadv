namespace Class14_Workshop.Services.Interfaces
{
    using System.Collections.Generic;
    using Domain;

    /// <summary>
    /// Generic abstraction over services for seeding entity data.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public interface ISeedService<T> where T: BaseEntity
    {
        /// <summary>
        /// Seeds (initializes) data for entity.
        /// </summary>
        /// <param name="entities">List of entities to initialize data with.</param>
        void Seed(List<T> entities);
    }
}