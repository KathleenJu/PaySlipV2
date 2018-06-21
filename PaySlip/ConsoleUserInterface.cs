using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PaySlip
{
    public class ConsoleUserInterface : PaySlipUserInterface
    {
        private readonly Dictionary<string, string> _userDetails = new Dictionary<string, string>();

        public void GeneratePaySlipForm(string formFile) //askforuserdetails?
        {
            using (StreamReader file = new StreamReader(formFile))
            {
                var json = file.ReadToEnd();
                var formFields = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                foreach (var field in formFields)
                {
                    Console.Write(field.Value);
//                    _userDetails.Add(field.Key, Console.ReadLine());
                }
            }
        }

//        public Employee GenerateEmployee()//should this method be in this class?? 
//        {
//            var paymentDetails = new PaymentDetails(Convert.ToInt32(_userDetails["annualSalary"]), Convert.ToInt32(_userDetails["superRate"]), _userDetails["paymentStartDate"], _userDetails["paymentEndDate"] );
//            return new Employee(_userDetails["firstName"], _userDetails["lastName"], paymentDetails);
//        }

        public void PrintPaySlip()
        {
        }
    }
}