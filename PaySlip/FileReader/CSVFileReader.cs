using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace PaySlip.FileReader
{
    public class CsvFileReader : IFileReaderInterface
    {
        public string Load(string filePath)
        {
            using (StreamReader file = new StreamReader(filePath))
            {
                var csvContent = file.ReadToEnd();
                return csvContent;
            }
        }

        public IEnumerable ParseBasicFormFile(string filePath)
        {
            var csvContent = Load(filePath);
//            var dict = new Dictionary<string, string>();
//            string[] lines = Regex.Split(csvContent, "\r\n");

//            foreach (string line in lines)
//            {
//                string[] parts = line.Split(',');
//                dict.Add(line, line[1]);
//            }

//            return dict;
            throw new System.NotImplementedException();

        }
        public IEnumerable<TaxRatesInfo> ParseTaxRatesInfoFile(string fileContent)
        {
            throw new System.NotImplementedException();
        }
    }
}