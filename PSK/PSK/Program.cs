using PSK_Lib;
using PSK_Lib.Configuration;
using PSK_Lib.Json;
using PSK_Lib.Logger;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PSK
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationHandler handler = new ConfigurationHandler("../../../blacklist.json");
            ILogger logger = new ConsoleLogger();
            PSK_Logic l = new PSK_Logic(handler, logger);
            l.Start();

            Console.WriteLine("All Done!");
            Console.ReadLine();
        }
    }
}
