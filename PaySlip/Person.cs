using System.Globalization;

namespace PaySlip
{
    public abstract class Person
    {
        private readonly string _firstName;
        private readonly string _lastName;

        protected Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
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