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

        public string getFullName()
        {
            return FullName;
        }
        
        public string getPayPeriod()
        {
            return PayPeriod;
        }
        
        public int getGrossIncome()
        {
            return GrossIncome;
        }
        
        public int getIncomeTax()
        {
            return IncomeTax;
        }
        
        public int getNetIncome()
        {
            return NetIncome;
        }
        
        public int getSuper()
        {
            return Super;
        }
        
    }
}