namespace Class05_Workshop.Repository
{
    using Domain;

    /// <summary>
    /// Interface for a repository for the <see cref="Driver"/> entity.
    ///
    /// Should have more obvious purpose in case you need a <see cref="Driver"/>-specific
    /// repository method.
    /// </summary>
    public interface IDriverRepository : IGenericRepository<Driver>
    {
    }
}