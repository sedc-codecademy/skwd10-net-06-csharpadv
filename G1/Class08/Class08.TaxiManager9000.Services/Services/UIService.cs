using Class08.TaxiManager9000.Domain.Entities;
using Class08.TaxiManager9000.Domain.Enums;
using Class08.TaxiManager9000.Services.Helpers;
using Class08.TaxiManager9000.Services.Interfaces;

namespace Class08.TaxiManager9000.Services.Services
{
    public class UIService : IUIService
    {
        private List<MenuOptions> _menuChoice;

        public List<MenuOptions> MenuChoice
        {
            get => _menuChoice;
            set
            {
                if (_menuChoice != null)
                {
                    _menuChoice.Clear();
                }
                _menuChoice = value;
            }
        }

        public User LogIn()
        {
            Console.WriteLine("Taxi Manager 9000");
            ConsoleHelper.Separator();
            Console.WriteLine("Log In:");
            string username = ConsoleHelper.GetInput("Username:");
            string password = ConsoleHelper.GetInput("Password:");

            return new User(username, password);
        }

        public int MainMenu(RoleEnum role)
        {
            List<MenuOptions> menuItems = new List<MenuOptions>() { MenuOptions.ChangePassword, MenuOptions.Exit };

            switch (role)
            {
                case RoleEnum.Administrator:
                    menuItems = menuItems.Prepend(MenuOptions.RemoveExistingUser).ToList();
                    menuItems = menuItems.Prepend(MenuOptions.AddNewUser).ToList();
                    break;
                case RoleEnum.Manager:
                    menuItems = menuItems.Prepend(MenuOptions.ListAllDrivers).ToList();
                    menuItems = menuItems.Prepend(MenuOptions.TaxiLicenseStatus).ToList();
                    menuItems = menuItems.Prepend(MenuOptions.DriverManager).ToList();
                    break;
                case RoleEnum.Maintenance:
                    menuItems = menuItems.Prepend(MenuOptions.ListAllCars).ToList();
                    menuItems = menuItems.Prepend(MenuOptions.LicensePlateStatus).ToList();
                    break;
            }

            MenuChoice = menuItems;
            return ChooseMenu(menuItems);
        }

        public int ChooseMenu<T>(List<T> items)
        {
            int selectedId = -1;
            try
            {
                Console.Clear();
                Console.WriteLine("Please insert the ID of the element you want to choose:");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {items[i]}");
                }
                selectedId = StringHelper.validateNumber(Console.ReadLine(), items.Count);

            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteLine(ex.Message, ConsoleColor.Red);
            }

            return selectedId;
        }

        public int ChooseEntityMenu<T>(List<T> entities) where T : BaseEntity
        {
            int selecteEntityId = -1;
            try
            {
                for (int i = 0; i < entities.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {entities[i].Print()}");
                }

                int selected = StringHelper.validateNumber(Console.ReadLine(), entities.Count);
                if (selected == -1)
                {
                    return selecteEntityId;
                }
                selecteEntityId = entities[selected-1].Id;
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteLine(ex.Message, ConsoleColor.Red);
            }

            return selecteEntityId;
;
        }
    }


    public enum MenuOptions
    {
        AddNewUser,
        RemoveExistingUser,
        ListAllDrivers,
        TaxiLicenseStatus,
        DriverManager,
        ListAllCars,
        LicensePlateStatus,
        ChangePassword,
        Exit
    }
}
