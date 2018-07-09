using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PaySlip
{
    public class PaySlip
    {
        private readonly Employee _employee;
        private readonly IEnumerable<TaxRatesInfo> _taxRates;

        public PaySlip(Employee employee, IEnumerable<TaxRatesInfo> taxRates)
        {
            _employee = employee;
            _taxRates = taxRates;
        }

        public string GetFullName()
        {
            return _employee.GetFullName();
        }

        public string GetPayPeriod()
        {
            var employeePaymentDetails = _employee.GetPaymentDetails();
            return employeePaymentDetails.GetPayPeriod();
        }
        
        public int GetGrossIncome() // monthsOfPaymentPeriod
        {
            var monthsInAYear = 12;
            var annualSalary = _employee.GetPaymentDetails().GetAnnualSalary();
            var grossIncome = annualSalary / monthsInAYear; // * monthsOfPaymentPeriod;

            return grossIncome;
        }

        public int GetSuper()
        {
            var superRate = _employee.GetPaymentDetails().GetSuperRate();
            var grossIncome = GetGrossIncome();
            var superRateInDecimal = (double) superRate / 100;
            var expectedSuper = grossIncome * superRateInDecimal;

            return (int) Math.Floor(expectedSuper);
        }

        public int GetNetIncome()
        {
            var grossIncome = GetGrossIncome();
            var incomeTax = GetIncomeTax();
            var netIncome = grossIncome - incomeTax;
            return netIncome;
        }

        public int GetIncomeTax()
        {
            var annualSalary = _employee.GetPaymentDetails().GetAnnualSalary();
            var taxRatesInfo = GetTaxRatesForAnnualSalary();

            var taxableSalary = annualSalary - taxRatesInfo.GetNonTaxableSalary();
            var taxOnSalary = taxableSalary * taxRatesInfo.GetTaxPerDollar();
            var incomeTax = Math.Round((taxOnSalary + taxRatesInfo.GetExtraTax()) / 12);

            return (int) incomeTax;
        }

        private TaxRatesInfo GetTaxRatesForAnnualSalary()
        {
            var annualSalary = _employee.GetPaymentDetails().GetAnnualSalary();
            var taxRatesOfSalaryRange = _taxRates.Where(taxRange =>
                annualSalary >= taxRange.GetMinimumSalary() && annualSalary <= taxRange.GetMaximumSalary()).ToList();
            var minimumSalary = taxRatesOfSalaryRange.ToList().Select(taxRange => taxRange.GetMinimumSalary()).First();
            var maximumSalary = taxRatesOfSalaryRange.ToList().Select(taxRange => taxRange.GetMaximumSalary()).First();
            var nonTaxableSalary = taxRatesOfSalaryRange.ToList().Select(taxRange => taxRange.GetNonTaxableSalary()).First();
            var taxPerDollar = taxRatesOfSalaryRange.ToList().Select(taxRange => taxRange.GetTaxPerDollar()).First();
            var extraTax = taxRatesOfSalaryRange.ToList().Select(taxRange => taxRange.GetExtraTax()).First();

            return new TaxRatesInfo(minimumSalary, maximumSalary, nonTaxableSalary, taxPerDollar, extraTax);
        }
    }
}