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
            var personDetails = new Person(firstName, lastName);
            var expectedFullName = personDetails.GetFullName();
            
            Assert.Equal(expectedFullName, actualFullName);
        }
    }
}