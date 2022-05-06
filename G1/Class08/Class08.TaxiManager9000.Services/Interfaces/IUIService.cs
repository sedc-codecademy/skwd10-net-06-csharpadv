using Class08.TaxiManager9000.Domain.Entities;
using Class08.TaxiManager9000.Domain.Enums;
using Class08.TaxiManager9000.Services.Services;

namespace Class08.TaxiManager9000.Services.Interfaces
{
    public interface IUIService
    {
        List<MenuOptions> MenuChoice { get; set; }
        User LogIn();

        int MainMenu(RoleEnum role);

        int ChooseMenu<T>(List<T> item);

        int ChooseEntityMenu<T>(List<T> entities) where T : BaseEntity;
    }
}
