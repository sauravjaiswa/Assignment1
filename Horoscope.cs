using System;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Horoscope : IHoroscope
    {
        public string DOB { get; set; }
        private string sunSign, horoscope;
        private string status = "OK";
        private readonly ILogger _logger;
        private readonly ApiProcessor _processor;

        public Horoscope(ILogger logger)
        {
            _processor = new ApiProcessor();
            _logger = logger;
        }

        public void GetSunSign()
        {
            sunSign = _processor.GetSunSign(DOB);
        }

        public async Task GetHoroscope()
        {
            try
            {
                //Console.WriteLine("Horoscope called...");
                horoscope = await _processor.GetHoroscope(sunSign);
            }
            catch(Exception e)
            {
                status = e.Message;
            }
        }

        public void Display()
        {
            GetSunSign();
            _logger.LogInfo($"DOB : {DOB} \nSun Sign : {sunSign}");
            var t = Task.WhenAny(GetHoroscope());
            while (!t.IsCompleted)
            {
                Console.Write(".");
                Console.Write("\b");
            }
            if (status != "OK")
            {
                _logger.LogError(status);
            }
            else
            {
                _logger.LogInfo($"Horoscope : {horoscope}");
            }   
        }
    }
}
