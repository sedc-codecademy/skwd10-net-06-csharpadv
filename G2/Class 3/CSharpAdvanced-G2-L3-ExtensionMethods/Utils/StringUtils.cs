namespace CSharpAdvanced_G2_L3_ExtensionMethods.Utils
{
    public static class StringUtils
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }
    }
}
