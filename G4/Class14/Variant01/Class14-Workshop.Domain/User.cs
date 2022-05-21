namespace Class14_Workshop.Domain
{
    using System;

    /// <summary>
    /// <see cref="User"/> entity.
    /// </summary>
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        /// <summary>
        /// Needed for deserialization.
        /// </summary>
        public User()
        {
            
        }

        /// <summary>
        /// Creates a new <see cref="User"/> instance.
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

        /// <summary>
        /// Static factory method for usage when seeding entities. This is needed because auto-generating Ids for
        /// existing entities in a persistent database will re-insert the same entities with new auto-generated Ids.
        ///
        /// This allows restoring of Ids of seeded data when trying to reinsert them.
        /// </summary>
        /// <param name="id">Id of the user.</param>
        /// <param name="userName">User name of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <param name="role">Role of the created user.</param>
        /// <returns>A new <see cref="User"/> instance that can be seeded.</returns>
        public static User CreateForSeed(int id, string userName, string password, Role role)
        {
            return new User(userName, password, role) { Id = id };
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
