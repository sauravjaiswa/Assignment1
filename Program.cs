using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===================================================================================");
            Console.WriteLine("===========================Welcome to Horoscope Console============================");
            InputProcessor processor = new (new Validation(), new ConsoleLogger());
            processor.Process();
            Console.WriteLine("=================================End of Application================================");
            Console.WriteLine("===================================================================================");
        }
    }
}
