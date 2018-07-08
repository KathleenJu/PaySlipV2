using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PaySlip
{
    public class JSONFileReader : FileReaderInterface
    {
        public string load(string filePath)
        {
            using (StreamReader file = new StreamReader(filePath))
            {
                var jsonContent = file.ReadToEnd();
                return jsonContent;
            }
        }

        public IEnumerable<TaxRatesInfo> parseTaxRatesInfoFile()
        {
            throw new System.NotImplementedException();
        }
    }
}