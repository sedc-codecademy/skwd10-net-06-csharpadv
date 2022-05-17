#region Setup
using TaxiCo.TaxiManager9000.Domain.Enums;
using TaxiCo.TaxiManager9000.Domain.Models;
using TaxiCo.TaxiManager9000.Services.Services;
using TaxiCo.TaxiManager9000.Services.Services.Interfaces;
using TaxiCo.TaxiManager9000.Services.Utilities;

IUIService uiService = new UIService();
ICarService carService = new CarService();
IDriverService driverService = new DriverService();
IUserService userService = new UserService();

InitializeStartingData();
#endregion

while (true)
{
    #region LogIn
    //Console.Clear();
    if (userService.CurrentUser == null)
    {
        try
        {
            User inputUser = uiService.LogInMenu();
            userService.LogIn(inputUser.Username, inputUser.Password);
            uiService.Welcome(userService.CurrentUser);
        }
        catch (Exception ex)
        {
            ExtendedConsole.WriteLine(ex.Message, ConsoleColor.Red);
            Console.ReadLine();
            continue;
        }
    }

    #endregion

    int menuChoiceNumber = uiService.MainMenu(userService.CurrentUser.Role);
    if (menuChoiceNumber == -1) continue;
    MenuChoice mainMenuChoice = uiService.MenuItems[menuChoiceNumber - 1];
    switch (mainMenuChoice)
    {
        case MenuChoice.AddNewUser:
            string username = ExtendedConsole.GetInput("Username:");
            string password = ExtendedConsole.GetInput("Password");
            if(!StringValidator.ValidateUsername(username) || !StringValidator.ValidatePassword(password))
            {
                ExtendedConsole.WriteLine("Add failed. Username and Password must have at least 5 characters and password must contain at least 1 number", ConsoleColor.Red);
                Console.ReadLine();
                continue;
            }
            int role = uiService.ChooseMenu(new List<string> { "Administrator", "Manager", "Maintenance" });
            User newUser = new User(username, password, (Role)role);
            userService.Add(newUser);
            break;
        case MenuChoice.RemoveExistingUser:
            List<User> users = userService.GetAll().Where(x => x.Id != userService.CurrentUser.Id).ToList();
            int choice = uiService.ChooseEntitiesMenu(users);
            if (choice == -1) continue;
            userService.Remove(users[choice - 1].Id);
            break;
        case MenuChoice.ListAllDrivers:
            driverService.GetAll().Print();
            break;
        case MenuChoice.TaxiLicenseStatus:
            driverService.GetAll().PrintStatus();
            break;
        case MenuChoice.DriverManager:
            var driverManagerMenu = new List<DriverManagerChoice>() { DriverManagerChoice.AssignDriver, DriverManagerChoice.UnassignDriver };
            int driverManagerChoice = uiService.ChooseMenu(driverManagerMenu);
            var availableDrivers = driverService.GetAll(x => driverService.IsAvailableDriver(x));
            // come back here
            break;
        case MenuChoice.ListAllCars:
            carService.GetAll().Print();
            break;
        case MenuChoice.LicensePlateStatus:
            carService.GetAll().PrintStatus();
            break;
        case MenuChoice.ChangePassword:
            var oldPassword = ExtendedConsole.GetInput("Please enter old password: ");
            var newPassword = ExtendedConsole.GetInput("Please enter new password: ");
            bool changeSuccessfull = userService.ChangePassword(oldPassword, newPassword);
            if (changeSuccessfull) ExtendedConsole.WriteLine("Password changed.", ConsoleColor.Green);
            else ExtendedConsole.WriteLine("Password change failed. Please try again.", ConsoleColor.Red);
            Console.ReadLine();
            break;
        case MenuChoice.Exit:
            userService.CurrentUser = null;
            continue;



    }
}

    //// AsignedDrivers - Filled with custom setter
    ////carService.GetAll().ForEach(car => car.AsignedDrivers.ForEach(driver => Console.WriteLine($"{car.Model} - {driver.FullName} Shift: {driver.Shift}")));

    //while (true)
    //{
    //    #region LogIn
    //    //Console.Clear();
    //    if(userService.CurrentUser == null)
    //    {
    //        try
    //        {
    //            User inputUser = uiService.LogInMenu();
    //            userService.LogIn(inputUser.Username, inputUser.Password);
    //            uiService.Welcome(userService.CurrentUser);
    //        }
    //        catch(Exception ex)
    //        {
    //            ExtendedConsole.WriteLine(ex.Message, ConsoleColor.Red);
    //            Console.ReadLine();
    //            continue;
    //        }
    //    }

    //    #endregion
    //    Console.WriteLine("1) List All Cars\n2) List All Drivers\n3) List All Users");

    //    bool isUserInputValid = int.TryParse(Console.ReadLine(), out int validUserInput);

    //    if (!isUserInputValid)
    //    {
    //        Console.ForegroundColor = ConsoleColor.Red;
    //        Console.WriteLine("Invalid Input!");
    //        Console.ResetColor();
    //        continue;
    //    }

    //    // validUserInput == 1
    //    if (validUserInput.Equals(1))
    //    {
    //        Console.WriteLine("List of cars:");
    //        foreach (Car car in carService.GetAll())
    //        {
    //            Console.WriteLine(car.Print());
    //        }
    //        Console.WriteLine("==============================================");
    //    }
    //    else if (validUserInput.Equals(2))
    //    {
    //        Console.WriteLine("List of drivers");
    //        driverService.GetAll().ForEach(driver => Console.WriteLine(driver.Print()));
    //        Console.WriteLine("==============================================");
    //    }
    //    else if (validUserInput.Equals(3))
    //    {
    //        Console.WriteLine("List of users:");
    //        userService.GetAll().ForEach(user => Console.WriteLine(user.Print()));
    //        Console.WriteLine("==============================================");
    //    }
    //    else
    //    {
    //        Console.ForegroundColor = ConsoleColor.Red;
    //        Console.WriteLine("Invalid Input!");
    //        Console.ResetColor();
    //        continue;
    //    }
    //}


    void InitializeStartingData()
{
    User administrator = new User("BobBobsky", "bobbest1", Role.Administrator);
    User manager = new User("JillWayne", "jillawesome1", Role.Manager);
    User maintenaces = new User("GregGregsky", "supergreg1", Role.Maintenance);
    List<User> seedUsers = new List<User> { administrator, maintenaces, manager };
    userService.Seed(seedUsers);

    Car car1 = new Car("Auris (Toyota)", "AFW950", new DateTime(2023, 12, 1));
    Car car2 = new Car("Transporter (Volkswagen)", "CKE480", new DateTime(2021, 10, 1));
    Car car3 = new Car("Mondeo (Ford)", "ASK150", new DateTime(2023, 5, 5));
    Car car4 = new Car("Premier (Peugeot)", "2AR9907", new DateTime(2022, 10, 3));
    Car car5 = new Car("Vito (Mercedes)", "6RND294", new DateTime(2023, 3, 11));
    List<Car> seedCars = new List<Car> { car1, car2, car3, car4, car5 };
    carService.Seed(seedCars);

    Driver driver1 = new Driver("Romario", "Walsh", Shift.NoShift, null, "LC12451234", new DateTime(2023, 11, 5));
    Driver driver2 = new Driver("Kathleen", "Rankin", Shift.Morning, car1, "AM12412234", new DateTime(2022, 1, 12));
    Driver driver3 = new Driver("Zakk", "Hook", Shift.Afternoon, car1, "PA12412AB4", new DateTime(2023, 9, 3));
    Driver driver4 = new Driver("Joy", "Shelton", Shift.Evening, car1, "AB5321VG2", new DateTime(2023, 5, 15));
    Driver driver5 = new Driver("Krity", "Walsh", Shift.Morning, car2, "GF16512234", new DateTime(2023, 1, 1));
    List<Driver> seedDrivers = new List<Driver> { driver1, driver2, driver3, driver4, driver5 };
    driverService.Seed(seedDrivers);
}