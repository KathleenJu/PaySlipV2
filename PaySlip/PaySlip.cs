namespace PaySlip
{
    public class PaySlip
    {
        private string FullName;
        private string PayPeriod;
        private int grossIncome;
        private int incomeTax;
        private int netIncome;
        private int super;

        public PaySlip(string fullName, string payPeriod, int grossIncome, int incomeTax, int netIncome, int super)
        {
            FullName = fullName;
            PayPeriod = payPeriod;
            this.grossIncome = grossIncome;
            this.incomeTax = incomeTax;
            this.netIncome = netIncome;
            this.super = super;
        }
    }
}