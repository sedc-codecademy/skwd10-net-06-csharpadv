namespace Class05_Workshop.Repository
{
    using System;
    using System.Collections.Generic;
    using Domain;

    /// <summary>
    /// Abstract generic repository - this forces specific implementation for each
    /// entity type. There's a better way to do this, but let's see it in future
    /// iterations of this workshop.
    /// </summary>
    /// <typeparam name="T">Type of entities in the repository.</typeparam>
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Container for the entities in the repository.
        /// </summary>
        public List<T> EntityTable { get; }

        protected GenericRepository()
        {
            EntityTable = new List<T>();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void InsertMany(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void PrintAll()
        {
            throw new NotImplementedException();
        }
    }
}
