using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace PaySlip
{
    public class TaxRates
    {
        private double MinimumSalary { get; }
        private double MaximumSalary { get; }
        private double NonTaxableSalary { get; }
        private double TaxPerDollar { get; }
        private double ExtraTax { get; }

        public TaxRates(double minimumSalary, double maximumSalary, double nonTaxableSalary, double taxPerDollar,
            double extraTax)
        {
            MinimumSalary = minimumSalary;
            MaximumSalary = maximumSalary;
            NonTaxableSalary = nonTaxableSalary;
            TaxPerDollar = taxPerDollar;
            ExtraTax = extraTax;
        }

        public double getMinimumSalary()
        {
            return MinimumSalary;
        }

        public double getMaximumSalary()
        {
            return MaximumSalary;
        }

        public double getNonTaxableSalary()
        {
            return NonTaxableSalary;
        }

        public double getTaxPerDollar()
        {
            return TaxPerDollar;
        }

        public double getExtraTax()
        {
            return ExtraTax;
        }
    }
}