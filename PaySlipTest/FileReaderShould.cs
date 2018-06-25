using PaySlip;
using Xunit;

namespace PaySlipTest
{
    public class FileReaderShould
    {
        [Theory]
        [InlineData("./files/taxRateInfo.json")]
        public void ReadJSONFiles(string filePath)
        {
            var foo = FileReader.ReadFromJSONFile(filePath);
            
        }
    }
}