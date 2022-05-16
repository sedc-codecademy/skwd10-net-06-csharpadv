namespace Class08_Workshop.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain;

    /// <summary>
    /// Static helper class for handling menu input.
    /// </summary>
    static class MenuHelpers
    {
        /// <summary>
        /// Gets user input welcome menu choice and parses it to
        /// <see cref="WelcomeMenuChoice"/>.
        /// </summary>
        /// <returns>The <see cref="WelcomeMenuChoice"/> according to user input.</returns>
        public static WelcomeMenuChoice GetWelcomeMenuChoice()
        {
            while (true)
            {
                // print welcome menu
                Console.WriteLine("Welcome guest!");
                Console.WriteLine("~~~~~~~~~~~~~~");
                Console.WriteLine("1) Log in");
                Console.WriteLine("2) Exit");

                var guestInput = Console.ReadLine();

                switch (guestInput)
                {
                    case "1":
                        return WelcomeMenuChoice.LogIn;
                    case "2":
                        return WelcomeMenuChoice.Exit;
                    default:
                        Console.WriteLine("Invalid input, try again");
                        continue;
                }
            }
        }

        /// <summary>
        /// Gets user input logged in menu choice for a given user and parses it to
        /// <see cref="LoggedInMenuChoice"/>. Depending on the role of the provided
        /// user, it should render different menus.
        /// </summary>
        /// <param name="user">The user the menu needs to be rendered for.</param>
        /// <returns>The <see cref="LoggedInMenuChoice"/> according to user input.</returns>
        public static LoggedInMenuChoice GetLoggedInMenuChoiceForUser(User user)
        {
            Console.WriteLine($"Welcome, {user.UserName}!");
            Console.WriteLine("What do you want to do today?");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            switch (user.Role)
            {
                case Role.Administrator:
                    Console.WriteLine("1) New user");
                    Console.WriteLine("2) Terminate user");
                    break;
                case Role.Maintenance:
                    Console.WriteLine("1) List all vehicles");
                    Console.WriteLine("2) License plate status");
                    break;
                case Role.Manager:
                    Console.WriteLine("1) List all drivers");
                    Console.WriteLine("2) Taxi license status");
                    Console.WriteLine("3) Driver manager");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("4) Change password");
            Console.WriteLine("5) Exit program");
            Console.WriteLine("6) Go back to main menu (log out)");

            while (true)
            {
                var loggedInUserInput = Console.ReadLine();

                switch (loggedInUserInput)
                {
                    case "1":
                        switch (user.Role)
                        {
                            case Role.Administrator:
                                return LoggedInMenuChoice.NewUser;
                            case Role.Maintenance:
                                return LoggedInMenuChoice.ListAllVehicles;
                            case Role.Manager:
                                return LoggedInMenuChoice.ListAllDrivers;
                        }

                        break;
                    case "2":
                        switch (user.Role)
                        {
                            case Role.Administrator:
                                return LoggedInMenuChoice.TerminateUser;
                            case Role.Maintenance:
                                return LoggedInMenuChoice.LicensePlateStatus;
                            case Role.Manager:
                                return LoggedInMenuChoice.TaxiLicenseStatus;
                        }

                        break;
                    case "3":
                        switch (user.Role)
                        {
                            case Role.Manager:
                                return LoggedInMenuChoice.DriverManager;
                        }

                        break;

                    case "4":
                        return LoggedInMenuChoice.ChangePassword;

                    case "5":
                        return LoggedInMenuChoice.Exit;

                    case "6":
                        return LoggedInMenuChoice.BackToMainMenu;

                    default:
                        Console.WriteLine("Invalid input, try again");
                        continue;
                }
            }
        }

        /// <summary>
        /// Shows sub menu for whether only operational vehicles should be shown when listing
        /// all vehicles and returns user input menu choice.
        /// </summary>
        /// <returns><c>true</c> if only operational vehicles should be shown; otherwise <c>false</c>.</returns>
        public static bool GetListVehiclesOperationalOnly()
        {
            Console.WriteLine("Do you want to list only operational vehicles? (Y/n)");

            bool? operationalOnly = null;

            while (!operationalOnly.HasValue)
            {
                var operationalOnlyInput = Console.ReadLine();

                switch (operationalOnlyInput)
                {
                    // show only operational cars
                    case "y":
                    case "Y":
                        operationalOnly = true;

                        break;
                    // show all cars
                    case "n":
                    case "N":
                        operationalOnly = false;

                        break;
                    // invalid input
                    default:
                        Console.WriteLine("Invalid input, try again");
                        continue;
                }
            }

            return operationalOnly.Value;
        }

        /// <summary>
        /// Gets user input manage drivers menu choice and parses it to
        /// <see cref="ManageDriversMenuChoice"/>.
        /// </summary>
        /// <returns>The <see cref="ManageDriversMenuChoice"/> according to user input.</returns>
        public static ManageDriversMenuChoice GetManageDriversMenuChoice()
        {
            Console.WriteLine("Manage Drivers");
            Console.WriteLine("~~~~~~~~~~~~~~");
            Console.WriteLine("1) Assign unassigned drivers");
            Console.WriteLine("2) Unassign drivers");

            while (true)
            {
                string manageDriversUserInput = Console.ReadLine();

                switch (manageDriversUserInput)
                {
                    case "1":
                        return ManageDriversMenuChoice.AssignDriver;
                    case "2":
                        return ManageDriversMenuChoice.UnassignDriver;
                    default:
                        Console.WriteLine("Invalid input, try again");
                        continue;
                }
            }
        }

        /// <summary>
        /// Reads user input user name from console. Check if input is empty.
        /// </summary>
        /// <returns>The user input user name.</returns>
        public static string ReadUserName()
        {
            string userName = null;
            // while userName input is empty
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.Write("Please enter user name: ");
                userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.WriteLine("User name cannot be empty!");
                }
            }

            return userName;
        }

        /// <summary>
        /// Reads user input password from console. Checks if input is empty. Changes prompt content depending on password being read.
        /// </summary>
        /// <param name="passwordInputType">The type of password that is being read. Only used for setting up the console prompt content.</param>
        /// <returns>The user input password.</returns>
        public static string ReadPassword(PasswordInputType passwordInputType = PasswordInputType.Default)
        {
            string password = null;
            // while password input is empty
            while (string.IsNullOrWhiteSpace(password))
            {
                string prompt;

                switch (passwordInputType)
                {
                    case PasswordInputType.Old:
                        prompt = "Please enter old password: ";
                        break;
                    case PasswordInputType.New:
                        prompt = "Please enter new password: ";
                        break;
                    case PasswordInputType.Default:
                    default:
                        prompt = "Please enter password: ";
                        break;
                }

                Console.Write(prompt);
                password = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Password cannot be empty!");
                }
            }

            return password;
        }

        /// <summary>
        /// Reads user input password confirmation from console. Compares to previously entered password.
        /// </summary>
        /// <param name="password">The password for which the password confirmation will be read.</param>
        /// <returns>The user input password confirmation.</returns>
        public static string ReadPasswordConfirmation(string password)
        {
            string passwordConfirmation = null;
            // while password and passwordConfirmation don't match
            while (passwordConfirmation != password)
            {
                Console.Write("Please confirm password: ");
                passwordConfirmation = Console.ReadLine();

                if (passwordConfirmation != password)
                {
                    Console.WriteLine("Passwords do not match, try again");
                }
            }

            return passwordConfirmation;
        }

        /// <summary>
        /// Reads user input user role from console. Check if input is a valid role.
        /// </summary>
        /// <returns>The user input role.</returns>
        public static Role ReadUserRole()
        {
            while (true)
            {
                Console.WriteLine("Please enter your desired role:");
                Console.WriteLine($"1) {Role.Administrator}");
                Console.WriteLine($"2) {Role.Manager}");
                Console.WriteLine($"3) {Role.Maintenance}");
                var roleInput = Console.ReadLine();

                switch (roleInput)
                {
                    // Administrator has been chosen
                    case "1":
                        return Role.Administrator;
                    // Manager has been chosen
                    case "2":
                        return Role.Manager;
                    // Maintenance has been chosen
                    case "3":
                        return Role.Maintenance;
                    // invalid input
                    default:
                        Console.WriteLine("Invalid role specified");
                        continue;
                }
            }
        }

        /// <summary>
        /// Reads user input user id from console. Check if input is valid.
        /// </summary>
        /// <returns>The user input user id.</returns>
        public static int ReadUserId(List<User> users)
        {
            users.Print();

            while (true)
            {
                string userIdUserInput = Console.ReadLine();

                int userId;

                if (int.TryParse(userIdUserInput, out userId) || users.Any(user => user.Id == userId)) return userId;

                Console.WriteLine("Invalid input, try again");
            }
        }

        /// <summary>
        /// Reads user input driver id from console. Check if input is valid.
        /// </summary>
        /// <returns>The user input driver id.</returns>
        public static int GetDriverId(List<Driver> drivers)
        {
            drivers.Print();

            Console.Write("Choose a driver id: ");

            while (true)
            {
                var driverIdUserInput = Console.ReadLine();

                int driverId;

                if (int.TryParse(driverIdUserInput, out driverId) &&
                    drivers.Any(driver => driver.Id == driverId)) return driverId;

                Console.WriteLine("Invalid input, try again");
            }
        }

        /// <summary>
        /// Reads user input driver shift from console. Check if input is a valid shift.
        /// </summary>
        /// <returns>The user input shift.</returns>
        public static Shift GetDriverShiftUserInput()
        {
            Console.WriteLine("Available shifts:");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"1) {Shift.Morning}");
            Console.WriteLine($"2) {Shift.AfterNoon}");
            Console.WriteLine($"3) {Shift.Evening}");

            Console.Write("Pick a shift: ");

            while (true)
            {
                var driverShiftUserInput = Console.ReadLine();

                Shift driverShift;
                
                if (Enum.TryParse(driverShiftUserInput, out driverShift)) return driverShift;
                
                Console.WriteLine("Invalid input, try again");
            }
        }

        /// <summary>
        /// Reads user input car id from console. Check if input is valid int.
        /// </summary>
        /// <returns>The user input car id.</returns>
        public static int GetCarIdUserInput(List<Car> cars)
        {
            cars.Print();

            while (true)
            {
                var carIdUserInput = Console.ReadLine();

                int carId;

                if (int.TryParse(carIdUserInput, out carId)) return carId;

                Console.WriteLine("Invalid input, try again");
            }
        }
    }

    /// <summary>
    /// Welcome menu options.
    /// </summary>
    public enum WelcomeMenuChoice
    {
        LogIn,
        Exit
    }

    /// <summary>
    /// Choices for menu when user is logged in.
    /// </summary>
    public enum LoggedInMenuChoice
    {
        NewUser,
        TerminateUser,
        ListAllVehicles,
        LicensePlateStatus,
        ListAllDrivers,
        TaxiLicenseStatus,
        DriverManager,
        ChangePassword,
        Exit,
        BackToMainMenu
    }

    /// <summary>
    /// Menu choices when managing drivers.
    /// </summary>
    internal enum ManageDriversMenuChoice
    {
        AssignDriver,
        UnassignDriver
    }

    /// <summary>
    /// Password types when reading user input password.
    /// </summary>
    internal enum PasswordInputType
    {
        Default,
        Old,
        New
    }
}
