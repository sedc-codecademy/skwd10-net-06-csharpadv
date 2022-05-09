namespace Class09.Example1.Services
{
    public class InvalidLoginException : Exception
    {
        private LoggerService _logger = new LoggerService();

        public string Username { get; set; }

        public InvalidLoginException(string username) : base("User entered wrong username or password")
        {
            Username = username;
            _logger.LogError();
        }
    }

    public class InvalidUserPropertyException : Exception
    {
        private LoggerService _logger = new LoggerService();

        public string BrokenProperty { get; set; }
        public string PropertyValue { get; set; }
        public string Username { get; set; }

        public InvalidUserPropertyException() : base("Unknown user had some invalid property")
        {
            _logger.LogError();
        }

        public InvalidUserPropertyException(string property, string value, string username) : base($"User {username} tryed to insert invalid property {property}")
        {
            BrokenProperty = property;
            PropertyValue = value;
            Username = username;
            _logger.LogError();
        }
    }
}
