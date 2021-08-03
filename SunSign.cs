using System;

namespace Assignment1
{
    public class SunSign : ISunSign
    {
        public string DOB { get; set; }
        private string sunSign;
        private readonly ILogger _logger;
        private readonly ApiProcessor _processor;

        public SunSign(ILogger logger)
        {
            _processor = new ApiProcessor();
            _logger = logger;
        }

        public void GetSunSign()
        {
            sunSign = _processor.GetSunSign(DOB);

        }

        public void Display()
        {
            GetSunSign();
            _logger.LogInfo($"Sun Sign : {sunSign}");
        }
    }
}
