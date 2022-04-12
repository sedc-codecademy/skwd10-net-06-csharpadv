
namespace CSharp_Advanced_G3_L3_Generics.Enteties
{
    public class NonGenericHelper
    {
        public void GoThroughList(List<string> strings)
        {
            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
        }

        public void GetInfoForList(List<string> strings)
        {
            Console.WriteLine($"The list has {strings.Count} and the elemnts are of type {strings[0].GetType()}");
        }

        public void GoThroughList(List<int> intList)
        {
            foreach (int s in intList)
            {
                Console.WriteLine(s);
            }
        }

        public void GetInfoForList(List<int> intList)
        {
            Console.WriteLine($"The list has {intList.Count} and the elemnts are of type {intList[0].GetType()}");
        }
    }
}
