namespace Class14_Workshop.Repository
{
    /// <summary>
    /// An abstraction over provider of entity Ids.
    /// </summary>
    public interface IEntityIdProvider
    {
        /// <summary>
        /// Gets the next Id to be assigned to a new entity.
        /// </summary>
        /// <returns>The Id of the new entity.</returns>
        int GetNextId();
    }
}