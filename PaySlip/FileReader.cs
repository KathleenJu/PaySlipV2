using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PaySlip
{
    public class FileReader
    {
        public static object ReadFromJSONFile(string filePath)
        {
            using (StreamReader file = new StreamReader(filePath))
            {
                var json = file.ReadToEnd();
                var taxRatesInfo = JsonConvert.DeserializeObject(json);
                return taxRatesInfo;
            }
        }
    }
}