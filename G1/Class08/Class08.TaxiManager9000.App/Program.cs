#region Setup
using Class08.TaxiManager9000.Domain.Entities;
using Class08.TaxiManager9000.Domain.Enums;
using Class08.TaxiManager9000.Services.Interfaces;
using Class08.TaxiManager9000.Services.Services;

ICarService carService = new CarService();
IDriverService driverService = new DriverService();
IUserService userService = new UserService();

InitializeStartingData();
#endregion

while (true)
{
    Console.Clear();
    if (userService.CurrentUser == null)
    {
        try
        {
            Console.WriteLine("Taxi Manager 9000");
            Console.WriteLine("Log In:");
            Console.Write("Username:");
            string? username = Console.ReadLine();
            Console.Write("Password:");
            string? password = Console.ReadLine();
            userService.Login(username, password);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Successful Login! Welcome[{userService.CurrentUser.Role}] user!");
            Console.ResetColor();
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Login unsuccessful. Please try again");
            Console.ResetColor();
            Console.ReadLine();
            continue;
        }
    }

    bool loopActive = true;
    while (loopActive)
    {
        Console.Clear();
        switch (userService.CurrentUser.Role)
        {
            case RoleEnum.Administrator:
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("1. Change Password");
                        Console.WriteLine("2. Add New User");
                        Console.WriteLine("3. Terminate User");
                        Console.WriteLine("4. Exit");
                        int selectedOption = int.Parse(Console.ReadLine());
                        if (selectedOption > 4 || selectedOption < 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong selection, try again!");
                            Console.ResetColor();
                            Console.ReadLine();
                        }

                        switch (selectedOption)
                        {
                            case 1:
                                {
                                    Console.Write("Insert old password: ");
                                    string oldPass = Console.ReadLine();
                                    Console.Write("Insert new password: ");
                                    string newPass = Console.ReadLine();
                                    if (userService.ChangePassword(userService.CurrentUser.Id, oldPass, newPass))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Password changed!");
                                        Console.ResetColor();
                                        Console.ReadLine();
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    try
                                    {
                                        Console.Write("Username:");
                                        string username = Console.ReadLine();
                                        Console.Write("Password:");
                                        string password = Console.ReadLine();
                                        Console.WriteLine("Select Role: 1. Administrator, 2. Manager, 3. Maintenance");
                                        int enumInt = int.Parse(Console.ReadLine()) - 1;
                                        if (enumInt < 0 || enumInt > 2)
                                        {

                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid role selection!");
                                            Console.ResetColor();
                                            Console.ReadLine();
                                            break;
                                        }

                                        RoleEnum role = (RoleEnum)enumInt;
                                        User user = new User(username, password, role);
                                        userService.Add(user);

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("New User Added");
                                        Console.ResetColor();
                                        Console.ReadLine();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(ex.Message);
                                        Console.ResetColor();
                                        Console.ReadLine();
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    try
                                    {
                                        Console.WriteLine("Select User For Removal (insert number in front of username):");
                                        userService.GetAll().ForEach(x => Console.WriteLine(x.Print()));

                                        if (userService.Remove(int.Parse(Console.ReadLine())))
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("User removed");
                                            Console.ResetColor();
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("User does not exist");
                                            Console.ResetColor();
                                            Console.ReadLine();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(ex.Message);
                                        Console.ResetColor();
                                        Console.ReadLine();
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    userService.CurrentUser = null;
                                    loopActive = false;
                                    break;
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input, try again!");
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                }
                break;
            case RoleEnum.Manager:
                {
                    Console.Clear();
                    Console.WriteLine("1. Change Password");
                    Console.WriteLine("2. List All Drivers");
                    Console.WriteLine("3. Check Taxi License Status");
                    Console.WriteLine("4. Assign Unassigned Drivers");
                    Console.WriteLine("5. Unasign Assigned Drivers");
                    Console.WriteLine("6. Exit");

                    int selectedOption = int.Parse(Console.ReadLine());

                    switch (selectedOption)
                    {
                        case 1:
                            {
                                Console.Write("Insert old password: ");
                                string oldPass = Console.ReadLine();
                                Console.Write("Insert new password: ");
                                string newPass = Console.ReadLine();
                                if (userService.ChangePassword(userService.CurrentUser.Id, oldPass, newPass))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Password changed!");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                }
                                break;
                            }
                        case 2:
                            {
                                driverService.GetAll().ForEach(x => Console.WriteLine(x.Print()));
                                Console.ReadLine();
                                break;
                            }
                        case 3:
                            {
                                carService.GetAll().ForEach(x =>
                                {
                                    var status = x.IsLicenseExpired();

                                    switch (status)
                                    {
                                        case ExpieryStatusEnum.Expired:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            break;
                                        case ExpieryStatusEnum.Valid:
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            break;
                                        case ExpieryStatusEnum.Warning:
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            break;
                                    }

                                    Console.WriteLine(x.Print());
                                    Console.ResetColor();
                                });
                                Console.ReadLine();
                                break;
                            }
                        case 4:
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("============= Assign Unassigned Drivers ============");
                                    Console.WriteLine("Select Driver (insert ID in front of name):");
                                    driverService.GetUnassignedDrivers().ForEach(x => Console.WriteLine(x.Print()));
                                    int driverId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("=============================================================");
                                    Console.WriteLine("Select shift:");
                                    Console.WriteLine("1. Morning");
                                    Console.WriteLine("2. Afternoon");
                                    Console.WriteLine("3. Evening");
                                    int shiftId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("=============================================================");
                                    Console.WriteLine("Select from available cars (insert id in front of the car):");
                                    carService.GetAvailableCarsInShift((ShiftEnum)shiftId).ForEach(x => Console.WriteLine(x.Print()));
                                    int carID = int.Parse(Console.ReadLine());
                                    Driver driverToUpdate = driverService.GetById(driverId);
                                    if (driverToUpdate != null)
                                    {
                                        driverToUpdate.Shift = (ShiftEnum)shiftId;
                                        Car carToUpdate = carService.GetById(carID);
                                        driverToUpdate.Car = carToUpdate;
                                        carToUpdate.AssignedDrivers.Add(driverToUpdate);
                                        Console.WriteLine("Driver Assignment Finished");
                                        Console.ReadLine();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Assignment failed. Please try again");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                }
                                break;
                            }
                        case 5:
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("============= Assign Unassigned Drivers ============");
                                    Console.WriteLine("Select Driver (insert ID in front of name):");
                                    driverService.GetAssignedDrivers().ForEach(x => Console.WriteLine(x.Print()));
                                    int driverId = int.Parse(Console.ReadLine());
                                    Driver driverToUnassign = driverService.GetById(driverId);
                                    Car carToUpdate = carService.GetById(driverToUnassign.Car.Id);
                                    var assignedDriver = carToUpdate.AssignedDrivers.FirstOrDefault(x => x.Id == driverToUnassign.Id);
                                    if (assignedDriver != null)
                                    {
                                        carToUpdate.AssignedDrivers.Remove(assignedDriver);
                                    }
                                    driverToUnassign.Car = null;
                                    driverToUnassign.Shift = ShiftEnum.NoShift;
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Unassignment failed. Please try again");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                }
                                break;
                            }
                        case 6:
                            {
                                userService.CurrentUser = null;
                                loopActive = false;
                                break;
                            }
                    }
                }
                break;
            case RoleEnum.Maintenance:
                {
                    Console.Clear();
                    Console.WriteLine("1. Change Password");
                    Console.WriteLine("2. List All Vehicles");
                    Console.WriteLine("3. Check Taxi License Status");
                    Console.WriteLine("4. Exit");

                    int selectedOption = int.Parse(Console.ReadLine());

                    switch (selectedOption)
                    {
                        case 1:
                            {
                                Console.Write("Insert old password: ");
                                string oldPass = Console.ReadLine();
                                Console.Write("Insert new password: ");
                                string newPass = Console.ReadLine();
                                if (userService.ChangePassword(userService.CurrentUser.Id, oldPass, newPass))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Password changed!");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                }
                                break;
                            }
                        case 2:
                            {
                                carService.GetAll().ForEach(x => Console.WriteLine(x.Print()));
                                Console.ReadLine();
                                break;
                            }
                        case 3:
                            {
                                carService.GetAll().ForEach(x =>
                                {
                                    var status = x.IsLicenseExpired();

                                    switch (status)
                                    {
                                        case ExpieryStatusEnum.Expired:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            break;
                                        case ExpieryStatusEnum.Valid:
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            break;
                                        case ExpieryStatusEnum.Warning:
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            break;
                                    }

                                    Console.WriteLine(x.Print());
                                    Console.ResetColor();
                                });
                                Console.ReadLine();
                                break;
                            }
                        case 4:
                            {
                                userService.CurrentUser = null;
                                loopActive = false;
                                break;
                            }
                    }
                    break;
                }
        }
    }
}

#region Seeding
void InitializeStartingData()
{
    User administrator = new User("BobBobsky", "bobbest1", RoleEnum.Administrator);
    User manager = new User("JillWayne", "jillawesome1", RoleEnum.Manager);
    User maintenances = new User("GregGregsky", "supergreg1", RoleEnum.Maintenance);
    List<User> seedUsers = new List<User>() { administrator, manager, maintenances };
    userService.Seed(seedUsers);

    Car car1 = new Car("Auris (Toyota)", "AFW950", new DateTime(2023, 12, 1));
    Car car2 = new Car("Auris (Toyota)", "CKE480", new DateTime(2021, 10, 15));
    Car car3 = new Car("Transporter (Volkswagen)", "GZDR69", new DateTime(2024, 5, 30));
    Car car4 = new Car("Mondeo (Ford)", "5RIP283", new DateTime(2022, 5, 13));
    Car car5 = new Car("Premier (Peugeot)", "2AR9907", new DateTime(2022, 11, 9));
    Car car6 = new Car("Vito (Mercedes)", "6RND294", new DateTime(2023, 3, 11));
    List<Car> seedCars = new List<Car>() { car1, car2, car3, car4, car5, car6 };
    carService.Seed(seedCars);

    Driver driver1 = new Driver("Romario", "Walsh", ShiftEnum.NoShift, null, "LC12456123", new DateTime(2023, 11, 5));
    Driver driver2 = new Driver("Kathleen", "Rankin", ShiftEnum.Morning, car1, "LC54435234", new DateTime(2022, 1, 12));
    Driver driver3 = new Driver("Ashanti", "Mooney", ShiftEnum.Evening, car1, "LC65803245", new DateTime(2022, 5, 19));
    Driver driver4 = new Driver("Zakk", "Hook", ShiftEnum.Afternoon, car1, "LC20897583", new DateTime(2023, 9, 28));
    Driver driver5 = new Driver("Xavier", "Kelly", ShiftEnum.NoShift, null, "LC15636280", new DateTime(2024, 6, 1));
    Driver driver6 = new Driver("Joy", "Shelton", ShiftEnum.Evening, car2, "LC47845611", new DateTime(2023, 7, 3));
    Driver driver7 = new Driver("Kristy", "Riddle", ShiftEnum.Morning, car3, "LC19006543", new DateTime(2024, 6, 12));
    Driver driver8 = new Driver("Stuart", "Mayer", ShiftEnum.Evening, car3, "LC53187767", new DateTime(2023, 10, 10));
    List<Driver> seedDrivers = new List<Driver>() { driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8 };
    driverService.Seed(seedDrivers);
}
#endregion