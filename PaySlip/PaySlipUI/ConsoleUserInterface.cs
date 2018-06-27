using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace PaySlip
{
    public class ConsoleUserInterface : PaySlipUserInterface
    {
        private readonly Dictionary<string, string> _userDetails = new Dictionary<string, string>();

        public Dictionary<string, string> GetPersonDetails(string formFilePath) //refactor, doing more than one thing?
        {
            var formQuestionsContent = FileReader.ReadFromJSONFile(formFilePath);
            var formFields = JsonConvert.DeserializeObject<Dictionary<string, string>>(formQuestionsContent);

            Console.WriteLine("Welcome to the payslip generator!\n");
            foreach (var field in formFields)
            {
                Console.Write(field.Value);
                GetUserInput(field);
            }

            return _userDetails;
        }

        private void GetUserInput(KeyValuePair<string, string> field)
        {
            _userDetails.Add(field.Key, Console.ReadLine());
        }

        public void PrintPaySlip(PaySlip paySlip, string paySlipFilePath)
        {
            var formQuestionsContent = FileReader.ReadFromJSONFile(paySlipFilePath);
            var paySlipFields = JsonConvert.DeserializeObject<Dictionary<string, string>>(formQuestionsContent);

            Console.WriteLine("\nYour payslip has been generated:\n");
            
            Console.Write(paySlipFields.Where(x => x.Key == "FullName").Select(x => x.Value).First());
            Console.WriteLine(paySlip.FullName);
            Console.Write(paySlipFields.Where(x => x.Key == "PaymentPeriod").Select(x => x.Value).First());
            Console.WriteLine(paySlip.PayPeriod);
            Console.Write(paySlipFields.Where(x => x.Key == "GrossIncome").Select(x => x.Value).First());
            Console.WriteLine(paySlip.GrossIncome);
            Console.Write(paySlipFields.Where(x => x.Key == "NetIncome").Select(x => x.Value).First());
            Console.WriteLine(paySlip.NetIncome);
            Console.Write(paySlipFields.Where(x => x.Key == "IncomeTax").Select(x => x.Value).First());
            Console.WriteLine(paySlip.IncomeTax);
            Console.Write(paySlipFields.Where(x => x.Key == "Super").Select(x => x.Value).First());
            Console.WriteLine(paySlip.Super);
            
            Console.WriteLine("\nThank you for using MYOB!");
        }
    }
}