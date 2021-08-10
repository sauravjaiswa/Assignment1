using System;
using System.Collections.Generic;
using System.Globalization;

namespace Assignment1
{
    static class HoroscopeRepository
    {
        private static readonly Dictionary<string, KeyValuePair<string, HoroscopeModel>> horoscopeRepo = new Dictionary<string, KeyValuePair<string, HoroscopeModel>>();

        public static bool ContainsKey(string sunSign)
        {
            if (horoscopeRepo.ContainsKey(sunSign) && (Get(sunSign).Key != DateTime.Now.ToShortDateString()))
            {
                RemoveKey(sunSign);
                return false;
            }
            return horoscopeRepo.ContainsKey(sunSign);
        }

        public static void Add(string sunSign,HoroscopeModel horoscope)
        {
            if (!ContainsKey(sunSign))
            {
                horoscopeRepo.Add(sunSign, new(DateTime.Now.ToShortDateString(), horoscope));
            }
        }

        public static KeyValuePair<string, HoroscopeModel> Get(string sunSign)
        {
            return horoscopeRepo.GetValueOrDefault(sunSign);
        }

        public static void RemoveKey(string sunSign)
        {
            horoscopeRepo.Remove(sunSign);
        }

        public static void Clear()
        {
            horoscopeRepo.Clear();
        }
    }
}
