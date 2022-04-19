namespace System
{
    public static class StringHelper
    {
        public static int requestCount { get; set; }
        
        static StringHelper()
        {
            requestCount = 0;
        }

        public static string Quotate(string text)
        {
            requestCount++;
            return $"\"{text}\"";
        }

        public static string Capitalize(this string text, string text2)
        {
            string result = string.Empty;
            var words = text.Split(" ");
            foreach (var word in words)
            {
                result += " " + word[0].ToString().ToUpper() + word.Substring(1, word.Length - 1);
            }

            return result + text2;
        }
    }
}
