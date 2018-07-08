using System.Collections;
using System.Collections.Generic;

namespace PaySlip
{
    public interface FileReaderInterface
    {
        string load(string filePath);
//        IEnumerable parseBasicFormFile(string fileContent);
        IEnumerable<TaxRatesInfo> parseTaxRatesInfoFile(string fileContent);
    }
}