using System;
using System.IO;
using PaySlip;
using Xunit;

namespace PaySlipTest
{
    public class PaySlipShould
    {
        private readonly string TaxRatesInfoFilePath = "/Users/kathleen.jumamoy/Projects/Katas/PaySlipV2/PaySlip/files/taxRatesInfo.json";
        [Theory]
        [InlineData(60050, 12, 5004)]
        [InlineData(70000, 12, 5833)]
        [InlineData(80000, 12, 6666)]
        public void ReturnGrossIncome(int annualSalary, int monthsInAYear, int actualGrossIncome)
        {
//            var paySlip = new PaySlip.PaySlip(annualSalary, TaxRatesInfoFilePath);
//            var expectedGrossIncome = PaySlip.CalculateGrossIncome();

//            Assert.Equal(expectedGrossIncome, actualGrossIncome);
        }

        [Theory]
        [InlineData(60050, 5004, 9, 450)]
        [InlineData(70000, 5833, 9, 524)]
        [InlineData(80000, 6666, 9, 599)]
        public void ReturnSuper(int annualSalary, int grossIncome, int superRate, int actualSuper)
        {
            var TaxCalculator = new TaxCalculator(annualSalary);
            var expectedSuper = TaxCalculator.CalculateSuper(grossIncome, superRate);

            Assert.Equal(expectedSuper, actualSuper);
        }

        [Theory]
        [InlineData(60050, 5004, 922, 4082)]
        [InlineData(70000, 5833, 963, 4870)]
        [InlineData(80000, 6666, 1050, 5616)]
        public void ReturnNetIncome(int annualSalary, int grossIncome, int incomeTax, int actualNetIncome)
        {
            var TaxCalculator = new TaxCalculator(annualSalary);
            var expectedSuper = TaxCalculator.CalculateNetIncome(grossIncome, incomeTax);

            Assert.Equal(expectedSuper, actualNetIncome);
        }

        [Theory]
        [InlineData(15000, 0, 0, 0, 0)]
        [InlineData(28000, 18200, 0.19, 0, 155)]
        [InlineData(60050, 37000, 0.325, 3572, 922)]
        [InlineData(95000, 87000, 0.37, 19822, 1898)]
        [InlineData(200000, 180000, 0.45, 54232, 5269)]
        public void ReturnIncomeTax(int annualSalary, int nonTaxableSalary, double taxPerDollar, int extraTax,
            int actualIncomeTax)
        {
            var TaxCalculator = new TaxCalculator(annualSalary);
            var taxRatesFile = "/Users/kathleen.jumamoy/Projects/Katas/PaySlipV2/PaySlip/files/taxRateInfo.json";
            var expectedIncomeTax = TaxCalculator.CalculateIncomeTax();

            Assert.Equal(expectedIncomeTax, actualIncomeTax);
        }
    }
}