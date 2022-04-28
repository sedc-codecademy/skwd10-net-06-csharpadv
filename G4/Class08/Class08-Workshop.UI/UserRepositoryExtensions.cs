using System;

namespace Class05_Workshop.UI
{
    using Domain;
    using Repository;

    /// <summary>
    /// Extensions for <see cref="IUserRepository"/>.
    /// </summary>
    static class UserRepositoryExtensions
    {
        /// <summary>
        /// Prompts user for credentials and attempts to log in.
        /// </summary>
        /// <param name="userRepository">The user repository instance that <see cref="IUserRepository.LogIn"/> will be invoked against.</param>
        /// <returns>The user name of the user when login is successful.</returns>
        internal static string LogIn(this IUserRepository userRepository)
        {
            string userName = null;
            // while userName input is empty
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.Write("Please enter your user name: ");
                userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.WriteLine("User name cannot be empty!");
                }
            }

            string password = null;
            // while password input is empty
            while (string.IsNullOrWhiteSpace(password))
            {
                Console.Write("Please enter your password: ");
                password = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Password cannot be empty!");
                }
            }

            // try to login
            var loginResult = userRepository.LogIn(userName, password);

            // if login failed
            if (!loginResult)
            {
                Console.WriteLine("Invalid login info");

                // return empty user name
                return null;
            }

            // if successful, return logged in user user name
            return userName;
        }

        /// <summary>
        /// Prompts user to create a new user and stores it.
        /// </summary>
        /// <param name="userRepository">The user repository instance that <see cref="IUserRepository.Insert"/> will be invoked against.</param>
        /// <returns>The user name of the newly registered user.</returns>
        internal static string Register(this IUserRepository userRepository)
        {
            string userName = null;
            // while userName input is empty
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.Write("Please enter your desired user name: ");
                userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.WriteLine("User name cannot be empty!");
                }
            }

            string password = null;
            // while password input is empty
            while (string.IsNullOrWhiteSpace(password))
            {
                Console.Write("Please enter your desired password: ");
                password = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Password cannot be empty!");
                }
            }

            string passwordConfirmation = null;
            // while password and passwordConfirmation don't match
            while (passwordConfirmation != password)
            {
                Console.Write("Please confirm your password: ");
                passwordConfirmation = Console.ReadLine();

                if (passwordConfirmation != password)
                {
                    Console.WriteLine("Passwords do not match, try again");
                }
            }

            Role role = Role.Administrator;

            // helper variable to signal that role has been set;
            // a better way to do this would be to declare nullable Role? role = null,
            // and instead of while(!roleSet) we check while(role.HasValue),
            // but I don't think nullable types have been covered so far.
            bool roleSet = false;
            while (!roleSet)
            {
                Console.WriteLine("Please enter your desired role:");
                Console.WriteLine($"1) {Role.Administrator.ToString()}");
                Console.WriteLine($"2) {Role.Manager.ToString()}");
                Console.WriteLine($"3) {Role.Maintenance.ToString()}");
                var roleInput = Console.ReadLine();

                switch (roleInput)
                {
                    // Administrator has been chosen
                    case "1":
                        role = Role.Administrator;
                        roleSet = true;
                        break;
                    // Manager has been chosen
                    case "2":
                        role = Role.Manager;
                        roleSet = true;
                        break;
                    // Maintenance has been chosen
                    case "3":
                        role = Role.Maintenance;
                        roleSet = true;
                        break;
                    // invalid input
                    default:
                        Console.WriteLine("Invalid role specified");
                        roleSet = false;
                        continue;
                }
            }

            // if everything goes through, insert the new user in the repository
            userRepository.Insert(new User(userName, password, role));

            // return newly created user user name
            return userName;
        }
    }
}
