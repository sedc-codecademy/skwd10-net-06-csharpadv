namespace Repository
{
    /// <summary>
    /// Simple modelling of a user
    /// </summary>
    internal class User
    {
        /// <summary>
        /// This was previously in the repository implementation.
        /// To allow auto-incrementing the ID while preventing
        /// mutation, this has been moved to this class, the ID
        /// parameter has been removed from the constructor and
        /// the setter of ID has been removed as well (see Id comment)
        /// </summary>
        private static int LastUserId = 0;
        
        /// <summary>
        /// Id has its setter removed - this prevents changing the
        /// object ID from outside, while allowing setting the value
        /// in the constructor.
        /// </summary>
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(string firstName, string lastName)
        {
            Id = GetNextUserId();
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// A helper method that increments the last user ID
        /// and returns it for constructor assignment.
        /// </summary>
        private static int GetNextUserId()
        {
            return ++LastUserId;
        }
    }
}
