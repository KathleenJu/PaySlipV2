using System;
using System.Collections;
using System.Collections.Generic;

namespace PaySlip
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var fillOutFormFilePath = "./files/fillOutForm.json";
            var paySlipFilePath = "./files/paySlip.json";
            var taxRatesInfoFilePath = "./files/taxRatesInfo.json";
//            var formConfig = new BasicFormFileConfig();
//            var taxRatesFileConfig = new TaxRatesFileConfig();
            
            var paySlipConsole = new ConsoleUserInterface();
            
//            var fillOutFormContent = JSONFileReader.load(fillOutFormFilePath);
//            var formQuestions = (Dictionary<string, string>)formConfig.Foo(fillOutFormContent) ;
//            var personDetails = paySlipConsole.GetPersonDetails( formQuestions);
//            var paymentDetails = new PaymentDetails(Convert.ToInt32(personDetails["annualSalary"]), Convert.ToInt32(personDetails["superRate"]), personDetails["paymentStartDate"], personDetails["paymentEndDate"] );
//            var employee = new Employee(personDetails["firstName"], personDetails["lastName"], paymentDetails);
//
//            var taxRatesInfoContent = JSONFileReader.load(taxRatesInfoFilePath);
//            var taxRates = (IEnumerable<TaxRatesInfo>)taxRatesFileConfig.Foo(taxRatesInfoContent) ;
//            var paySlip = new PaySlip(employee, taxRates);
//            
//            var paySlipFileContent = JSONFileReader.load(paySlipFilePath);
//            var paySlipForm = (Dictionary<string, string>)formConfig.Foo(paySlipFileContent);
//            
//            paySlipConsole.PrintPaySlip(paySlip, paySlipForm);

        }
    }
}