namespace Class14_Workshop.Domain
{
    using System;

    /// <summary>
    /// <see cref="User"/> entity.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Static field to keep track on what was the last assigned
        /// Id for <see cref="User"/>, so we are able to calculate the
        /// next one when creating a new instance (see <see cref="BaseEntity"/>
        /// constructor in combination with <see cref="BaseEntity.GetNextEntityId"/>
        /// on how this works).
        /// </summary>
        private static int s_lastEntityId = 0;
        
        public string UserName { get; }
        public string Password { get; private set; }
        public Role Role { get; }

        /// <summary>
        /// Creates a new <see cref="User"/> instance.
        /// Invokes <see cref="BaseEntity"/> default constructor.
        /// </summary>
        /// <param name="userName">User name of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <param name="role">Role of the created user.</param>
        public User(string userName, string password, Role role)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("Parameter cannot be empty", nameof(userName));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Parameter cannot be empty", nameof(password));

            UserName = userName;
            Password = password;
            Role = role;
        }

        protected override int GetNextEntityId()
        {
            return ++s_lastEntityId;
        }

        /// <summary>
        /// Changes user existing password. Does basic validation according to common sense/business requirements.
        /// Detailed validation about password requirements is done in the service layer.
        /// </summary>
        /// <param name="oldPassword">Old password for verification.</param>
        /// <param name="newPassword">Password that existing password will be switched to.</param>
        /// <param name="passwordConfirmation">Confirmation of new password.</param>
        /// <returns></returns>
        public bool ChangePassword(string oldPassword, string newPassword, string passwordConfirmation)
        {
            if (Password != oldPassword)
            {
                return false;
            }

            if (oldPassword == newPassword)
            {
                return false;
            }

            if (newPassword != passwordConfirmation)
            {
                return false;
            }

            Password = newPassword;

            return true;
        }
    }

    /// <summary>
    /// Enum that models user roles.
    /// </summary>
    public enum Role
    {
        Administrator,
        Manager,
        Maintenance
    }
}
