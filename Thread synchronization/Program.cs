namespace Testing
{
    public class Program
    {
        public static Mutex semaphore = new();
        public static object locker = new();
        public static void Print()
        {
            while (true)
            {
                lock (locker)
                {
                    Console.Write($"{Thread.CurrentThread.Name}");
                    if(Thread.CurrentThread.Name == "3")
                        Console.WriteLine();
                    Thread.Sleep(1000);
                }
            }
        }
        static void Main()
        {

            for (int i = 1; i < 4; i++)
            {
                Thread thread = new(Print)
                {
                    Name= i.ToString(),
                };
                thread.Start();
            }

        }
    }
}