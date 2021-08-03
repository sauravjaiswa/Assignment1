using System;

namespace Assignment1
{
    public class SunSign : ISunSign
    {
        public string DOB { get; set; }
        private string sunSign;

        public void GetSunSign()
        {
            sunSign = ApiProcessor.GetSunSign(DOB);
        }

        public void Display()
        {
            GetSunSign();
            Console.WriteLine($"Sun Sign : {sunSign}");
        }
    }
}
