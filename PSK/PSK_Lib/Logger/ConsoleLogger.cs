using System;
using System.Collections.Generic;
using System.Text;

namespace PSK_Lib.Logger
{
    public class ConsoleLogger : ILogger
    {
        private string format = "[{0}] - ({1}) : {2}";

        public ConsoleLogger() { }

        public void Debug(string message)
        {
            var log = String.Format(format, LogLevel.DEBUG, DateTime.Now.ToString(), message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(log);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Error(string message)
        {
            var log = String.Format(format, LogLevel.ERROR, DateTime.Now.ToString(), message);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(log);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Fatal(string message)
        {
            var log = String.Format(format, LogLevel.FATAL, DateTime.Now.ToString(), message);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(log);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Info(string message)
        {
            var log = String.Format(format, LogLevel.INFO, DateTime.Now.ToString(), message);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(log);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Warning(string message)
        {
            var log = String.Format(format, LogLevel.WARNING, DateTime.Now.ToString(), message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(log);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
