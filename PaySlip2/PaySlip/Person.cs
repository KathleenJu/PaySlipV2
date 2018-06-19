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
    }

    public class Employee : Person
    {
        private string _company;
//        private PaymentDetails _paymentDetails;

        public Employee(string firstName, string lastName, string company)
        {
            _firstName = firstName;
            _lastName = lastName;
            _company = company;
        }
    }
}