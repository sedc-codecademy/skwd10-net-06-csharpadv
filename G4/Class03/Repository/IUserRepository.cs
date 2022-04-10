namespace Repository
{
    /// <summary>
    /// A general-purpose interface for a user repository
    /// </summary>
    internal interface IUserRepository
    {
        /// <summary>
        /// Returns all users from database
        /// </summary>
        List<User> GetAll();

        /// <summary>
        /// Gets the user with the given ID
        /// </summary>
        User GetById(int id);

        /// <summary>
        /// Adds a new user to the database
        /// </summary>
        void Add(User user);
        
        /// <summary>
        /// Updates an existing user in the database
        /// </summary>
        void Update(User user);

        /// <summary>
        /// Deletes the user with the given ID
        /// </summary>
        void Delete(int id);
    }
}
