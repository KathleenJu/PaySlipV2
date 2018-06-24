using System;
using System.Globalization;
using System.Text.RegularExpressions;

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

        public string GetPayPeriod()
        {
            string payPeriod =  FormatDate(_paymentStartDate) + " - " + FormatDate(_paymentEndDate);
            return payPeriod;
        }

        private string FormatDate(string dayAndMonthDate)
        {
            var formattedDate = Convert.ToDateTime(dayAndMonthDate + DateTime.Now.Year).ToString("dd MMMM");
            return formattedDate;
        }
    }
}