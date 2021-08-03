using System.Collections.Generic;

namespace Assignment1
{
    class HoroscopeRepository
    {
        private static readonly Dictionary<string, HoroscopeModel> horoscopeRepo = new Dictionary<string, HoroscopeModel>();

        public bool ContainsKey(string sunSign)
        {
            return horoscopeRepo.ContainsKey(sunSign);
        }

        public void Add(string sunSign,HoroscopeModel horoscope)
        {
            if (!ContainsKey(sunSign)) 
                horoscopeRepo.Add(sunSign, horoscope);
        }

        public HoroscopeModel Get(string sunSign)
        {
            return horoscopeRepo.GetValueOrDefault(sunSign);
        }

        public void RemoveKey(string sunSign)
        {
            horoscopeRepo.Remove(sunSign);
        }
    }
}
