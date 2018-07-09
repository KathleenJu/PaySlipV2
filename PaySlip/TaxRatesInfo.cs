using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace PaySlip
{
    public class TaxRatesInfo
    {
        private double MinimumSalary { get; }
        private double MaximumSalary { get; }
        private double NonTaxableSalary { get; }
        private double TaxPerDollar { get; }
        private double ExtraTax { get; }

        public TaxRatesInfo(double minimumSalary, double maximumSalary, double nonTaxableSalary, double taxPerDollar,
            double extraTax)
        {
            MinimumSalary = minimumSalary;
            MaximumSalary = maximumSalary;
            NonTaxableSalary = nonTaxableSalary;
            TaxPerDollar = taxPerDollar;
            ExtraTax = extraTax;
        }

        public double GetMinimumSalary()
        {
            return MinimumSalary;
        }

        public double GetMaximumSalary()
        {
            return MaximumSalary;
        }

        public double GetNonTaxableSalary()
        {
            return NonTaxableSalary;
        }

        public double GetTaxPerDollar()
        {
            return TaxPerDollar;
        }

        public double GetExtraTax()
        {
            return ExtraTax;
        }
    }
}