namespace Class14_Workshop.Domain
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="User"/> entity.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Static field to keep track on what was the last assigned
        /// Id for <see cref="User"/>, so we are able to calculate the
        /// next one when creating a new instance (see <see cref="BaseEntity"/>
        /// constructor on how this works).
        /// </summary>
        private static int s_lastEntityId = 0;

        private static Func<int> s_customIdFactory;

        /// <summary>
        /// Allows customizing Id generation for <see cref="User"/> entity.
        ///
        /// It can be set only once, because it employs the "singleton pattern".
        /// Should be set in a static context before the application actually starts running (e.g. static constructor).
        /// </summary>
        public static Func<int> CustomIdFactory
        {
            get => s_customIdFactory;
            set
            {
                if (s_customIdFactory == null)
                {
                    s_customIdFactory = value;
                }
            }
        }

        public string UserName { get; }
        public string Password { get; private set; }
        public Role Role { get; }

        /// <summary>
        /// Private constructor to allow setting of the Id property (used by <see cref="CreateForSeed"/> method.
        /// It is marked with [<see cref="JsonConstructorAttribute"/>] so we force Newtonsoft.Json to use this constructor
        /// when deserializing the entity.
        /// </summary>
        /// <param name="id">Id of the user.</param>
        /// <param name="userName">User name of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <param name="role">Role of the created user.</param>
        [JsonConstructor]
        private User(int id, string userName, string password, Role role) : base(id)
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
        /// Creates a new <see cref="User"/> instance.
        /// Invokes <see cref="BaseEntity"/> default constructor.
        /// </summary>
        /// <param name="userName">User name of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <param name="role">Role of the created user.</param>
        public User(string userName, string password, Role role) : this(0, userName, password, role)
        {

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
            return new User(id, userName, password, role);
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

        protected override int GetNextEntityId()
        {
            if (CustomIdFactory != null)
            {
                return CustomIdFactory();
            }

            return ++s_lastEntityId;
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
