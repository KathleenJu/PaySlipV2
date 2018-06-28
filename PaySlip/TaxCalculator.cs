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

            var taxableSalary = _annualSalary - taxRatesInfo.getNonTaxableSalary();
            var taxOnSalary = taxableSalary * taxRatesInfo.getTaxPerDollar();
            var incomeTax = Math.Round((taxOnSalary + taxRatesInfo.getExtraTax()) / 12);

            return (int) incomeTax;
        }

        private TaxRatesInfo GetTaxRatesForAnnualSalary()
        {
            var taxRatesOfSalaryRange = TaxRates.Where(taxRange =>
                _annualSalary >= taxRange.getMinimumSalary() && _annualSalary <= taxRange.getMaximumSalary());
            var minimumSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.getMinimumSalary()).First();
            var maximumSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.getMaximumSalary()).First();
            var nonTaxableSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.getNonTaxableSalary()).First();
            var taxPerDollar = taxRatesOfSalaryRange.Select(taxRange => taxRange.getTaxPerDollar()).First();
            var extraTax = taxRatesOfSalaryRange.Select(taxRange => taxRange.getExtraTax()).First();

            return new TaxRatesInfo(minimumSalary, maximumSalary, nonTaxableSalary, taxPerDollar, extraTax);
        }
    }
}