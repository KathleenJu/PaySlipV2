using System.Collections;
using System.Collections.Generic;

namespace PaySlip.FileReader
{
    public interface IFileReaderInterface
    {
        string Load(string filePath);
        IEnumerable ParseBasicFormFile(string filePath);
        IEnumerable<TaxRatesInfo> ParseTaxRatesInfoFile(string fileContent);
    }
}