namespace CSharpAdvanced_G2_L3_ExtensionMethods.Utils
{
    public static class DecimalUtils
    {
        public static decimal RoundNumber(this decimal number)
        {
            return Math.Round(number, 2);
        }

        public static decimal RoundCurrency(this decimal currency)
        {
            int decimalValues = (int)(currency * 100 / 10000);

            if (decimalValues < 25)
            {
                return 25;
            }

            if (decimalValues > 25 && decimalValues < 50)
            {
                return 50;
            }

            return 100;
        }
    }
}
