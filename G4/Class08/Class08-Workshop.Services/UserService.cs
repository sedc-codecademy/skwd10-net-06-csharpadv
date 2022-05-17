namespace Class08_Workshop.Services
{
    using System.Collections.Generic;
    using Domain;
    using Interfaces;
    using Repository;

    /// <summary>
    /// Implementation of <see cref="IUserService"/> that uses any type
    /// of instance of <see cref="IGenericRepository{T}"/>. This allows
    /// abstraction over the type of repository we use.
    /// </summary>
    public class UserService : EntityServiceBase<User>, IUserService
    {
        public UserService(IGenericRepository<User> repository) : base(repository)
        {
        }

        public User CurrentUser { get; private set; }

        public List<User> GetUsers()
        {
            return Repository.GetAll();
        }

        public bool LogIn(string userName, string password)
        {
            User loggedInUser = Repository.Find(user => user.UserName == userName.Trim() && user.Password == password.Trim());

            if (loggedInUser == null) return false;
            
            CurrentUser = loggedInUser;
            return true;
        }

        public bool Register(string userName, string password, string passwordConfirmation, Role role)
        {
            if (!IsUserNameValid(userName) || !IsPasswordValid(password) ||
                !IsPasswordConfirmationValid(password, passwordConfirmation))
            {
                return false;
            }

            User newUser = new User(userName.Trim(), password.Trim(), role);

            Repository.Insert(newUser);

            return true;
        }

        public bool ChangePassword(string oldPassword, string newPassword, string passwordConfirmation)
        {
            if (!IsPasswordValid(newPassword) || !IsPasswordConfirmationValid(newPassword, passwordConfirmation) ||
                !IsNewPasswordValid(oldPassword, newPassword))
            {
                return false;
            }

            if (CurrentUser.Password != oldPassword.Trim()) return false;

            CurrentUser.ChangePassword(oldPassword.Trim(), newPassword.Trim(), passwordConfirmation.Trim());
            return true;
        }

        public bool TerminateUser(int userId)
        {
            if (CurrentUser.Id == userId)
            {
                return false;
            }

            bool userToBeTerminatedExists = Repository.Exists(user => user.Id == userId);

            if (userToBeTerminatedExists)
            {
                Repository.Delete(userId);
                return true;
            }

            return false;
        }

        public void LogOut()
        {
            CurrentUser = null;
        }

        /// <summary>
        /// Helper method for validating a user name. Can be moved to a helper
        /// class in case this validation is needed elsewhere.
        /// </summary>
        /// <param name="userName">The user name to be validated.</param>
        /// <returns><c>true</c> if user name is valid; otherwise <c>false</c>.</returns>
        private bool IsUserNameValid(string userName)
        {
            return Validate.StringLength(userName, 5);
        }

        /// <summary>
        /// Helper method for validating a password. Can be moved to a helper
        /// class in case this validation is needed elsewhere.
        /// </summary>
        /// <param name="password">The password to be validated.</param>
        /// <returns><c>true</c> if password is valid; otherwise <c>false</c>.</returns>
        private bool IsPasswordValid(string password)
        {
            return Validate.StringLength(password, 5) &&
                   Validate.StringHasNumericCharacters(password);
        }

        /// <summary>
        /// Helper method for validating a password confirmation. Can be moved to a helper
        /// class in case this validation is needed elsewhere.
        /// </summary>
        /// <param name="password">The password to validate the confirmation against.</param>
        /// <param name="passwordConfirmation">The password confirmation.</param>
        /// <returns><c>true</c> if password confirmation is valid; otherwise <c>false</c>.</returns>
        private bool IsPasswordConfirmationValid(string password, string passwordConfirmation)
        {
            return password.Trim() == passwordConfirmation.Trim();
        }

        /// <summary>
        /// Helper method for validating the new password when changing an existing one.
        /// Can be moved to a helper class in case this validation is needed elsewhere.
        /// </summary>
        /// <param name="oldPassword">The old password to validate new password against.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns><c>true</c> if new password is valid; otherwise <c>false</c>.</returns>
        private bool IsNewPasswordValid(string oldPassword, string newPassword)
        {
            return oldPassword.Trim() != newPassword.Trim();
        }
    }
}
