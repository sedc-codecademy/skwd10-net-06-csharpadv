namespace Class05_Workshop.Repository
{
    using System;
    using Domain;

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public bool LogIn(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
