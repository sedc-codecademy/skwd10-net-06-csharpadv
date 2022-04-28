namespace Class05_Workshop.Repository
{
    using Domain;

    /// <summary>
    /// Interface for a repository for the <see cref="User"/> entity.
    ///
    /// Usually, the repository only does data operations (read, modify, delete),
    /// not things like <see cref="LogIn"/>, and methods like these are offloaded
    /// to an additional layer of classes. Don't worry, we'll get there.
    /// </summary>
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Tries to log in with the user with the supplied credentials.
        /// </summary>
        /// <param name="userName">The user name of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>If <c>true</c>, login has been successful; otherwise <c>false</c>.</returns>
        bool LogIn(string userName, string password);
    }
}