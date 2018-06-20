using System.Globalization;

namespace PaySlip
{
    public class Person
    {
        protected string _firstName;
        protected string _lastName;

        public Person()
        {
            _firstName = "default";
            _lastName = "default";
        }

        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string GetFullName()
        {
            var fullName = GetTitleCase(_firstName + " " + _lastName);
            return fullName;
        }

        private string GetTitleCase(string name)
        {
            var capitalisedName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
            return capitalisedName;
        }
    }

    public class Employee : Person
    {
        private string _company;
        private PaymentDetails _paymentDetails;
        private PaySlip _paySlip;

        public Employee(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public void setPaymentDetails(int annualSalary, int superRate, string paymentStartDate, string paymentEndDate)
        {
            _paymentDetails = new PaymentDetails(annualSalary, superRate, paymentStartDate, paymentEndDate);
        }

        public PaySlip getPaySlip()
        {
            return _paySlip;
        }
    }
}