using System;

namespace PaySlip
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeDetails = new Employee("john", "doe");
            Console.WriteLine("Full Name: " + employeeDetails.GetFullName());
        }
    }
}