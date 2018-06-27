namespace PaySlip
{
    public class PaySlip
    {
        public readonly string FullName;
        public readonly string PayPeriod;
        public readonly int GrossIncome;
        public readonly int IncomeTax;
        public readonly int NetIncome;
        public readonly int Super;

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