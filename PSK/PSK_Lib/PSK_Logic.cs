using PSK_Lib.Configuration;
using PSK_Lib.Logger;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace PSK_Lib
{
    public class PSK_Logic
    {
        private ConfigurationHandler _handler;
        private ILogger _logger;
        private bool _configReaded;
        private bool _stepbystep;
        private bool _stop;
        public PSK_Logic(ConfigurationHandler handler, ILogger logger, bool stepbystep = false)
        {
            _handler = handler;
            _logger = logger;
            _stepbystep = stepbystep;
        }

        public void Start()
        {
            if (!_configReaded)
            {
                _logger.Info("Reading Configuration...");
                try
                {
                    _handler.ReadConfiguration();
                    _logger.Info(_handler.Configuration.ToString());
                    _configReaded = true;
                }
                catch (Exception ex)
                {

                    _logger.Fatal(ex.Message);
                    return;
                }
            }

            if (_stepbystep)
            {
                ProcessLogic();
            }
            else
            {
                _stop = false;
                while (!_stop)
                {
                    ProcessLogic();
                    _logger.Info($"TimeOut: {_handler.Configuration.TimeInterval}s");
                    Thread.Sleep(_handler.Configuration.TimeInterval * 1000);
                }
            }
           
        }

        public void Stop()
        {
            _stop = true;
        }

        private void ProcessLogic()
        {
            var allProcesses = Process.GetProcesses(Environment.MachineName).ToList();
            foreach (var item in _handler.Configuration.Processes)
            {
                _logger.Info($"Processing: {item} ...");
                var processes = allProcesses.Where(x => x.ProcessName == item).ToList();
                _logger.Info($"Found: {processes.Count} processes!");
                if(processes.Count > 0)
                {
                    foreach (var process in processes)
                    {
                        try
                        {
                            process.Kill();
                            _logger.Info($"{process.ProcessName} - {process.Id} - KILLED!");
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(ex.Message);
                        }
                       
                    }
                }
            }
        }



    }
}
