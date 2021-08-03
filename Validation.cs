using System;
using System.Globalization;

namespace Assignment1
{
    public class Validation : IValidation
    {
        public bool IsValidDate(string dob)
        {
            bool result = DateTime.TryParseExact(dob, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

            return result;
        }

        public bool IsValidChoice(string ch)
        {
            bool result = int.TryParse(ch, out _);

            return result;
        }
    }
}
