using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===================================================================================");
            Console.WriteLine("===========================Welcome to Horoscope Console============================");
            InputProcessor processor = new(new ValidationChoice(), new ValidationDate(), new ConsoleLogger(), new FileLogger(@"C:\Users\Dell-pc\Desktop\log.txt"));
            processor.Process();
            Console.WriteLine("=================================End of Application================================");
            Console.WriteLine("===================================================================================");
        }
    }
}
