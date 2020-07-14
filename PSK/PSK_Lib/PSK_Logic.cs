using PSK_Lib.Configuration;
using PSK_Lib.Logger;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSK_Lib
{
    public class PSK_Logic
    {
        private ConfigurationHandler _handler;
        private ILogger _logger;

        public PSK_Logic(ConfigurationHandler handler, ILogger logger)
        {
            _handler = handler;
            _logger = logger;
        }

        public void Start()
        {
            _logger.Info("Reading Configuration...");
            try
            {
                _handler.ReadConfiguration();
                _logger.Info(_handler.Configuration.ToString());
            }
            catch (Exception ex)
            {

                _logger.Fatal(ex.Message);
                return;
            }
        }
    }
}
