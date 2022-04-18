using Class05.Domain.Entities.Interfaces;
using Class05.Services.Helpers;

namespace Class05.Services
{
    public class DogService
    {


        public string GroomDog(IDog dog)
        {

            string text = $"The dog {StringHelper.Quotate(dog.ToString())} is in grooming!";
            return text.Capitalize("");
        }
    }
}