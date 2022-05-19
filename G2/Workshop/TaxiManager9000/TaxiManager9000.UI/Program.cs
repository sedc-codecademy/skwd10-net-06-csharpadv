// See https://aka.ms/new-console-template for more information
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Exceptions;
using TaxiManager9000.Domain.Utils;
using TaxiManager9000.Services;
using TaxiManager9000.Services.Interfaces;
using TaxiManager9000.Services.Services;
using TaxiManager9000.UI.Helpers;
using TaxiManager9000.UI.Utils;

IAuthService authService = new AuthService();
IMaintainanceService maintainanceService = new MaintainanceService();
IAdminService adminService = new AdminService();
IManagerService managerService = new ManagerService();

await StartApplicationAsync(authService, adminService, maintainanceService, managerService);


async Task StartApplicationAsync(IAuthService authService, IAdminService adminService, 
                                 IMaintainanceService maintainanceService, 
                                 IManagerService managerService)
{
    ShowLogin(authService);
    await ShowMenuAsync(authService, adminService, maintainanceService, managerService);
}

async Task ShowMenuAsync(IAuthService authService, IAdminService adminService, 
                         IMaintainanceService maintainanceService, 
                         IManagerService managerService)
{
    if (authService.CurrentUser != null)
    {
        switch (authService.CurrentUser.Role)
        {
            case Role.Administrator:
                await ShowAdminMenuAsync(adminService);
                break;
            case Role.Maintainance:
                ShowMaintainenceMenu(maintainanceService);
                break;
            case Role.Manager:
                await ShowManagerMenuAsync(managerService);
                break;
            default:
                ConsoleUtils.WriteLineInColor($"Invalid role, {authService.CurrentUser.Role}", ConsoleColor.Red);
                break;
        }
    }
}

async Task ShowAdminMenuAsync(IAdminService adminService)
{
    Console.WriteLine($"{AdminMenuOptions.ADD_USER}) Create new user \n{AdminMenuOptions.TERMINATE_USER}) Terminate user");
    string input = Console.ReadLine();

    switch (input)
    {
        case AdminMenuOptions.ADD_USER:
            {
                Console.WriteLine("Enter username");
                string userName = Console.ReadLine();

                Console.WriteLine("Enter password");
                string password = Console.ReadLine();

                Console.WriteLine("Enter role");
                string role = Console.ReadLine();

                await adminService.AddUserAsync(userName, password, role.ToRoleEnum());
                break;
            }
        case AdminMenuOptions.TERMINATE_USER:
            {
                Console.WriteLine("All users:");
                adminService.ListAllUsers().ForEach(x => Console.WriteLine(x.UserName));

                Console.WriteLine("Enter username");
                string userName = Console.ReadLine();

                await adminService.TerminateUserAsync(userName);
                break;
            }
        case AdminMenuOptions.CHANGE_USER_PASSWORD:
            {
                Console.WriteLine("Enter username");
                string userName = Console.ReadLine();

                Console.WriteLine("Enter password");
                string password = Console.ReadLine();

                Console.WriteLine("Enter new password");
                string newPassword = Console.ReadLine();

                await adminService.ChangePasswordAsync(userName, password, newPassword);
                break;
            }
        default:
            throw new ArgumentOutOfRangeException("Invalid input");
    }
}

void ShowMaintainenceMenu(IMaintainanceService maintainanceService)
{
    Console.WriteLine($"{MaintainenceMenuOptions.LIST_ALL_CARS}) List All Cars \n{MaintainenceMenuOptions.LICENSE_PLATE_STATUS}) Lincense plate status");
    string input = Console.ReadLine();

    switch (input)
    {
        case MaintainenceMenuOptions.LIST_ALL_CARS:
            {
                List<Car> cars = maintainanceService.ListAllCars();
                foreach (Car car in cars)
                {
                    Console.WriteLine($"{car.Id}) {car.Model} with license plate {car.LicensePlate} and utilized {car.GetShiftPercentageUtilization():0.##}%");
                }
                break;
            }
        case MaintainenceMenuOptions.LICENSE_PLATE_STATUS:
            {
                List<Car> cars = maintainanceService.ListAllCars();

                foreach (Car car in cars.Where(car => car.LicensePlateExpiryDate < DateTime.Now))
                {
                    ConsoleUtils.WriteLineInColor($"[Expired] {car.Id}) Plate - {car.LicensePlate} expiring on {car.LicensePlateExpiryDate}", ConsoleColor.Red);
                }

                foreach (Car car in cars.Where(x => (x.LicensePlateExpiryDate - DateTime.Now) < TimeSpan.FromDays(31) && (x.LicensePlateExpiryDate - DateTime.Now) > TimeSpan.Zero))
                {
                    ConsoleUtils.WriteLineInColor($"[3 Months until expiry] {car.Id}) Plate - {car.LicensePlate} expiring on {car.LicensePlateExpiryDate}", ConsoleColor.Yellow);

                }

                foreach (Car car in cars.Where(x => x.LicensePlateExpiryDate > DateTime.Now.AddMonths(3)))
                {
                    ConsoleUtils.WriteLineInColor($"[Valid] {car.Id}) Plate - {car.LicensePlate} expiring on {car.LicensePlateExpiryDate}", ConsoleColor.Green);
                }
                break;
            }
        default:
            throw new ArgumentOutOfRangeException("Invalid input");
    }
}

async Task ShowManagerMenuAsync(IManagerService managerService)
{
    Console.WriteLine($"{ManagerMenuOptions.LIST_ALL_DRIVERS}) List All Drivers \n{ManagerMenuOptions.TAXI_LICENSE_STATUS}) Taxi Lincense status\n{ManagerMenuOptions.DRIVER_MANAGER}) Driver Manager");
    string input = Console.ReadLine();

    switch (input)
    {
        case ManagerMenuOptions.LIST_ALL_DRIVERS:
            {
                List<Driver> drivers = managerService.ListAllDrivers();

                foreach (Driver driver in drivers)
                {
                    Console.WriteLine($"{driver.Id}) {driver.FirstName} {driver.LastName} driving in shift {driver.Shift} with a {driver.Car?.Model ?? "Unassigned Car"}");
                }
                break;
            }
        case ManagerMenuOptions.TAXI_LICENSE_STATUS:
            {
                List<Driver> drivers = managerService.ListAllDrivers();

                foreach (Driver driver in drivers.Where(x => x.LicenseExpiryDate < DateTime.Now))
                {
                    ConsoleUtils.WriteLineInColor($"[Expired] {driver.Id}) {driver.FirstName} {driver.LastName} with license {driver.License} on {driver.LicenseExpiryDate}", ConsoleColor.Red);
                }

                foreach (Driver driver in drivers.Where(x => (x.LicenseExpiryDate - DateTime.Now) < TimeSpan.FromDays(31) && (x.LicenseExpiryDate - DateTime.Now) > TimeSpan.Zero))
                {
                    ConsoleUtils.WriteLineInColor($"[3 Months until expiry] {driver.Id}) {driver.FirstName} {driver.LastName} with license {driver.License} on {driver.LicenseExpiryDate}", ConsoleColor.Yellow);

                }

                foreach (Driver driver in drivers.Where(x => x.LicenseExpiryDate > DateTime.Now.AddMonths(3)))
                {
                    ConsoleUtils.WriteLineInColor($"[Valid] {driver.Id}) {driver.FirstName} {driver.LastName} with license {driver.License} on {driver.LicenseExpiryDate}", ConsoleColor.Green);
                }
                break;
            }
        case ManagerMenuOptions.DRIVER_MANAGER:
            {
                await ShowDriverManagerAsync(managerService);
                break;
            }
    }
}

async Task ShowDriverManagerAsync(IManagerService managerService)
{
    Console.WriteLine($"{ManagerMenuOptions.ASSIGN_UNASSIGNED_DRIVERS}) Assign Unassigned Drivers\n{ManagerMenuOptions.UNASSIGN_ASSIGNED_DRIVERS}) Unassign Assigned Drivers");
    string input = Console.ReadLine();

    switch (input)
    {
        case ManagerMenuOptions.ASSIGN_UNASSIGNED_DRIVERS:
            {

                List<Driver> drivers = managerService.ListUnassignedDrivers();

                foreach (Driver driver in drivers)
                {
                    Console.WriteLine($"{driver.Id}) {driver.FirstName} {driver.LastName} driving in shift {driver.Shift} with a {driver.Car?.Model ?? "Unassigned Car"}");
                }

                Console.WriteLine("Enter driver id: ");
                
                bool driverIdParsed = int.TryParse(Console.ReadLine(), out int driverId);

                if (!driverIdParsed)
                {
                    throw new InvalidDataException("Invalid value for driver id");
                }

                if (driverId > drivers.Count || driverId < 0)
                {
                    throw new IndexOutOfRangeException("Id was out of the provided range");
                }

                Console.WriteLine("Pick a shift: \"Morning\", \"Afternoon\" or \"Evening\"");

                bool shiftParsed =  Enum.TryParse(Console.ReadLine(), out Shift shift);

                if (!shiftParsed)
                {
                    throw new InvalidDataException("Invalid value for shift");
                }

                List<Car> cars = managerService.ListAllAvailableCars(shift);

                Console.WriteLine("Available cars: ");

                foreach (Car car in cars)
                {
                    Console.WriteLine($"{car.Id}) {car.Model} with license plate {car.LicensePlate} and utilized {car.GetShiftPercentageUtilization():0.##}%");
                }

                Console.WriteLine("Enter desired car Id");

                bool carIdParsed = int.TryParse(Console.ReadLine(), out int carId);

                if (!carIdParsed)
                {
                    throw new InvalidDataException("Invalid value for car id");
                }

                Console.WriteLine($"Assigning driver with id {driverId} to car with id {carId}");

                await managerService.AssignDriverAsync(driverId, carId);

                break;
            }
        case ManagerMenuOptions.UNASSIGN_ASSIGNED_DRIVERS:
            {
                List<Driver> drivers = managerService.ListAssignedDrivers();

                foreach (Driver driver in drivers)
                {
                    Console.WriteLine($"{driver.Id}) {driver.FirstName} {driver.LastName} driving in shift {driver.Shift} with a {driver.Car?.Model ?? "Unassigned Car"}");
                }

                Console.WriteLine("Enter driver id: ");

                bool driverIdParsed = int.TryParse(Console.ReadLine(), out int driverId);


                Console.WriteLine($"UnAssigning driver with id {driverId}");

                await managerService.UnAssignDriverAsync(driverId);
                break;
            }
    }
}

void ShowLogin(IAuthService authService)
{
    while (true)
    {
        Console.WriteLine("Enter username");
        string username = Console.ReadLine();

        Console.WriteLine("Enter password");
        string password = Console.ReadLine();

        User currentUser;
        try
        {
            authService.LogIn(username, password);

            ConsoleUtils.WriteLineInColor($"Successful login! Welcome {authService.CurrentUser.Role} {authService.CurrentUser.UserName}",
                                          ConsoleColor.Green);
            break;
        }
        catch (InvalidCredentialsException ex)
        {
            ConsoleUtils.WriteLineInColor(ex.Message, ConsoleColor.Red);
            ConsoleUtils.WriteLineInColor("Unsuccessful login, try again", ConsoleColor.Red);
        }
    }
}