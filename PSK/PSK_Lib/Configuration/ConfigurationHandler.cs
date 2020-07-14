using PSK_Lib.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PSK_Lib.Configuration
{
    public class ConfigurationHandler
    {
        private IParser<Configuration> _parser;
        private string _filePath;
        public Configuration Configuration { get; set; }

        public ConfigurationHandler(string filePath)
        {
            _filePath = filePath;
            _parser = new JsonParser<Configuration>(filePath);
            Configuration = ReadConfiguration();
        }

        public Configuration ReadConfiguration()
        {
            try
            {
                return _parser.Read()[0];
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        public bool ProcessExists(string name)
        {
            if(Configuration != null)
            {
                return Configuration.Processes.Where(x => x == name).Count() > 0;
            }
            return false;
        }
    }
}
