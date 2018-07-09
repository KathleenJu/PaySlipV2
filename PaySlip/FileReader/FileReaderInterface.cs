using System.Collections;
using System.Collections.Generic;

namespace PaySlip
{
    public interface FileReaderInterface
    {
        string load(string filePath);
        IEnumerable parseBasicFormFile(string filePath);
        IEnumerable<TaxRatesInfo> parseTaxRatesInfoFile(string fileContent);
    }
}