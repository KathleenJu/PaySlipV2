using System;

namespace PaySlip
{
    public class TaxCalculator
    {
        public int CalculateGrossIncome(int annualSalary) // monthsOfPaymentPeriod
        {
            var monthsInAYear = 12;
            var grossIncome = annualSalary / monthsInAYear; // * monthsOfPaymentPeriod;

            return grossIncome;
        }

        public double CalculateSuper(int grossIncome, int superRate)
        {
            var superRateInDecimal = (double) superRate / 100;
            var expectedSuper = grossIncome * superRateInDecimal;

            return Math.Floor(expectedSuper);
        }
    }
}