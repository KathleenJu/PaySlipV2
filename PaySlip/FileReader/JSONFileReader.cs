using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PaySlip.FileReader
{
    public class JsonFileReader : FileReader
    {
        public JsonFileReader(string filePath) : base(filePath)
        {
        }

        public override Dictionary<string,string> ParseBasicFormFile()
        {
            var form = JsonConvert.DeserializeObject<Dictionary<string, string>>(FileContent);
            return form;
        }

        public override IEnumerable<TaxRatesInfo> ParseTaxRatesInfoFile()
        {
            var taxRates = JsonConvert.DeserializeObject<IEnumerable<TaxRatesInfo>>(FileContent);
            return  taxRates;
        }

    }
}