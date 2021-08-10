using System;
using System.Collections.Generic;
using System.Globalization;

namespace Assignment1
{
    static class HoroscopeRepository
    {
        private static readonly Dictionary<string, HoroscopeModel> horoscopeRepo = new Dictionary<string, HoroscopeModel>();

        public static string LastUpdate { get; set; }

        public static bool ContainsKey(string sunSign)
        {
            return horoscopeRepo.ContainsKey(sunSign);
        }

        public static void Add(string sunSign,HoroscopeModel horoscope)
        {
            if (!ContainsKey(sunSign))
            {
                horoscopeRepo.Add(sunSign, horoscope);
                //LastUpdate = "17368";
            }
        }

        public static HoroscopeModel Get(string sunSign)
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
