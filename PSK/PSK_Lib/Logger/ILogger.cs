using System;
using System.Collections.Generic;
using System.Text;

namespace PSK_Lib.Logger
{
    public interface ILogger
    {
        void Info(string message);
        void Debug(string message);
        void Fatal(string message);
        void Error(string message);
        void Warning(string message);
    }
}
