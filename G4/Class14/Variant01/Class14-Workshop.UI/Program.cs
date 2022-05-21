using System;

namespace Class14_Workshop.UI
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using Repository;
    using Services;
    using Services.Interfaces;

    /// <summary>
    /// Variant01 - Models don't use proper encapsulation (close to anemic models).
    /// 
    /// In a scenario like this where we don't have an actual database system to manage
    /// entity Ids, this approach has some advantages because it lets us set the entity Ids
    /// after object creation (without any hacks), and this allows entity Id assignment to be
    /// done by the repository layer (Ids are usually handled by the database system, so
    /// this does not break any responsibility rules/good practices). It also simplifies
    /// serialization/deserialization by having publicly accessible setters, and allows
    /// avoiding using Newtonsoft.Json property attributes in the models to configure
    /// serialization.
    ///
    /// But, this approach has one major disadvantages in the sense that it allows
    /// manipulation of entity state anywhere in the application - including properties
    /// like Id that should remain unchanged throughout the lifetime of the entity. This
    /// is a serious flaw and could allow serious data inconsistencies if you don't know
    /// what you are doing.
    /// </summary>
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
            IGenericRepository<Car> carRepository = new FileSystemGenericRepository<Car>();
            IGenericRepository<Driver> driverRepository = new FileSystemGenericRepository<Driver>();
            IGenericRepository<User> userRepository = new FileSystemGenericRepository<User>();

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
                                ColorWriter.WriteLine("Login unsuccessful. Please try again", TextColor.Red);
                            }
                            // otherwise
                            else
                            {
                                ColorWriter.WriteLine($"Successful Login! Welcome {_userService.CurrentUser.Role} user!", TextColor.Green);
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
                                ColorWriter.WriteLine("Creation unsuccessful. Please try again", TextColor.Red);
                            }
                            // otherwise
                            else
                            {
                                ColorWriter.WriteLine($"Successful creation of an {role} user!", TextColor.Green);
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

                                    bool assignResult = _driverService.AssignDriverToCar(driverIdToBeAssigned, carIdToBeAssignedTo, shift);

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
                                ColorWriter.WriteLine("Password change unsuccessful. Please try again", TextColor.Red);
                            }
                            // otherwise
                            else
                            {
                                ColorWriter.WriteLine("Successful change password!", TextColor.Green);
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
            User adminUser = User.CreateForSeed(1, "admin", "admin", Role.Administrator);
            User managerUser = User.CreateForSeed(2, "manager", "manager", Role.Manager);
            User maintenanceUser = User.CreateForSeed(3, "maintenance", "maintenance", Role.Maintenance);

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
            var bmwCar = Car.CreateForSeed(1, "BMW", "123456", DateTime.Now.AddMonths(6));
            var teslaCar = Car.CreateForSeed(2, "Tesla", "45342432", DateTime.Now.AddYears(1));
            var golfCar = Car.CreateForSeed(3, "Golf", "48324983", DateTime.Now.AddYears(-1));

            var cars = new List<Car>
            {
                bmwCar,
                teslaCar,
                golfCar,
                Car.CreateForSeed(4,"Fiat", "271368", DateTime.Now.AddMonths(4)),
                Car.CreateForSeed(5,"Renault" , "636781", DateTime.Today.AddYears(1))
            };

            // insert a few assigned drivers
            var driverJohn = Driver.CreateForSeed(1, "John", "Doe", "123456", DateTime.Now.AddMonths(1));
            var driverMary = Driver.CreateForSeed(2, "Mary", "Jane", "324432", DateTime.Now.AddMonths(4));
            var driverElon = Driver.CreateForSeed(3, "Elon", "Musk", "291873", DateTime.Now.AddMonths(-1));

            var drivers = new List<Driver>
            {
                driverJohn,
                driverMary,
                driverElon,
                Driver.CreateForSeed(4, "Jill", "Valentine", "928381", DateTime.Now.AddMonths(3)),
                Driver.CreateForSeed(5, "Spike", "Spiegel", "123993", DateTime.Now.AddMonths(4)),
                Driver.CreateForSeed(6, "Jet", "Black", "129837", DateTime.Now.AddYears(1))
            };

            // assign some cars to the drivers (not really affecting anything)
            driverJohn.AssignCar(bmwCar, Shift.Morning);
            driverMary.AssignCar(golfCar, Shift.AfterNoon);
            driverElon.AssignCar(teslaCar, Shift.Evening);

            _carSeedService.Seed(cars);
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
