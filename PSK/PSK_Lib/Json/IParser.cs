using System;
using System.Collections.Generic;
using System.Text;

namespace PSK_Lib.Json
{
    public interface IParser<T>
    {
        List<T> Read();
        void Write(List<T> items);

    }
}
