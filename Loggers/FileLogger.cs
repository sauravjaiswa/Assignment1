using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Assignment1
{
    public class FileLogger : ILogger
    {
        private readonly string _path;
        private readonly Queue<string> _logs;

        public FileLogger(string path)
        {
            _path = path;
            _logs = new Queue<string>();
        }
        public void LogError(string message)
        {
            Log(message, "ERROR", DateTime.Now.ToString());
        }

        public void LogInfo(string message)
        {
            Log(message, "SUCCESS", DateTime.Now.ToString());
        }

        private async Task Log(string message, string messageType, string timestamp)
        {
            _logs.Enqueue($"{messageType} ({timestamp}): {message}");

            using (var streamWriter = new StreamWriter(_path, true))
            {
                await streamWriter.WriteLineAsync(_logs.Dequeue());
            }
        }
    }
}
