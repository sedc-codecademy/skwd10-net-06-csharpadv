using System;

namespace AsyncGenericRepository
{
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main(string[] args)
        {
            /*
             * Async/Await Bonus Sample
             * ------------------------
             * This sample shows usage of Task and async/await keywords in a
             * form that you would usually encounter them in. Point of it is that
             * the work that is done in a repository is very often a bottleneck in
             * the system, and it makes sense to try to speed it up by parallelizing
             * its work. Data queries usually take measurable time, sometimes in the
             * rank of seconds, even minutes for big/badly written queries, so it only
             * makes sense for us to not block execution while waiting for query results.
             * Luckily tasks and async/await allow us to let C# manage this parallelization
             * for us while we focus on the code - no need to think about asynchronous
             * programming, most if not all frameworks that you would use to work with
             * any kind of data store will expose "async" versions of methods for querying/
             * writing data. This is the case with the static System.IO.File class as well.
             *
             * Check the FileSystemAsyncGenericRepository for more details. Also note the change
             * in Program.Main method - to allow using "await" here, we convert the Main
             * entry point method to be async and to return task rather than just returning
             * void. You can avoid this by using Wait() method for methods that return "void"
             * tasks and task.Result for the ones that return some result, but this can cause
             * issues in some cases - use async/await whenever possible!
             */

            // initialize repository
            IAsyncGenericRepository<Human> repository = new FileSystemAsyncGenericRepository<Human>();

            Human bob = new Human
            {
                Id = 1,
                FirstName =  "Bob",
                LastName = "Bobsky"
            };

            Human jill = new Human
            {
                Id = 2,
                FirstName = "Jill",
                LastName = "Valentine"
            };

            // insert two humans
            await repository.InsertAsync(bob);
            await repository.InsertAsync(jill);

            // read all humans stored
            var allEntities = await repository.GetAllAsync();

            // print humans
            foreach (Human human in allEntities)
            {
                Console.WriteLine($"Id: {human.Id}, FirstName: {human.FirstName}, LastName: {human.LastName}");
            }
        }
    }
}
