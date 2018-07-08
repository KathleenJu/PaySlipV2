using System.Collections.Generic;
using System.IO;

namespace PaySlip
{
    public class CSVFileREader : FileReaderInterface
    {
        public string load(string filePath)
        {
            using (StreamReader file = new StreamReader(filePath))
            {
                var csvContent = file.ReadToEnd();
                return csvContent;
            }
        }

        public IEnumerable<TaxRatesInfo> parseTaxRatesInfoFile(string fileContent)
        {
            throw new System.NotImplementedException();
        }
    }
}