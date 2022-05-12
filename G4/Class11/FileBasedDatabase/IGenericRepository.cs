namespace FileBasedDatabase
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Reduced interface to show how would a file-based repository
    /// would work.
    /// </summary>
    /// <typeparam name="T">The entity type for the repository instance.</typeparam>
    public interface IGenericRepository<T> where T: BaseEntity
    {
        List<T> GetAll();

        void Insert(T entity);
    }
}