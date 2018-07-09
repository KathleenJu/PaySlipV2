using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace PaySlip
{
    public class CSVFileReader : FileReaderInterface
    {
        public string load(string filePath)
        {
            using (StreamReader file = new StreamReader(filePath))
            {
                var csvContent = file.ReadToEnd();
                return csvContent;
            }
        }

        public IEnumerable parseBasicFormFile(string filePath)
        {
            var csvContent = load(filePath);
            var dict = new Dictionary<string, string>();
            string[] lines = Regex.Split(csvContent, "\r\n");

//            foreach (string line in lines)
//            {
//                string[] parts = line.Split(',');
//                dict.Add(line, line[1]);
//            }

            return dict;

        }
        public IEnumerable<TaxRatesInfo> parseTaxRatesInfoFile(string fileContent)
        {
            throw new System.NotImplementedException();
        }
    }
}