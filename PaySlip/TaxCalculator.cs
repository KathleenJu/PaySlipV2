using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PaySlip
{
    public static class TaxCalculator
    {
        public static int CalculateGrossIncome(int annualSalary) // monthsOfPaymentPeriod
        {
            var monthsInAYear = 12;
            var grossIncome = annualSalary / monthsInAYear; // * monthsOfPaymentPeriod;

            return grossIncome;
        }

        public static double CalculateSuper(int grossIncome, int superRate)
        {
            var superRateInDecimal = (double) superRate / 100;
            var expectedSuper = grossIncome * superRateInDecimal;

            return Math.Floor(expectedSuper);
        }

        public static int CalculateNetIncome(int grossIncome, int incomeTax)
        {
            var netIncome = grossIncome - incomeTax;
            return netIncome;
        }

        private static TaxRates GetTaxRatesForAnnualSalary(int annualSalary, IEnumerable<TaxRates> taxRatesInfo)
        {
//            var taxRatesInfo = JsonConvert.DeserializeObject<IEnumerable<TaxRates>>(json);
            var taxRatesOfSalaryRange = taxRatesInfo.Where(taxRange => annualSalary >= taxRange.getMinimumSalary() && annualSalary <= taxRange.getMaximumSalary());

            var minimumSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.getMinimumSalary()).First();
            var maximumSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.getMaximumSalary()).First();
            var nonTaxableSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.getNonTaxableSalary()).First();
            var taxPerDollar = taxRatesOfSalaryRange.Select(taxRange => taxRange.getTaxPerDollar()).First();
            var extraTax = taxRatesOfSalaryRange.Select(taxRange => taxRange.getExtraTax()).First();

            return new TaxRates(minimumSalary, maximumSalary, nonTaxableSalary, taxPerDollar, extraTax);
        }

        public static double CalculateIncomeTax(int annualSalary, double nonTaxableSalary, double taxPerDollar,
            double extraTax)
        {
            var taxableSalary = annualSalary - nonTaxableSalary;
            var taxOnSalary = taxableSalary * taxPerDollar;
            var incomeTax = Math.Round((taxOnSalary + extraTax) / 12);

            return incomeTax;
        }
    }
}