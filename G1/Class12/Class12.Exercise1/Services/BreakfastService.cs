namespace Class12.Exercise1.Services
{
    public class BreakfastService
    {
        public bool pourCoffee()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Coffee prtepared");
            return true;
        }

        public bool PreapreEggs(int numberOfEggs)
        {
            Console.WriteLine("Heat pan!");
            Thread.Sleep(2000);

            Console.WriteLine("Add butter in the pan");
            Console.WriteLine($"Crack {numberOfEggs} into the pan");
            Thread.Sleep(3000);

            Console.WriteLine("Serve eggs.");
            return true;
        }

        public bool PreapreMushrooms(int grams)
        {
            Console.WriteLine("Add butter in the pan");
            Console.WriteLine($"pour {grams} grams of mushrooms in the pan");
            Thread.Sleep(3000);

            Console.WriteLine("Serve mushrooms.");
            return true;
        }

        public bool PrepareToast(int numberOfSlices)
        {
            Console.WriteLine($"Add {numberOfSlices} slices of bread in the toaster");
            Thread.Sleep(3000);
            AddButterToSlice();
            AddJamToSlice();
            Console.WriteLine("Serve toast with butter and jam.");
            return true;
        }

        public bool AddButterToSlice()
        {
            Console.WriteLine("Add butter to slice");
            Thread.Sleep(1000);
            return true;
        }

        public bool AddJamToSlice()
        {
            Console.WriteLine("Add jam to slice");
            Thread.Sleep(1000);
            return true;
        }

        public bool pourJuice()
        {
            Console.WriteLine("pour orange juice");
            Thread.Sleep(1000);
            return true;
        }
    }
}
