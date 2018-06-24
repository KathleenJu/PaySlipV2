using PaySlip;
using Xunit;

namespace PaySlipTest
{
    public class PersonShould
    {
        [Theory]
        [InlineData("john", "doe", "John Doe")]
        [InlineData("lucy", "hale", "Lucy Hale")]
        public void ReturnFullNameInTitleCase(string firstName, string lastName, string actualFullName)
        {
            var paymentDetails = new PaymentDetails(0, 0, "test", "test");
            var employee = new Employee(firstName, lastName, paymentDetails);
            var expectedFullName = employee.GetFullName();

            Assert.Equal(expectedFullName, actualFullName);
        }
    }
}