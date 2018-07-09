using System.Collections.Generic;
using System.Threading;
using PaySlip;
using PaySlip.FileReader;
using Xunit;

namespace PaySlipTest
{
    public class FileReaderShould
    {
        private readonly IEnumerable<Dictionary<string, string>> foo = new[]
        {
            new Dictionary<string, string>
            {
                {"firstName", "David"},
                {"lastName", "Rudd"},
                {"annualSalary", "60050"},
                {"superRate", "9"},
                {"paymentStartDate", "01 March - 31 March"} 
            }
        };
        
        [Theory]
        [InlineData("/Users/kathleen.jumamoy/Projects/Katas/PaySlipV2/PaySlip/files/sample_input.csv",
            "first name,last name,annual salary,super rate (%),payment start date\r\n" +
            "David,Rudd,60050,9%,01 March – 31 March\r\n" +
            "Ryan,Chen,120000,10%,01 March – 31 March")]
        public void ReturnCSVFileContent(string filePath, string actualCSVOutput)
        {
            var csv = new CsvFileReader();
            var expectedCSVOutput = csv.Load(filePath);
            Assert.Equal(expectedCSVOutput, actualCSVOutput);
        }
        
        [Fact]
        public void ReturnCSVFileInTheRightFormat()
        {
            var csv = new CsvFileReader();
            var filePath = "/Users/kathleen.jumamoy/Projects/Katas/PaySlipV2/PaySlip/files/sample_input.csv";
            var expectedCSVOutput = csv.ParseBasicFormFile(filePath);
            Assert.Equal(expectedCSVOutput, foo);
        }
    }
}