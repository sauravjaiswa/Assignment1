using System;
using System.Globalization;

namespace Assignment1
{
    public class ValidationDate : IValidationDate
    {
        public bool IsValidDate(string dob)
        {
            bool result = DateTime.TryParseExact(dob, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

            return result;
        }
    }
}
