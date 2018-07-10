using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PaySlip.FileReader
{
    public class JsonFileReader : IFileReaderInterface 
    {
        public string Load(string filePath)
        {
            using (StreamReader file = new StreamReader(filePath))
            {
                var jsonContent = file.ReadToEnd();
                return jsonContent;
            }
        }

        public IEnumerable ParseBasicFormFile(string formFilePath)
        {
            string formFileContent = Load(formFilePath);
            var form = JsonConvert.DeserializeObject<Dictionary<string, string>>(formFileContent);
            return form;
        }

        public IEnumerable<TaxRatesInfo> ParseTaxRatesInfoFile(string taxRatesFilePath)
        {
            var taxRatesInfoFileContent = Load(taxRatesFilePath);
            var taxRates = JsonConvert.DeserializeObject<IEnumerable<TaxRatesInfo>>(taxRatesInfoFileContent);
            return  taxRates;
        }

    }
}