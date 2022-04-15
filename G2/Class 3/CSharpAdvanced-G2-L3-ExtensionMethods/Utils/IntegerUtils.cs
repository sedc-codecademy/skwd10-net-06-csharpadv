namespace CSharpAdvanced_G2_L3_ExtensionMethods.Utils
{
    public static class IntegerUtils
    {
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }

        public static bool IsBiggerThan(this int numberOne, int numberTwo)
        {
            return numberOne > numberTwo;
        }
    }
}
