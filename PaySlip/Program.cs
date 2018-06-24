using System;

namespace PaySlip
{
    class Program
    {
        static void Main(string[] args)
        {
            var paySlipConsole = new ConsoleUserInterface();
            paySlipConsole.GeneratePaySlipForm("./files/formQuestions.json");
             
//            var paySlip = CalculatePaySlip(employee,  );
        }
    }
}