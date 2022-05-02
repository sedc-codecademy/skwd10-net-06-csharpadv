using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCo.TaxiManager9000.Domain;
using TaxiCo.TaxiManager9000.Domain.Enums;
using TaxiCo.TaxiManager9000.Domain.Models;

namespace TaxiCo.TaxiManager9000.Services.Services.Interfaces
{
    public interface IUIService
    {
        List<MenuChoice> MenuItems { get; set; }
        User LogInMenu();
        void Welcome(User user);
        int MainMenu(Role role);
        int ChooseMenu<T>(List<T> items);
        int ChooseEntitiesMenu<T>(List<T> entities) where T : BaseEntity;
    }
}
