using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.IO;
 using System.Linq;
 using System.Text;
using System.Text.RegularExpressions;

namespace PaySlip.FileReader
 {
     public class CsvFileReader : FileReader
     {
         public CsvFileReader(string filePath) : base(filePath)
         {
         }
 
         public override Dictionary<string, string> ParseBasicFormFile()
         {
             throw new NotImplementedException();
 
         }
         public override IEnumerable<TaxRatesInfo> ParseTaxRatesInfoFile()
         {
             throw new NotImplementedException();
         }
     }
 }