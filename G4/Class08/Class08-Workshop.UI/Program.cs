using System;

namespace Class08_Workshop.UI
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using Repository;
    using Services;
    using Services.Interfaces;

    class Program
    {
        private static ICarService _carService;
        private static IDriverService _driverService;
        private static IUserService _userService;
        private static ISeedService<Car> _carSeedService;
        private static ISeedService<Driver> _driverSeedService;
        private static ISeedService<User> _userSeedService;

        static Program()
        {
            // initialize repositories
            IGenericRepository<Car> carRepository = new InMemoryGenericRepository<Car>();
            IGenericRepository<Driver> driverRepository = new InMemoryGenericRepository<Driver>();
            IGenericRepository<User> userRepository = new InMemoryGenericRepository<User>();

            // initialize services
            _carService = new CarService(carRepository);
            _driverService = new DriverService(driverRepository, carRepository);
            _userService = new UserService(userRepository);

            // initialize seed services
            _carSeedService = (ISeedService<Car>)_carService;
            _driverSeedService = (ISeedService<Driver>)_driverService;
            _userSeedService = (ISeedService<User>)_userService;
        }

        static void Main(string[] args)
        {

            SeedCarsAndDrivers();
            SeedUsers();

            // repeat menus until user chooses to exit
            while (true)
            {
                // while user is not logged in
                while (_userService.CurrentUser == null)
                {
                    var choice = MenuHelpers.GetWelcomeMenuChoice();

                    switch (choice)
                    {
                        case WelcomeMenuChoice.LogIn:
                            var userName = MenuHelpers.ReadUserName();
                            var password = MenuHelpers.ReadPassword();

                            // try to login
                            var loginResult = _userService.LogIn(userName, password);

                            // if login failed
                            if (!loginResult)
                            {
                                Console.WriteLine("Invalid login info!");
                            }
                            // otherwise
                            else
                            {
                                Console.WriteLine($"Successfully logged in as {_userService.CurrentUser.UserName}!");
                            }

                            break;

                        case WelcomeMenuChoice.Exit:
                            return;
                    }

                    ClearConsole();
                }

                // once user is logged in, show logged in menu
                while (_userService.CurrentUser != null)
                {
                    var choice = MenuHelpers.GetLoggedInMenuChoiceForUser(_userService.CurrentUser);

                    switch (choice)
                    {
                        case LoggedInMenuChoice.NewUser:
                            string userName = MenuHelpers.ReadUserName();
                            string password = MenuHelpers.ReadPassword();
                            string passwordConfirmation = MenuHelpers.ReadPasswordConfirmation(password);
                            Role role = MenuHelpers.ReadUserRole();

                            // if everything goes through, insert the new user in the repository
                            bool registerResult = _userService.Register(userName, password, passwordConfirmation, role);

                            // if registration failed
                            if (!registerResult)
                            {
                                Console.WriteLine("Registration failed!");
                            }
                            // otherwise
                            else
                            {
                                Console.WriteLine($"Successfully registered user {userName}!");
                            }

                            break;

                        case LoggedInMenuChoice.TerminateUser:
                            List<User> availableUsersForTermination = _userService.GetUsers();

                            var userIdToBeTerminated = MenuHelpers.ReadUserId(availableUsersForTermination);

                            bool userDeleted = _userService.TerminateUser(userIdToBeTerminated);

                            // if user deletion failed
                            if (!userDeleted)
                            {
                                Console.WriteLine("User termination failed!");
                            }
                            // otherwise
                            else
                            {
                                Console.WriteLine($"User with id {userIdToBeTerminated} terminated!");
                            }

                            break;

                        case LoggedInMenuChoice.ListAllVehicles:

                            var operationalOnly = MenuHelpers.GetListVehiclesOperationalOnly();

                            var carsToBeListed = _carService.GetAllVehicles(operationalOnly);

                            carsToBeListed.Print();

                            break;

                        case LoggedInMenuChoice.LicensePlateStatus:

                            List<Car> carToListLicensePlateStatusFor = _carService.GetAllVehicles();

                            carToListLicensePlateStatusFor.PrintLicensePlateExpiryStatuses();
                            break;

                        case LoggedInMenuChoice.ListAllDrivers:
                            List<Driver> driversToBeListed = _driverService.GetAllDrivers();

                            driversToBeListed.Print();
                            break;

                        case LoggedInMenuChoice.TaxiLicenseStatus:
                            List<Driver> driversToListLicenseStatusFor = _driverService.GetAllDrivers();

                            driversToListLicenseStatusFor.PrintTaxiLicenseExpiryStatuses();
                            break;

                        case LoggedInMenuChoice.DriverManager:
                            ManageDriversMenuChoice manageDriversMenuChoice = MenuHelpers.GetManageDriversMenuChoice();

                            switch (manageDriversMenuChoice)
                            {
                                case ManageDriversMenuChoice.AssignDriver:
                                    List<Driver> availableDrivers = _driverService.GetAvailableDrivers();

                                    // if no available drivers, no point in doing assignment
                                    if (!availableDrivers.Any())
                                    {
                                        Console.WriteLine("No available drivers, cannot continue");
                                        break;
                                    }

                                    int driverIdToBeAssigned = MenuHelpers.GetDriverId(availableDrivers);
                                    Shift shift = MenuHelpers.GetDriverShiftUserInput();

                                    List<Car> availableCars = _carService.GetAvailableVehiclesForShift(shift);

                                    // if there are no available cars for chosen shift, no point to do assignment
                                    if (!availableCars.Any())
                                    {
                                        Console.WriteLine($"No available cars available for {shift} shift, cannot continue");
                                        break;
                                    }

                                    int carIdToBeAssignedTo = MenuHelpers.GetCarIdUserInput(availableCars);

                                    bool assignResult = _driverService.AssignDriverToCar(driverIdToBeAssigned, carIdToBeAssignedTo);

                                    // if assignment fails
                                    if (!assignResult)
                                    {
                                        Console.WriteLine("Driver assignment failed!");
                                    }
                                    // otherwise
                                    else
                                    {
                                        Console.WriteLine(
                                            $"Successfully assigned driver with id {driverIdToBeAssigned} to car with id {carIdToBeAssignedTo} with {shift} shift!");
                                    }

                                    break;
                                case ManageDriversMenuChoice.UnassignDriver:
                                    List<Driver> assignedDrivers = _driverService.GetAssignedDrivers();
                                    
                                    // if there are no assigned drivers, no point in doing unassignment
                                    if (!assignedDrivers.Any())
                                    {
                                        Console.WriteLine("No assigned drivers, cannot continue");
                                        break;
                                    }

                                    int driverIdToBeUnassigned = MenuHelpers.GetDriverId(assignedDrivers);

                                    bool unassignResult = _driverService.UnassignDriver(driverIdToBeUnassigned);

                                    // if unassignment fails
                                    if (!unassignResult)
                                    {
                                        Console.WriteLine("Unassign driver failed!");
                                    }
                                    // otherwise
                                    else
                                    {
                                        Console.WriteLine($"Unassignment of driver with id {driverIdToBeUnassigned} is successful!");
                                    }

                                    break;
                            }

                            break;

                        case LoggedInMenuChoice.ChangePassword:
                            string oldPassword = MenuHelpers.ReadPassword(PasswordInputType.Old);
                            string newPassword = MenuHelpers.ReadPassword(PasswordInputType.New);
                            passwordConfirmation =
                                MenuHelpers.ReadPasswordConfirmation(newPassword);

                            bool changePasswordResult = _userService.ChangePassword(oldPassword, newPassword, passwordConfirmation);

                            // if change password fails
                            if (!changePasswordResult)
                            {
                                Console.WriteLine("Change password failed!");
                            }
                            // otherwise
                            else
                            {
                                Console.WriteLine("Successfully changed password!");
                            }

                            break;

                        case LoggedInMenuChoice.Exit:
                            // return from Main = exit application
                            return;

                        case LoggedInMenuChoice.BackToMainMenu:
                            // unassign _userService.CurrentUser = no logged in user
                            _userService.LogOut();
                            break;
                    }

                    ClearConsole();
                }
            }
        }

        /// <summary>
        /// Helper method that aggregates seeding of users.
        /// </summary>
        private static void SeedUsers()
        {
            User adminUser = new User("admin", "admin", Role.Administrator);
            User managerUser = new User("manager", "manager", Role.Manager);
            User maintenanceUser = new User("maintenance", "maintenance", Role.Maintenance);

            List<User> users = new List<User>
            {
                adminUser,
                managerUser,
                maintenanceUser
            };

            _userSeedService.Seed(users);
        }

        /// <summary>
        /// Helper method that aggregates seeding of cars and drivers.
        /// </summary>
        private static void SeedCarsAndDrivers()
        {
            // insert a few assigned cars
            var bmwCar = new Car("BMW", "123456", DateTime.Now.AddMonths(6));
            var teslaCar = new Car("Tesla", "45342432", DateTime.Now.AddYears(1));
            var golfCar = new Car("Golf", "48324983", DateTime.Now.AddYears(-1));

            var cars = new List<Car>
            {
                bmwCar,
                teslaCar,
                golfCar,
                new Car("Fiat", "271368", DateTime.Now.AddMonths(4)),
                new Car("Renault" , "636781", DateTime.Today.AddYears(1))
            };

            _carSeedService.Seed(cars);

            // insert a few assigned drivers
            var driverJohn = new Driver("John", "Doe", Shift.Morning, "123456", DateTime.Now.AddMonths(1));
            var driverMary = new Driver("Mary", "Jane", Shift.AfterNoon, "324432", DateTime.Now.AddMonths(4));
            var driverElon = new Driver("Elon", "Musk", Shift.Evening, "291873", DateTime.Now.AddMonths(-1));

            var drivers = new List<Driver>
            {
                driverJohn,
                driverMary,
                driverElon,
                new Driver("Jill", "Valentine", Shift.Morning, "928381", DateTime.Now.AddMonths(3)),
                new Driver("Spike", "Spiegel", Shift.AfterNoon, "123993", DateTime.Now.AddMonths(4)),
                new Driver("Jet", "Black", Shift.Evening, "129837", DateTime.Now.AddYears(1))
            };

            // assign some cars to the drivers (not really affecting anything)
            driverJohn.AssignCar(bmwCar);
            driverJohn.AssignCar(golfCar);
            driverMary.AssignCar(bmwCar);
            driverMary.AssignCar(teslaCar);
            driverMary.AssignCar(golfCar);
            driverElon.AssignCar(teslaCar);

            _driverSeedService.Seed(drivers);
        }

        /// <summary>
        /// Clears Console output after a key has been pressed.
        /// </summary>
        private static void ClearConsole()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            Console.Clear();
        }
    }
}
