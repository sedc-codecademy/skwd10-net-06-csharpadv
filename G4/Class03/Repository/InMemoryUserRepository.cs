namespace Repository
{
    /// <summary>
    /// A proper in-memory implementation of a user repository.
    /// Very similar to what you would use in the future for
    /// so-called "unit testing" where tests are done for the smallest
    /// units of code (most often methods).
    /// </summary>
    internal class InMemoryUserRepository : IUserRepository
    {
        /// <summary>
        /// Note that this is a static list, so any number of instances
        /// of InMemoryUserRepository class would use the same global
        /// instance (remember - static classes/members are initialized
        /// only ONCE automatically during program startup, and then
        /// they are shared in the context they are declared (in this
        /// case, InMemoryUserRepository.UserTable). Finally, note that
        /// the access modifier is set to private, which means only
        /// the InMemoryUserRepository class will have access to it.
        /// </summary>
        private static List<User> UserTable = new List<User>();

        public List<User> GetAll()
        {
            // return all with no filtering
            return UserTable;
        }

        /// <summary>
        /// Static method that displays user table contents to console output
        /// </summary>
        public static void PrintAll()
        {
            Console.WriteLine("Users Table");
            Console.WriteLine("~~~~~~~~~~~");

            foreach (var item in UserTable)
            {
                Console.WriteLine($"First name: {item.FirstName}; Last name: {item.LastName}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Static method that returns string of concatenated user infos that then can be
        /// printed out from Program.cs by using Console.WriteLine
        /// </summary>
        public static string GetAllUserInfo()
        {
            string returnString = "";

            foreach (var item in UserTable)
            {
                returnString += $"First name: {item.FirstName}; Last name: {item.LastName};\n";
            }

            return returnString;
        }

        public User GetById(int id)
        {
            // LINQ expression to match user by ID
            return UserTable.FirstOrDefault(x => x.Id == id);
        }

        public void Add(User user)
        {   
            // just add it to the list
            UserTable.Add(user);
        }

        public void Update(User user)
        {
            // iterate over each user
            for (int i = 0; i < UserTable.Count; i++)
            {
                // if the ID of the current user from the table
                // matches the ID of the user we want to update...
                if (UserTable[i].Id == user.Id)
                {
                    // ... update FirstName and LastName
                    UserTable[i].FirstName = user.FirstName;
                    UserTable[i].LastName = user.LastName;

                    // update done, exit loop
                    break;
                }
            }
        }

        public void Delete(int id)
        {
            // check if a user with the supplied id exists
            User userToBeDeleted = UserTable.FirstOrDefault(x => x.Id == id);

            // if exists
            if (userToBeDeleted != null)
            {
                // remove it
                UserTable.Remove(userToBeDeleted);
            }

            // depending on the scenario, you might need to
            // signal that the user that was requested to be
            // deleted did not exist and throw an error
            // that would alert the developer using the class
            // and/or the system attempted an invalid operation
            // (e.g. trying to delete a non-existent user).
            // Just some food for thought, don't overthink it
            // for now
        }
    }
}
