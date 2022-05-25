namespace TaxiManager9000.Services.Utilities
{
    public static class StringValidator
    {
        public static int ValidateNumber(string number, int range)
        {
            int num = 0;
            bool isNumber = int.TryParse(number, out num);
            if (!isNumber) return -1;
            if (num <= 0 || num > range) return -1;
            return num;
        }
        public static string? ValidateString(string str)
        {
            if (str.Length < 2) return null;
            int number;
            if (int.TryParse(str, out number)) return null;
            return str;
        }
        public static bool ValidateUsername(string username)
        {
            if (username.Length < 6) return false;
            return true;

        }
        public static bool ValidatePassword(string password)
        {
            if (password.Length < 6) return false;
            int num;
            bool isNum = false;
            foreach (char item in password)
            {
                isNum = int.TryParse(item.ToString(), out num);
            }
            if (!isNum) return false;
            return true;
        }
    }
}
