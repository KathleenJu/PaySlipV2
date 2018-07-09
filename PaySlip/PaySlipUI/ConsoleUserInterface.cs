using System;
using System.Collections.Generic;
using System.Linq;

namespace PaySlip.PaySlipUI
{
    public class ConsoleUserInterface : IPaySlipUserInterface
    {
        private readonly Dictionary<string, string> _personDetails = new Dictionary<string, string>();

        public Dictionary<string, string> GetPersonDetails(Dictionary<string, string> formQuestions) 
        {
            Console.WriteLine("Welcome to the payslip generator!\n");
            foreach (var field in formQuestions)
            {
                Console.Write(field.Value);
                GetUserInput(field);
            }

            return _personDetails;
        }

        private void GetUserInput(KeyValuePair<string, string> field)
        {
            _personDetails.Add(field.Key, Console.ReadLine());
        }

        public void PrintPaySlip(PaySlip paySlip, Dictionary<string, string> paySlipFields)
        {

            Console.WriteLine("\nYour payslip has been generated:\n");
            
            Console.Write(paySlipFields.Where(x => x.Key == "FullName").Select(x => x.Value).First());
            Console.WriteLine(paySlip.GetFullName());
            Console.Write(paySlipFields.Where(x => x.Key == "PaymentPeriod").Select(x => x.Value).First());
            Console.WriteLine(paySlip.GetPayPeriod());
            Console.Write(paySlipFields.Where(x => x.Key == "GrossIncome").Select(x => x.Value).First());
            Console.WriteLine(paySlip.GetGrossIncome());
            Console.Write(paySlipFields.Where(x => x.Key == "NetIncome").Select(x => x.Value).First());
            Console.WriteLine(paySlip.GetNetIncome());
            Console.Write(paySlipFields.Where(x => x.Key == "IncomeTax").Select(x => x.Value).First());
            Console.WriteLine(paySlip.GetIncomeTax());
            Console.Write(paySlipFields.Where(x => x.Key == "Super").Select(x => x.Value).First());
            Console.WriteLine(paySlip.GetSuper());
            
            Console.WriteLine("\nThank you for using MYOB!");
        }
    }
}