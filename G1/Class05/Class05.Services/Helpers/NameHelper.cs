using Class05.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class05.Services.Helpers
{
    public static class NameHelper<T> where T : Animal
    {
        public static string GetName(T animal)
        {
            return $"Hello {animal.GetType().FullName}";
        }
    }
}
