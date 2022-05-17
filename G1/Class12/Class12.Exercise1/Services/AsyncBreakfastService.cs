namespace Class12.Exercise1.Services
{
    public class AsyncBreakfastService
    {
        public async Task<bool> pourCoffeeAsync()
        {
            await Task.Delay(2000);
            Console.WriteLine("Coffee prtepared");
            return true;
        }

        public async Task<bool> PreapreEggsAsync(int numberOfEggs)
        {
            Console.WriteLine("Heat pan!");
            await Task.Delay(2000);
            
            Console.WriteLine("Add butter in the pan");
            Console.WriteLine($"Crack {numberOfEggs} eggs into the pan");
            await Task.Delay(3000);

            Console.WriteLine("Serve eggs.");
            return true;
        }

        public async Task<bool> PreapreMushroomsAsync(int grams)
        {
            Console.WriteLine("Add butter in the pan");
            Console.WriteLine($"pour {grams} grams of mushrooms in the pan");
            await Task.Delay(3000);

            Console.WriteLine("Serve mushrooms.");
            return true;
        }

        public async Task<bool> PrepareToastAsync(int numberOfSlices)
        {
            Console.WriteLine($"Add {numberOfSlices} slices of bread in the toaster");
            await Task.Delay(3000);
            AddButterToSlices();
            AddJamToSlices();
            Console.WriteLine("Serve toast with butter and jam.");
            return true;
        }

        public bool AddButterToSlices()
        {
            Console.WriteLine("Add butter to slice");
            Thread.Sleep(1000);
            return true;
        }

        public bool AddJamToSlices()
        {
            Console.WriteLine("Add jam to slice");
            Thread.Sleep(1000);
            return true;
        }

        public async Task<bool> pourJuiceAsync()
        {
            Console.WriteLine("pour orange juice");
            await Task.Delay(1000);
            return true;
        }
    }
}
