using System;
using System.Collections.Generic;
using System.Text;

namespace PSK_Lib.Configuration
{
    public class Configuration
    {
        public int TimeInterval { get; set; }
        public List<string> Processes { get; set; }

        public Configuration()
        {
            Processes = new List<string>();
        }

        public override string ToString()
        {
            var stringToReturn = $"Configuration:{Environment.NewLine}\tTime Interval: ";
            stringToReturn += TimeInterval;
            stringToReturn += $"{Environment.NewLine}\tProcesses:{Environment.NewLine}";

            if(Processes != null)
            {
                foreach (var item in Processes)
                {
                    stringToReturn += $"\t\t{item.ToString()}{Environment.NewLine}";
                }
            }
            else
            {
                stringToReturn = "No Items!" + Environment.NewLine;
            }
           
            return stringToReturn;
        }
    }
}
