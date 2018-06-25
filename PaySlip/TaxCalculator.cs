using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public int CalculateNetIncome(int grossIncome, int incomeTax)
        {
            var netIncome = grossIncome - incomeTax;
            return netIncome;
        }

        public int CalculateIncomeTax(int annualSalary, int nonTaxableSalary, double taxPerDollar, int extraTax)
        {
            var taxableSalary = annualSalary - nonTaxableSalary;
            double incomeTax = taxableSalary * taxPerDollar;
            var totalIncomeTax = Math.Round((incomeTax + extraTax) / 12);

            return (int) totalIncomeTax;
        }

        public double GetTaxableIncome(int annualSalary)
        {
            using (StreamReader file =
                new StreamReader("/Users/kathleen.jumamoy/Projects/Katas/PaySlipV2/PaySlip/files/taxRateInfo.json"))
            {
                var json = file.ReadToEnd();
                var taxRanges = JsonConvert.DeserializeObject<IEnumerable<TaxRateInfo>>(json);
                var taxRangeInfo = taxRanges.Where(taxRange => annualSalary >= taxRange.getMinimumSalary() && annualSalary <= taxRange.getMaximumSalary());
                var nonTaxableSalary = taxRangeInfo.Select(taxRange => taxRange.getNonTaxableSalary()).First();
                return nonTaxableSalary;
            }
        }
    }
}