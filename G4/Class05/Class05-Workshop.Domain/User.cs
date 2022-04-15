namespace Class05_Workshop.Domain
{
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
        public string Password { get; }
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
            UserName = userName;
            Password = password;
            Role = role;
        }

        protected override int GetNextEntityId()
        {
            return ++s_lastEntityId;
        }

        public override void Print()
        {
            throw new System.NotImplementedException();
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
