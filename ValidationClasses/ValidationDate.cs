using System;
using System.Globalization;

namespace Assignment1
{
    public class ValidationDate : IValidationDate
    {
        public bool IsValidDate(string dob)
        {
            DateTime temp;
            bool result = DateTime.TryParseExact(dob, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp);


            return result && (temp.Year <= DateTime.Now.Year);
        }
    }
}
