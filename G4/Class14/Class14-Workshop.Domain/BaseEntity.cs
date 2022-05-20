namespace Class14_Workshop.Domain
{
    /// <summary>
    /// Base entity implementation for inheritance of all entities
    /// in the application.
    /// </summary>
    public abstract class BaseEntity
    {
        public int Id { get; }

        protected BaseEntity(int id = 0)
        {
            if (id == 0)
                Id = GetNextEntityId();
            else
                Id = id;
        }

        /// <summary>
        /// Abstract method for getting the next Id to be assigned to a newly
        /// created entity, while exposing the Id property only via getter to prevent
        /// accidental mutation of the Id. Note the invocation in the constructor. Since we
        /// are not working with a real database engine that would do id assignment for us,
        /// one way to do it is to keep a static field for each class that would store the
        /// last assigned entity Id - check the implementation of other entities for more info.
        /// </summary>
        /// <returns>The Id that will be assigned to a newly created entity.</returns>
        protected abstract int GetNextEntityId();
    }
}
