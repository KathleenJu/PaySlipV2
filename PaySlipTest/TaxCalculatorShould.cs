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

        [Theory]
        [InlineData(5004, 922, 4082)]
        [InlineData(5833, 963, 4870)]
        [InlineData(6666, 1050, 5616)]
        public void ReturnNetIncome(int grossIncome, int incomeTax, int actualNetIncome)
        {
            var taxCalculator = new TaxCalculator();
            var expectedSuper = taxCalculator.CalculateNetIncome(grossIncome, incomeTax);

            Assert.Equal(expectedSuper, actualNetIncome);
        }

        [Theory]
        [InlineData(60050, 37000, 0.325, 3572, 922)]
        public void ReturnIncomeTax(int annualSalary, int nonTaxableSalary, double taxPerDollar, int extraTax,
            int actualIncomeTax)
        {
            var taxCalculator = new TaxCalculator();
            var expectedIncomeTax = taxCalculator.CalculateIncomeTax(annualSalary, nonTaxableSalary, taxPerDollar, extraTax);
            
            Assert.Equal(expectedIncomeTax, actualIncomeTax);
        }
        
        [Theory]
        [InlineData(60050, 37000)]
        [InlineData(15000, 0)]
        [InlineData(20000, 18200)]
        [InlineData(37001, 37000)]
        public void ReturnTaxableSalary(int annualSalary, 
            double actualIncomeTax)
        {
            var taxCalculator = new TaxCalculator();
            var expectedIncomeTax = taxCalculator.GetTaxableIncome(annualSalary);
            
            Assert.Equal(expectedIncomeTax, actualIncomeTax);
        }
    }
}