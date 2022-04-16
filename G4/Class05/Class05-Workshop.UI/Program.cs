using System;

namespace Class05_Workshop.UI
{
    using System.Collections.Generic;
    using Domain;
    using Repository;

    class Program
    {
        /// <summary>
        /// Stores the user name of logged in user.
        /// </summary>
        private static string _loggedInUser;

        static void Main(string[] args)
        {
            // initialize repositories
            ICarRepository carRepository = new CarRepository();
            IDriverRepository driverRepository = new DriverRepository();
            IUserRepository userRepository = new UserRepository();

            // insert a few cars
            var bmwCar = new Car("BMW", "123456", DateTime.Now.AddMonths(6));
            var teslaCar = new Car("Tesla", "45342432", DateTime.Now.AddYears(1));
            var golfCar = new Car("Golf", "48324983", DateTime.Now.AddYears(-1));

            var cars = new List<Car>
            {
                bmwCar,
                teslaCar,
                golfCar
            };

            carRepository.InsertMany(cars);

            // insert a few drivers
            var driver01 = new Driver("John", "Doe", Shift.Morning);
            var driver02 = new Driver("Mary", "Jane", Shift.AfterNoon);
            var driver03 = new Driver("Elon", "Musk", Shift.Evening);

            var drivers = new List<Driver>
            {
                driver01,
                driver02,
                driver03
            };

            // assign some cars to the drivers (not really affecting anything)
            driver01.AssignCar(bmwCar);
            driver01.AssignCar(golfCar);
            driver02.AssignCar(bmwCar);
            driver02.AssignCar(teslaCar);
            driver02.AssignCar(golfCar);
            driver03.AssignCar(teslaCar);

            driverRepository.InsertMany(drivers);

            // consider pre-inserting some "built-in" users as well so you can
            // skip the "Register" step

            while (true)
            {
                // print landing menu
                Console.WriteLine("Welcome guest!");
                Console.WriteLine("~~~~~~~~~~~~~~");
                Console.WriteLine("1) Log in");
                Console.WriteLine("2) Register");

                var guestInput = Console.ReadLine();

                switch (guestInput)
                {
                    // Log in was chosen
                    case "1":
                        // while we don't have the user name of the logged in user
                        while (string.IsNullOrWhiteSpace(_loggedInUser))
                        {
                            _loggedInUser = userRepository.LogIn();

                            // if login attempt produced a valid user name
                            if (!string.IsNullOrWhiteSpace(_loggedInUser))
                            {
                                Console.WriteLine($"Successfully logged in as {_loggedInUser}!");
                            }
                        }

                        ClearConsole();

                        // while we have a user logged in (_loggedInUser is not null or empty)
                        while (!string.IsNullOrWhiteSpace(_loggedInUser))
                        {
                            // show logged in user menu and record whether logout was requested
                            bool shouldLogOut = HandleLoggedInUser(carRepository, driverRepository);

                            if (shouldLogOut)
                            {
                                Console.WriteLine($"Successfully logged out user {_loggedInUser}!");

                                // clear logged out user
                                _loggedInUser = null;
                            }

                            ClearConsole();
                        }

                        break;

                    // Register was chosen
                    case "2":
                        // show register menu and capture the user name of the newly
                        // registered user so we can display it below
                        var registeredUser = userRepository.Register();

                        Console.WriteLine($"Successfully registered user {registeredUser}!");

                        ClearConsole();

                        break;
                    // choice was not valid
                    default:
                        Console.WriteLine("Invalid input, try again");
                        continue;
                }
            }
        }

        /// <summary>
        /// Method to handle operations after an user has been logged in.
        /// </summary>
        /// <param name="carRepository">The car repository instance where car info will be fetched from.</param>
        /// <param name="driverRepository">The driver repository instance where driver info will be fetched from.</param>
        /// <returns>If user requested to log out <c>true</c>; otherwise <c>false</c>.</returns>
        private static bool HandleLoggedInUser(ICarRepository carRepository, IDriverRepository driverRepository)
        {
            Console.WriteLine($"Welcome, {_loggedInUser}!");
            Console.WriteLine("What do you want to do today?");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1) Check car licenses expiry");
            Console.WriteLine("2) List all vehicles");
            Console.WriteLine("3) List all drivers");
            Console.WriteLine();
            Console.WriteLine("4) Log out");

            var loggedInUserInput = Console.ReadLine();

            switch (loggedInUserInput)
            {
                // Check car licenses expiry was chosen
                case "1":
                    Console.WriteLine("Car license expiry statuses:");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    carRepository.CheckLicenses();
                    break;
                // List all vehicles was chosen
                case "2":
                    // helper variable to control the while loop when prompting user
                    // for the type of vehicles that need to be displayed
                    bool carsListed = false;
                    
                    while (!carsListed)
                    {
                        Console.WriteLine("Do you want to list only operational vehicles? (Y/n)");
                        var operationalOnlyInput = Console.ReadLine();

                        switch (operationalOnlyInput)
                        {
                            // show only operational cars
                            case "y":
                            case "Y":
                                Console.WriteLine("Operational cars list:");
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
                                carRepository.ListAllCars(true);
                                carsListed = true;
                                break;
                            // show all cars
                            case "n":
                            case "N":
                                Console.WriteLine("All cars list:");
                                Console.WriteLine("~~~~~~~~~~~~~~");
                                carRepository.ListAllCars(false);
                                carsListed = true;
                                break;
                            // invalid input
                            default:
                                Console.WriteLine("Invalid input, try again");
                                carsListed = false;
                                continue;
                        }
                    }

                    break;
                // List all drivers was chosen
                case "3":
                    Console.WriteLine("Driver list:");
                    Console.WriteLine("~~~~~~~~~~~~");
                    driverRepository.PrintAll();
                    break;
                // Log out was chosen, return true to signal that user
                // was logged out
                case "4":
                    return true;
                default:
                    Console.WriteLine("Invalid input, try again");
                    break;
            }

            return false;
        }

        /// <summary>
        /// Clears console output after a key has been pressed.
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
