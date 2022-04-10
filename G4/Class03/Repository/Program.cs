namespace Repository // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepository = new InMemoryUserRepository();

            var user1 = new User("John", "Doe");
            var user2 = new User("Mary", "Jane");
            var user3 = new User("Johnny", "Depp");

            userRepository.Add(user1);
            userRepository.Add(user2);
            userRepository.Add(user3);

            // should print 3 users
            InMemoryUserRepository.PrintAll();

            IUserRepository userRepository2 = new InMemoryUserRepository();

            var user4 = new User("Brad", "Pitt");
            userRepository2.Add(user4);

            // should print 4 users even though we added a user
            // to a new instance to InMemoryRepository. This is
            // because we are using a static instance of List<User>,
            // and this means that it will be instantiated only once
            // and shared among instances of InMemoryUserRepository
            InMemoryUserRepository.PrintAll();

            IUserRepository brokenUserRepostory = new BrokenUserRepository();

            // this will fail, because none of BrokenUserRepository
            // methods have proper implementation.
            brokenUserRepostory.Add(user4);

            // Exercise: try to use the rest of the IUserRepository/InMemoryUserRepository
            // instance methods to simulate realistic user management. For example,
            // first you would use the Add method to add a user so the database is not empty.
            // Next would be updating an existing user - you would use GetById to get a user
            // object from the database, try to mutate some of its properties (FirstName, LastName)
            // and then invoke the Update method to "store" the updated user. Finally,
            // when the user no longer uses his/hers account, you need to find the ID of the user
            // you want to delete, and then invoke the Delete method.
        }
    }
}