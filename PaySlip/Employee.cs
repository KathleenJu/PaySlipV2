namespace PaySlip
{
    public class Employee : Person
    {
        private string _company;
        private PaymentDetails _paymentDetails;
        private PaySlip _paySlip;

        public Employee(string firstName, string lastName, PaymentDetails paymentDetails) : base(firstName, lastName)
        {
            _paymentDetails = paymentDetails;
        }

        public void setPaymentDetails(PaymentDetails paymentDetails)
        {
            _paymentDetails = paymentDetails;
        }

        public PaymentDetails getPaymentDetails()
        {
            return _paymentDetails;
        }

        public PaySlip getPaySlip()
        {
            return _paySlip;
        }

        public void setPaySlip(PaySlip paySlip)
        {
            _paySlip = paySlip;
        }
    }
}