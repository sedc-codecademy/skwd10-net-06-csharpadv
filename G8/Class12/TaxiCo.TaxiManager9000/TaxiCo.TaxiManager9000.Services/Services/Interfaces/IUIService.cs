using TaxiManager9000.Domain;

namespace TaxiManager9000.Services
{
    public interface IUIService
    {
        List<MenuChoice> MenuItems { get; set; }
        User LogInMenu();
        void Welcome(User user);
        int MainMenu(Role role);
        int ChooseMenu<T>(List<T> items);
        int ChooseEntiiesMenu<T>(List<T> entities) where T : BaseEntity;

    }
}
