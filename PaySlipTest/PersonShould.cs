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
            var employeeDetails = new Employee(firstName, lastName);
            var expectedFullName = employeeDetails.GetFullName();
            
            Assert.Equal(expectedFullName, actualFullName);
        }
    }
}