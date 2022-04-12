using Class03.Exercise01.Entities;

namespace Class03.Exercise01.Services
{
    public class PetStoreService<T> where T : Pet
    {
        public List<T> Pets = new List<T>();

        public PetStoreService()
        {
            Pets = new List<T>();
        }

        public void PrintPets()
        {
            foreach (T pet in Pets)
            {
                Console.WriteLine(pet.PetInfo());
            }
        }

        public void Add(T pet)
        {
            try
            {
                Pets.Add(pet);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ocured adding per");
            }
            Console.WriteLine($"{pet.GetType().FullName} sucessfully added.");
        }

        public void BuyPet(int id)
        {
            try
            {
                T pet = Pets.Single(x => x.Id == id);
                Pets.Remove(pet);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Pet with ID {id} does not exist");
            }
        }
    }
}
