using System.Globalization;

namespace PaySlip
{
    public class Person
    {
        protected string _firstName = "default";
        protected string _lastName = "default";

        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        protected Person()
        {
        }

        public string GetFullName()
        {
            var fullName = GetTitleCase(_firstName + " " + _lastName);
            return fullName;
        }

        private string GetTitleCase(string name)
        {
            var capitalisedName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
            return capitalisedName;
        }
    }
}