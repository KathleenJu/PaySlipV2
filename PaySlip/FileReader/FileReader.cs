using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace PaySlip.FileReader
{
    public abstract class FileReader
    {
        protected string FileContent { get; private set; }

        protected FileReader(string filePath)
        {
            Load(filePath);
        }
        
        public void Load(string filePath)
        {
            var fileBytes = File.ReadAllBytes(filePath);
            var str = Encoding.Default.GetString(fileBytes);
            FileContent = Regex.Replace(str, @"[^\w\.,–0-9 \r\n:{}\""\[\]]", "");
        }
        
        public abstract Dictionary<string, string> ParseBasicFormFile();
        public abstract IEnumerable<TaxRatesInfo> ParseTaxRatesInfoFile();
    }
}