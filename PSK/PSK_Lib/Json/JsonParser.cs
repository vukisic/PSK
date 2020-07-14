using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PSK_Lib.Json
{
    public class JsonParser<T> : IParser<T>
    {
        private string filePath;

        public JsonParser(string filePath)
        {
            this.filePath = filePath;
        }
        public List<T> Read()
        {
            try
            {
                if (!File.Exists(filePath))
                    throw new AccessViolationException($"File '{filePath}' doesn't exist!");
                string JSONstring = File.ReadAllText(filePath);
                List<T> list = JsonConvert.DeserializeObject<List<T>>(JSONstring);
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Write(List<T> items)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "");
                }

                string JSONout = JsonConvert.SerializeObject(items, Formatting.Indented);
                File.WriteAllText(filePath, JSONout);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
