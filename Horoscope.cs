using System;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Horoscope : IHoroscope
    {
        public string DOB { get; set; }
        private string sunSign, horoscope;

        public void GetSunSign()
        {
            sunSign = ApiProcessor.GetSunSign(DOB);
        }

        public async Task GetHoroscope()
        {
            Console.WriteLine("Horoscope called...");
            horoscope = await ApiProcessor.GetHoroscope(sunSign);
        }

        public void Display()
        {
            GetSunSign();
            Console.WriteLine($"Sun Sign : {sunSign}");
            var t = Task.WhenAny(GetHoroscope());
            while (!t.IsCompleted)
            {
                Console.Write(".");
                Console.Write("\b");
            }
            Console.WriteLine($"Horoscope : {horoscope}");
        }
    }
}
