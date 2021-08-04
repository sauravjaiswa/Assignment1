using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public interface IAgeCalculator : IDateOfBirth
    {
        void CalculateAge();
    }
    class AgeCalculator : IAgeCalculator
    {
        public string DOB { get; set; }
        private string age;
        private readonly ILogger _logger;

        public AgeCalculator(ILogger logger)
        {
            _logger = logger;
        }

        public void CalculateAge()
        {
            DateTime dob;
            DateTime.TryParseExact(DOB, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob);
            age = (DateTime.Now.Subtract(dob).Days / 365).ToString();
        }

        public void Display()
        {
            CalculateAge();
            _logger.LogInfo($"DOB : {DOB}");
            _logger.LogInfo($"Age : {age}");
        }
    }
}
