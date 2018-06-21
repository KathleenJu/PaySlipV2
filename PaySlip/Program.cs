using System;

namespace PaySlip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the payslip generator!\n");
            
            Console.Write("Please input your name: ");
            var firstName = Console.ReadLine();
            Console.Write("Please input your surname: ");
            var lastName = Console.ReadLine();
            Console.Write("Please input your annual salary: ");
            var annualSalary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please input your super rate: ");
            var superRate = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please input your payment start date: ");
            var paymentStartDate = Console.ReadLine();
            Console.Write("Please input your payment end date: ");
            var paymentEndDate = Console.ReadLine();

            var paymentDetails = new PaymentDetails(annualSalary, superRate, paymentStartDate, paymentEndDate);
            var employee = new Employee(firstName, lastName, paymentDetails);


//            var paySlip = CalculatePaySlip(employee, );
            
            Console.WriteLine("\nYour payslip has been generated:\n");
            Console.WriteLine("Full Name: " + employee.GetFullName());
            Console.WriteLine("Pay Period: " + paymentDetails.GetPayPeriod());
            Console.WriteLine("\nThank you for using MYOB!");
        }
    }
}