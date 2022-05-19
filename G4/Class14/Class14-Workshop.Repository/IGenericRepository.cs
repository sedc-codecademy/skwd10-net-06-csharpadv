namespace Class14_Workshop.Repository
{
    using System;
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
        /// Returns filtered entities based on specified filter.
        /// </summary>
        /// <param name="filter">The filter criteria.</param>
        /// <returns>List of filtered entities.</returns>
        public List<T> Filter(Func<T, bool> filter);

        /// <summary>
        /// Finds a single entity by its id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>The entity with the specified id if it exists, otherwise <c>null</c>.</returns>
        public T FindById(int id);

        /// <summary>
        /// Find a single entity based on a custom filter.
        /// </summary>
        /// <param name="filter">The filter criteria.</param>
        /// <returns>The filtered entity if it exists, otherwise <c>null</c>.</returns>
        public T Find(Func<T, bool> filter);

        /// <summary>
        /// Checks if an entity that satisfies filter criteria exists.
        /// </summary>
        /// <param name="filter">The filter criteria.</param>
        /// <returns><c>true</c> if such entity exists, otherwise <c>false</c>.</returns>
        public bool Exists(Func<T, bool> filter);

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
        /// Updates a single existing entity, decided by the provided <paramref name="entity"/>'s id.
        /// If the entity does not already exists, does nothing.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        public void Update(T entity);

        /// <summary>
        /// Deletes a single entity by its id. If an entity with the given id does not exist, does nothing.
        /// </summary>
        /// <param name="id">The id of the entity to be deleted.</param>
        public void Delete(int id);
    }
}