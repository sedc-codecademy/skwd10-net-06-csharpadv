using Newtonsoft.Json;

namespace CSharpAdvanced_G2_L10_FileDb.Entities
{
    public class Car : BaseEntity
    {
        public string Name { get; set; }    

        public string Model { get; set; }

        [JsonConstructor]
        public Car(int id, string name, string model) : base(id)
        {
            Name = name;
            Model = model;
        }

        public Car(string name, string model) : base()
        {
            Name = name;
            Model = model;
        }
    }
}
