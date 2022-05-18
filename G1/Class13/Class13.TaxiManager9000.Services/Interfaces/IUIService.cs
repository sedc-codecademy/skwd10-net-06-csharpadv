using Class13.TaxiManager9000.Domain.Entities;
using Class13.TaxiManager9000.Domain.Enums;
using Class13.TaxiManager9000.Services.Services;

namespace Class13.TaxiManager9000.Services.Interfaces
{
    public interface IUIService
    {
        List<MenuOptions> MenuChoice { get; set; }
        User LogIn();

        int MainMenu(Role role);

        int ChooseMenu<T>(List<T> item);

        int ChooseEntityMenu<T>(List<T>? entities) where T : BaseEntity;
    }
}
