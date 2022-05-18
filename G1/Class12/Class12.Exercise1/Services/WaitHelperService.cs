namespace Class12.Exercise1.Services
{
    public static class WaitHelperService
    {
        public static async Task Prepare(int delay)
        {
            int delayTime = delay;
            await Task.Run(() =>
            {
                Thread.Sleep(delayTime);
                Console.WriteLine(delayTime);
            });
            Console.WriteLine("testing");
        }
    }
}
