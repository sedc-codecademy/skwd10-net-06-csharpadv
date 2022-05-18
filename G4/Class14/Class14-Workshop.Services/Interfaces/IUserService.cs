namespace Class14_Workshop.Services.Interfaces
{
    using System.Collections.Generic;
    using Domain;

    /// <summary>
    /// Abstraction over a service that exposes operations over the
    /// <see cref="User"/> entity.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Keeps track of the currently logged-in user.
        /// </summary>
        User CurrentUser { get; }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>List of users.</returns>
        List<User> GetUsers();

        /// <summary>
        /// Attempts to log in with provided credentials.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <returns><c>true</c> if login was successful; otherwise <c>false</c>.</returns>
        bool LogIn(string userName, string password);
        /// <summary>
        /// Attempts to register user with the provided user info.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <param name="passwordConfirmation">The password confirmation.</param>
        /// <param name="role">The role of the user.</param>
        /// <returns><c>true</c> if registration was successful; otherwise <c>false</c>.</returns>
        bool Register(string userName, string password, string passwordConfirmation, Role role);
        /// <summary>
        /// Attempts to change existing user password.
        /// </summary>
        /// <param name="oldPassword">The old password for verification.</param>
        /// <param name="newPassword">The new password to replace the old one.</param>
        /// <param name="passwordConfirmation">The confirmation of the new password.</param>
        /// <returns><c>true</c> if password change was successful; otherwise <c>false</c>.</returns>
        bool ChangePassword(string oldPassword, string newPassword, string passwordConfirmation);
        /// <summary>
        /// Terminates the user with the given Id.
        /// </summary>
        /// <param name="userId">The user id of the user.</param>
        /// <returns><c>true</c> if user termination was successful; otherwise <c>false</c>.</returns>
        bool TerminateUser(int userId);
        /// <summary>
        /// Logs out currently logged in user.
        /// </summary>
        void LogOut();
    }
}