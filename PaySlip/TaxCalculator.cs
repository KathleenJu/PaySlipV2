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

        public double GetTaxRates(int annualSalary, string taxRatesFile) //refactor name as it doesnt reflect the method as it calls calculateIncomeTax()
        {
            using (StreamReader file = new StreamReader(taxRatesFile))
            {
                var json = file.ReadToEnd();
                var taxRatesInfo = JsonConvert.DeserializeObject<IEnumerable<TaxRates>>(json);
                var taxRatesOfSalaryRange = taxRatesInfo.Where(taxRange => annualSalary >= taxRange.getMinimumSalary() && annualSalary <= taxRange.getMaximumSalary());
                
                var nonTaxableSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.getNonTaxableSalary()).First();
                var taxPerDollar = taxRatesOfSalaryRange.Select(taxRange => taxRange.getTaxPerDollar()).First();
                var extraTax = taxRatesOfSalaryRange.Select(taxRange => taxRange.getExtraTax()).First();
                
                return CalculateIncomeTax(annualSalary, nonTaxableSalary, taxPerDollar, extraTax);
            }
        }

        private double CalculateIncomeTax(int annualSalary, double nonTaxableSalary, double taxPerDollar, double extraTax)
        {
            var taxableSalary = annualSalary - nonTaxableSalary;
            var taxOnSalary = taxableSalary * taxPerDollar;
            var incomeTax = Math.Round((taxOnSalary + extraTax) / 12);

            return incomeTax;
        }
    }
}