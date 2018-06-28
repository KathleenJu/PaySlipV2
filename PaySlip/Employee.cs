namespace PaySlip
{
    public class Employee : Person
    {
        private string _company;
        private readonly PaymentDetails _paymentDetails;
        private PaySlip _paySlip;

        public Employee(string firstName, string lastName, PaymentDetails paymentDetails) : base(firstName, lastName)
        {
            _paymentDetails = paymentDetails;
        }

        public PaymentDetails getPaymentDetails()
        {
            return _paymentDetails;
        }
    }
}