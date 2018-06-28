using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PaySlip.FilesConfig
{
    public class TaxRatesFileConfig : FileConfigInterface
    {
        public IEnumerable Foo(string taxRatesInfoFileContent) //GetFileStructure
        {
            var taxRates = JsonConvert.DeserializeObject<IEnumerable<TaxRatesInfo>>(taxRatesInfoFileContent);
            return  taxRates;
        }
    }
}