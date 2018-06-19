using System;
using System.Collections.Generic;
using PaySlip;
using Xunit;

namespace PaySlipTest
{
    public class PaymentDetailsShould
    {
        //acceptance test
        [Theory]
        [InlineData("1 March", "31 March", "01 March - 31 March")]
        public void ReturnThePayPeriodGenerated(string paymentStartDate, string paymentEndDate, string actualPayPeriod)
        {
            var paymentDetails = new PaymentDetails(0, 0, paymentStartDate, paymentEndDate);
            var expectedPayPeriod = paymentDetails.GeneratePayPeriod();
            
            Assert.Equal(expectedPayPeriod, actualPayPeriod);
        }
    }
}