using System.Collections;
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

        public IEnumerable parseBasicFormFile(string formFileContent)
        {
            var form = JsonConvert.DeserializeObject<Dictionary<string, string>>(formFileContent);
            return form;
        }

        public IEnumerable<TaxRatesInfo> parseTaxRatesInfoFile(string taxRatesInfoFileContent)
        {
            var taxRates = JsonConvert.DeserializeObject<IEnumerable<TaxRatesInfo>>(taxRatesInfoFileContent);
            return  taxRates;
        }

    }
}