using System;
using System.Collections;
using System.Collections.Generic;
using PaySlip.FileReader;
using PaySlip.PaySlipUI;

namespace PaySlip
{
    class Program
    {
        static void Main(string[] args)
        {
            var fillOutFormFilePath = "./files/fillOutForm.json";
            var paySlipFilePath = "./files/paySlip.json";
            var taxRatesInfoFilePath = "./files/taxRatesInfo.json";
            
            var paySlipConsole = new ConsoleUserInterface();
            var json = new JsonFileReader(fillOutFormFilePath);
            var formQuestions = json.ParseBasicFormFile();
            var personDetails = paySlipConsole.GetPersonDetails( formQuestions);
            var paymentDetails = new PaymentDetails(Convert.ToInt32(personDetails["annualSalary"]), Convert.ToInt32(personDetails["superRate"]), personDetails["paymentStartDate"], personDetails["paymentEndDate"] );
            var employee = new Employee(personDetails["firstName"], personDetails["lastName"], paymentDetails);

            var taxRates = new JsonFileReader(taxRatesInfoFilePath).ParseTaxRatesInfoFile();
            var paySlip = new PaySlip(employee, taxRates);
//            
            var paySlipForm = new JsonFileReader(paySlipFilePath).ParseBasicFormFile();
//            
            paySlipConsole.PrintPaySlip(paySlip, paySlipForm);
        }
    }
}