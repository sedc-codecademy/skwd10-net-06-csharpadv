namespace Class05_Workshop.Repository
{
    using System.Collections.Generic;
    using Domain;

    /// <summary>
    /// Interface for implementations of a generic repository.
    /// </summary>
    /// <typeparam name="T">Type of entity that the repository will work with.</typeparam>
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>List of all entities.</returns>
        public List<T> GetAll();

        /// <summary>
        /// Inserts a single entity in the repository.
        /// </summary>
        /// <param name="entity">Entity to be inserted.</param>
        public void Insert(T entity);

        /// <summary>
        /// Insert multiple entities in the repository.
        /// </summary>
        /// <param name="entities">List of entities to be inserted.</param>
        public void InsertMany(List<T> entities);

        /// <summary>
        /// Prints all entities in the repository.
        /// </summary>
        public void PrintAll();
    }
}