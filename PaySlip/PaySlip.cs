using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PaySlip
{
    public class PaySlip
    {
        private readonly Employee Employee;
        private readonly IEnumerable<TaxRatesInfo> TaxRates;

        public PaySlip(Employee employee, IEnumerable<TaxRatesInfo> taxRates)
        {
            Employee = employee;
            TaxRates = taxRates;
        }

        public string GetFullName()
        {
            return Employee.GetFullName();
        }

        public string GetPayPeriod()
        {
            var employeePaymentDetails = Employee.getPaymentDetails();
            return employeePaymentDetails.GetPayPeriod();
        }
        
        public int GetGrossIncome() // monthsOfPaymentPeriod
        {
            var monthsInAYear = 12;
            var annualSalary = Employee.getPaymentDetails().getAnnualSalary();
            var grossIncome = annualSalary / monthsInAYear; // * monthsOfPaymentPeriod;

            return grossIncome;
        }

        public int GetSuper()
        {
            var superRate = Employee.getPaymentDetails().getSuperRate();
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
            var annualSalary = Employee.getPaymentDetails().getAnnualSalary();
            var taxRatesInfo = GetTaxRatesForAnnualSalary();

            var taxableSalary = annualSalary - taxRatesInfo.getNonTaxableSalary();
            var taxOnSalary = taxableSalary * taxRatesInfo.getTaxPerDollar();
            var incomeTax = Math.Round((taxOnSalary + taxRatesInfo.getExtraTax()) / 12);

            return (int) incomeTax;
        }

        private TaxRatesInfo GetTaxRatesForAnnualSalary()
        {
            var annualSalary = Employee.getPaymentDetails().getAnnualSalary();
            var taxRatesOfSalaryRange = TaxRates.Where(taxRange =>
                annualSalary >= taxRange.getMinimumSalary() && annualSalary <= taxRange.getMaximumSalary());
            var minimumSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.getMinimumSalary()).First();
            var maximumSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.getMaximumSalary()).First();
            var nonTaxableSalary = taxRatesOfSalaryRange.Select(taxRange => taxRange.getNonTaxableSalary()).First();
            var taxPerDollar = taxRatesOfSalaryRange.Select(taxRange => taxRange.getTaxPerDollar()).First();
            var extraTax = taxRatesOfSalaryRange.Select(taxRange => taxRange.getExtraTax()).First();

            return new TaxRatesInfo(minimumSalary, maximumSalary, nonTaxableSalary, taxPerDollar, extraTax);
        }
    }
}