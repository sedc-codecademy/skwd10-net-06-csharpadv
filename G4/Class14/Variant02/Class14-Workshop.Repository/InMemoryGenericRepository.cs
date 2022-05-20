namespace Class14_Workshop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain;

    /// <summary>
    /// In-memory generic repository, formerly abstract generic repository when each entity
    /// had its own implementation. This no longer forces specific implementation for each
    /// entity type because the type of the repository will be defined when defining the entity-
    /// specific service.
    /// </summary>
    /// <typeparam name="T">Type of entities in the repository.</typeparam>
    public class InMemoryGenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Container for the entities in the repository.
        /// </summary>
        public List<T> EntityTable { get; }

        public InMemoryGenericRepository()
        {
            EntityTable = new List<T>();
        }

        public List<T> GetAll()
        {
            return EntityTable;
        }

        public List<T> Filter(Func<T, bool> filter)
        {
            return EntityTable.Where(filter).ToList();
        }

        public T FindById(int id)
        {
            return EntityTable.SingleOrDefault(entity => entity.Id == id);
        }

        public T Find(Func<T, bool> filter)
        {
            return EntityTable.FirstOrDefault(filter);
        }

        public bool Exists(Func<T, bool> filter)
        {
            return EntityTable.Any(filter);
        }

        public void Insert(T entity)
        {
            EntityTable.Add(entity);
        }

        public void InsertMany(List<T> entities)
        {
            EntityTable.AddRange(entities);
        }

        public void Update(T entity)
        {
            for (int i = 0; i < EntityTable.Count; i++)
            {
                if (entity.Id == EntityTable[i].Id)
                {
                    EntityTable[i] = entity;
                    break;
                }
            }
        }

        public void Delete(int id)
        {
            T entityToBeDeleted = FindById(id);

            if (entityToBeDeleted != null)
            {
                EntityTable.Remove(entityToBeDeleted);
            }
        }
    }
}
