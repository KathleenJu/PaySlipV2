using System;

namespace PaySlip
{
    class Program
    {
        static void Main(string[] args)
        {
            var paySlipConsole = new ConsoleUserInterface();
            var paySlipFormFile = "./files/formQuestions.json";
            
            paySlipConsole.GeneratePaySlipForm(paySlipFormFile);

//            var paySlip = CalculatePaySlip(employee,  );
        }
    }
}