namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            InputProcessor processor = new (new Validation(), new ConsoleLogger());
            processor.Process();
        }
    }
}
