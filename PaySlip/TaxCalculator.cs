using System;
using System.Collections;
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
        
        public static double CalculateIncomeTax(int annualSalary, string taxRatesInfoFilePath)
        {
            var taxRatesInfo = GetTaxRatesForAnnualSalary(annualSalary, taxRatesInfoFilePath);

            var taxableSalary = annualSalary - taxRatesInfo.getNonTaxableSalary();
            var taxOnSalary = taxableSalary * taxRatesInfo.getTaxPerDollar();
            var incomeTax = Math.Round((taxOnSalary + taxRatesInfo.getExtraTax()) / 12);

            return incomeTax;
        }

        private static TaxRatesInfo GetTaxRatesForAnnualSalary(int annualSalary, string taxRatesInfoFilePath)
        {
            var jsonContent = FileReader.ReadFromJSONFile(taxRatesInfoFilePath); 
            var taxRatesInfo = JsonConvert.DeserializeObject<IEnumerable<TaxRatesInfo>>(jsonContent);
            
            var taxRatesOfSalaryRange = taxRatesInfo.Where(taxRange =>annualSalary >= taxRange.getMinimumSalary() && annualSalary <= taxRange.getMaximumSalary());
            var minimumSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.getMinimumSalary()).First();
            var maximumSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.getMaximumSalary()).First();
            var nonTaxableSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.getNonTaxableSalary()).First();
            var taxPerDollar = taxRatesOfSalaryRange.Select(taxRange => taxRange.getTaxPerDollar()).First();
            var extraTax = taxRatesOfSalaryRange.Select(taxRange => taxRange.getExtraTax()).First();

            return new TaxRatesInfo(minimumSalary, maximumSalary, nonTaxableSalary, taxPerDollar, extraTax);
        }
    }
}