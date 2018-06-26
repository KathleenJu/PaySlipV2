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

        public Dictionary<string, string> GetUserDetails(string formFilePath) //refactor, doing more than one thing?
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

//        public Employee GenerateEmployee()//should this method be in this class?? 
//        {
//            var paymentDetails = new PaymentDetails(Convert.ToInt32(_userDetails["annualSalary"]), Convert.ToInt32(_userDetails["superRate"]), _userDetails["paymentStartDate"], _userDetails["paymentEndDate"] );
//            return new Employee(_userDetails["firstName"], _userDetails["lastName"], paymentDetails);
//        }

        public void PrintPaySlip(PaySlip paySlip, string paySlipFilePath)
        {
            var formQuestionsContent = FileReader.ReadFromJSONFile(paySlipFilePath);
            var paySlipFields = JsonConvert.DeserializeObject<Dictionary<string, string>>(formQuestionsContent);

            Console.WriteLine("\nYour payslip has been generated:\n");
            
            Console.Write(paySlipFields.Where(x => x.Key == "FullName").Select(x => x.Value).First());
            Console.WriteLine(paySlip.getFullName());
            Console.Write(paySlipFields.Where(x => x.Key == "PaymentPeriod").Select(x => x.Value).First());
            Console.WriteLine(paySlip.getPayPeriod());
            Console.Write(paySlipFields.Where(x => x.Key == "GrossIncome").Select(x => x.Value).First());
            Console.WriteLine(paySlip.getGrossIncome());
            Console.Write(paySlipFields.Where(x => x.Key == "NetIncome").Select(x => x.Value).First());
            Console.WriteLine(paySlip.getNetIncome());
            Console.Write(paySlipFields.Where(x => x.Key == "IncomeTax").Select(x => x.Value).First());
            Console.WriteLine(paySlip.getIncomeTax());
            Console.Write(paySlipFields.Where(x => x.Key == "Super").Select(x => x.Value).First());
            Console.WriteLine(paySlip.getSuper());
            
            Console.WriteLine("\nThank you for using MYOB!");
        }
    }
}