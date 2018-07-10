using System;
using System.Collections.Generic;
using System.IO;
using PaySlip;
using PaySlip.FileReader;
using Xunit;
using Moq;

namespace PaySlipTest
{
    public class PaySlipShould
    {
        private readonly string TaxRatesInfoFilePath = "/Users/kathleen.jumamoy/Projects/Katas/PaySlipV2/PaySlip/files/taxRatesInfo.json";
        [Theory]
        [InlineData(60050, 5004)]
        [InlineData(70000, 5833)]
        [InlineData(80000, 6666)]
        public void ReturnGrossIncome(int annualSalary, int actualGrossIncome)
        {
            var mockOfEmployee = new Mock<Employee>(It.IsAny<string>(), It.IsAny<string>(), new PaymentDetails(annualSalary, It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()) );
            var paySlip = new PaySlip.PaySlip(mockOfEmployee.Object, It.IsAny<IEnumerable<TaxRatesInfo>>() );
            var expectedGrossIncome = paySlip.GetGrossIncome();

            Assert.Equal(expectedGrossIncome, actualGrossIncome);
        }

        [Theory]
        [InlineData(60050, 5004, 9, 450)]
        [InlineData(70000, 5833, 9, 524)]
        [InlineData(80000, 6666, 9, 599)]
        public void ReturnSuper(int annualSalary, int grossIncome, int superRate, int actualSuper)
        {
            var mockOfEmployee = new Mock<Employee>(It.IsAny<string>(), It.IsAny<string>(), new PaymentDetails( annualSalary, superRate, It.IsAny<string>(), It.IsAny<string>()) );
            var paySlip = new PaySlip.PaySlip(mockOfEmployee.Object, It.IsAny<IEnumerable<TaxRatesInfo>>() );
            var expectedSuper = paySlip.GetSuper();

            Assert.Equal(expectedSuper, actualSuper);
        }

        [Theory]
        [InlineData(60050, 5004, 922, 4082)]
        [InlineData(70000, 5833, 1191, 4642)]
        [InlineData(80000, 6666, 1462, 5204)]
        public void ReturnNetIncome(int annualSalary, int grossIncome, int incomeTax, int actualNetIncome)
        {
            
            var taxRatesFilePath = "/Users/kathleen.jumamoy/Projects/Katas/PaySlipV2/PaySlip/files/taxRatesInfo.json";
            var mockOfEmployee = new Mock<Employee>(It.IsAny<string>(), It.IsAny<string>(), new PaymentDetails( annualSalary, It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()) );
            var taxRates = new JsonFileReader().ParseTaxRatesInfoFile(taxRatesFilePath);
            var paySlip = new PaySlip.PaySlip(mockOfEmployee.Object, taxRates);
            var expectedNetIncome = paySlip.GetNetIncome();

            Assert.Equal(expectedNetIncome, actualNetIncome);
        }

        [Theory]
        [InlineData(15000, 0)]
        [InlineData(28000, 155)]
        [InlineData(60050, 922)]
        [InlineData(95000, 1898)]
        [InlineData(200000, 5269)]
        public void ReturnIncomeTax(int annualSalary,
            int actualIncomeTax)
        {
            var taxRatesFilePath = "/Users/kathleen.jumamoy/Projects/Katas/PaySlipV2/PaySlip/files/taxRatesInfo.json";
            var mockOfEmployee = new Mock<Employee>(It.IsAny<string>(), It.IsAny<string>(), new PaymentDetails( annualSalary, It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()) );
            var taxRates = new JsonFileReader().ParseTaxRatesInfoFile(taxRatesFilePath);
            var paySlip = new PaySlip.PaySlip(mockOfEmployee.Object, taxRates);
            var expectedIncomeTax = paySlip.GetIncomeTax();

            Assert.Equal(expectedIncomeTax, actualIncomeTax);
        }
    }
}