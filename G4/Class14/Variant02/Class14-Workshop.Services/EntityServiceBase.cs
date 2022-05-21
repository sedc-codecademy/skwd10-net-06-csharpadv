namespace Class14_Workshop.Services
{
    using System.Collections.Generic;
    using Domain;
    using Interfaces;
    using Repository;

    /// <summary>
    /// Base abstract implementation for services that will work over a generic
    /// repository of a specific entity type. Exposes a "main" <see cref="Repository"/>
    /// property that defines what is the target type of the service.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public abstract class EntityServiceBase<T> : ISeedService<T> where T : BaseEntity
    {
        /// <summary>
        /// The "main" repository of the service.
        /// </summary>
        protected IGenericRepository<T> Repository { get; }

        protected EntityServiceBase(IGenericRepository<T> repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Seeds initial data for a given entity.
        /// </summary>
        /// <param name="entities">The list of entities to seed.</param>
        public void Seed(List<T> entities)
        {
            foreach (var entity in entities)
            {
                if (Repository.Exists(existingEntity => existingEntity.Id == entity.Id))
                {
                    Repository.Update(entity);
                }
                else
                {
                    Repository.Insert(entity);
                }
            }
        }
    }
}
