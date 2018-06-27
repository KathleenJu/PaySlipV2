using System;

namespace PaySlip
{
    class Program
    {
        static void Main(string[] args)
        {
            var paySlipConsole = new ConsoleUserInterface();
            var userFormFilePath = "./files/formQuestions.json";
            var paySlipFilePath = "./files/paySlip.json";
            var taxRatesInfoFilePath = "./files/taxRateInfo.json";
            
            var personDetails = paySlipConsole.GetPersonDetails(userFormFilePath);
            var paymentDetails = new PaymentDetails(Convert.ToInt32(personDetails["annualSalary"]), Convert.ToInt32(personDetails["superRate"]), personDetails["paymentStartDate"], personDetails["paymentEndDate"] );
            var employee = new Employee(personDetails["firstName"], personDetails["lastName"], paymentDetails);

            var fullName = employee.GetFullName();
            var employeePaymentDetails = employee.getPaymentDetails();
            var payPeriod = employeePaymentDetails.GetPayPeriod();
            var grossIncome = TaxCalculator.CalculateGrossIncome(employeePaymentDetails.getAnnualSalary());
            var incomeTax = TaxCalculator.CalculateIncomeTax(employeePaymentDetails.getAnnualSalary(), taxRatesInfoFilePath);
            var netIncome = TaxCalculator.CalculateNetIncome(grossIncome, incomeTax);
            var super = TaxCalculator.CalculateSuper(grossIncome, Convert.ToInt32(personDetails["superRate"]));
            var paySlip = new PaySlip(fullName, payPeriod, grossIncome, incomeTax, netIncome, super);
            
            paySlipConsole.PrintPaySlip(paySlip, paySlipFilePath);
            
//            var paySlip = CalculatePaySlip(employee);
        }
    }
}