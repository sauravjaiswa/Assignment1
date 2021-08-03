using System;
using System.Globalization;

namespace Assignment1
{
    public class Validation : IValidation
    {
        public bool IsValidDate(string dob)
        {
            DateTime date;
            bool result = DateTime.TryParseExact(dob, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            return result;
        }

        public bool IsValidChoice(string ch)
        {
            int choice;
            bool result = int.TryParse(ch, out choice);

            return result;
        }
    }
}
