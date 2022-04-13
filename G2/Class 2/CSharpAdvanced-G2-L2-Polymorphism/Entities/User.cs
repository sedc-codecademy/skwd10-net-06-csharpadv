using CSharpAdvanced_G2_L2_Polymorphism.Helpers;

namespace CSharpAdvanced_G2_L2_Polymorphism.Entities
{
    public class User
    {
        public string Name { get; set; }

        public string MotherTongue { get; set; }

        public User(string name)
        {
            Name = name;
            MotherTongue = LanguageHelper.ENGLISH;
        }

        public User(string name, string language)
        {
            Name = name;
            MotherTongue = language;
        }

        public void SayHello()
        {
            if (MotherTongue == LanguageHelper.ENGLISH)
            {
                Console.WriteLine("Hello");
            }
            else if (MotherTongue == LanguageHelper.MACEDONIAN)
            {
                Console.WriteLine("Zdravo");
            }
            else if (MotherTongue == LanguageHelper.GERMAN)
            {
                Console.WriteLine("Guten Tag");
            }
        }

        public void SayHello(string language)
        {
            if (language == LanguageHelper.ENGLISH)
            {
                Console.WriteLine("Hello");
            }
            else if (language == LanguageHelper.MACEDONIAN)
            {
                Console.WriteLine("Zdravo");
            }
            else if (language == LanguageHelper.GERMAN)
            {
                Console.WriteLine("Guten Tag");
            }
        }
    }
}
