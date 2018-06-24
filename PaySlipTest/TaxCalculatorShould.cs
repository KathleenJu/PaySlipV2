using System;
using PaySlip;
using Xunit;

namespace PaySlipTest
{
    public class TaxCalculatorShould
    {
        [Theory]
        [InlineData(60050, 12, 5004)]
        [InlineData(70000, 12, 5833)]
        [InlineData(80000, 12, 6666)]
        public void ReturnGrossIncome(int annualSalary, int monthsInAYear, int actualGrossIncome)
        {
            var taxCalculator = new TaxCalculator();
            var expectedGrossIncome = taxCalculator.CalculateGrossIncome(annualSalary);
            
            Assert.Equal(expectedGrossIncome, actualGrossIncome);
        }

        [Theory]
        [InlineData(5004, 9, 450)]
        [InlineData(5833, 9, 524)]
        [InlineData(6666, 9, 599)]
        public void ReturnSuper(int grossIncome, int superRate, int actualSuper)
        {
            var taxCalculator = new TaxCalculator();
            var expectedSuper = taxCalculator.CalculateSuper(grossIncome, superRate);

            Assert.Equal(expectedSuper, actualSuper);
        }

    }
}