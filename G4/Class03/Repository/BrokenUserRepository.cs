namespace Repository
{
    /// <summary>
    /// A user repository implementation that does not work, to illustrate
    /// using different implementations for the IUserRepository interface
    /// and how we can model different behaviors for different implementations.
    /// </summary>
    internal class BrokenUserRepository : IUserRepository
    {
        public void Add(User user)
        {
            throw new Exception("This is a broken user repository - cannot add new users!");
        }

        public void Delete(int id)
        {
            throw new Exception("This is a broken user repository - cannot delete user!");
        }

        public List<User> GetAll()
        {
            throw new Exception("This is a broken user repository - cannot get all users!");
        }

        public User GetById(int id)
        {
            throw new Exception("This is a broken user repository - cannot get user by ID!");
        }

        public void Update(User user)
        {
            throw new Exception("This is a broken user repository - cannot update user!");
        }
    }
}
