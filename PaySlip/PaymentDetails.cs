namespace PaySlip
{
    public class PaymentDetails
    {
        private int _annualSalary;
        private int _superRate;
        private string _paymentStartDate;
        private string _paymentEndDate;

        public PaymentDetails(int annualSalary, int superRate, string paymentStartDate, string paymentEndDate)
        {
            _annualSalary = annualSalary;
            _superRate = superRate;
            _paymentStartDate = paymentStartDate;
            _paymentEndDate = paymentEndDate;
        }

        public string GeneratePayPeriod()
        {
            string payPeriod = _paymentStartDate + " - " + _paymentEndDate;
            return payPeriod;
        }
    }
}