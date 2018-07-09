using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PaySlip
{
    public class TaxCalculator
    {
        private readonly int _annualSalary;
        private IEnumerable<TaxRatesInfo> TaxRates;
        
        public TaxCalculator(int annualSalary)
        {
            _annualSalary = annualSalary;
        }
        
        public int CalculateGrossIncome() // monthsOfPaymentPeriod
        {
            var monthsInAYear = 12;
            var grossIncome = _annualSalary / monthsInAYear; // * monthsOfPaymentPeriod;

            return grossIncome;
        }

        public int CalculateSuper(int grossIncome, int superRate)
        {
            var superRateInDecimal = (double) superRate / 100;
            var expectedSuper = grossIncome * superRateInDecimal;

            return (int) Math.Floor(expectedSuper);
        }

        public int CalculateNetIncome(int grossIncome, int incomeTax)
        {
            var netIncome = grossIncome - incomeTax;
            return netIncome;
        }

        public int CalculateIncomeTax()
        {
            var taxRatesInfo = GetTaxRatesForAnnualSalary();

            var taxableSalary = _annualSalary - taxRatesInfo.GetNonTaxableSalary();
            var taxOnSalary = taxableSalary * taxRatesInfo.GetTaxPerDollar();
            var incomeTax = Math.Round((taxOnSalary + taxRatesInfo.GetExtraTax()) / 12);

            return (int) incomeTax;
        }

        private TaxRatesInfo GetTaxRatesForAnnualSalary()
        {
            var taxRatesOfSalaryRange = TaxRates.Where(taxRange =>
                _annualSalary >= taxRange.GetMinimumSalary() && _annualSalary <= taxRange.GetMaximumSalary());
            var minimumSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.GetMinimumSalary()).First();
            var maximumSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.GetMaximumSalary()).First();
            var nonTaxableSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.GetNonTaxableSalary()).First();
            var taxPerDollar = taxRatesOfSalaryRange.Select(taxRange => taxRange.GetTaxPerDollar()).First();
            var extraTax = taxRatesOfSalaryRange.Select(taxRange => taxRange.GetExtraTax()).First();

            return new TaxRatesInfo(minimumSalary, maximumSalary, nonTaxableSalary, taxPerDollar, extraTax);
        }
    }
}