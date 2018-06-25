namespace PaySlip
{
    public class PaySlip
    {
        private string FullName;
        private string PayPeriod;
        private int GrossIncome;
        private int IncomeTax;
        private int NetIncome;
        private int Super;

        public PaySlip(string fullName, string payPeriod, int grossIncome, int incomeTax, int netIncome, int super)
        {
            FullName = fullName;
            PayPeriod = payPeriod;
            GrossIncome = grossIncome;
            IncomeTax = incomeTax;
            NetIncome = netIncome;
            Super = super;
        }
    }
}