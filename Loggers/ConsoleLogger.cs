using System;
using System.IO;

namespace Assignment1
{
    public class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }
        public void LogError(string message)
        {
            Log(message, "ERROR", DateTime.Now.ToString());
        }

        public void LogInfo(string message)
        {
            Log(message, "SUCCESS", DateTime.Now.ToString());
        }

        private void Log(string message, string messageType, string timestamp)
        {
            using (var streamWriter = new StreamWriter(_path, true))
            {
                streamWriter.WriteLine($"{messageType} ({timestamp}): {message}");
            }
        }
    }
    public class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
