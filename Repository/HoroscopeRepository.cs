using System.Collections.Generic;

namespace Assignment1
{
    class HoroscopeRepository
    {
        private static readonly Dictionary<string, HoroscopeModel> horoscopeRepo = new Dictionary<string, HoroscopeModel>();

        //public HoroscopeModel this[string sunSign]
        //{
        //    get
        //    {
        //        return horoscopeRepo.GetValueOrDefault(sunSign);
        //    }
        //    set
        //    {
        //        if (!ContainsKey(sunSign))
        //            horoscopeRepo.Add(sunSign, value);
        //    }
        //}

        public static bool ContainsKey(string sunSign)
        {
            return horoscopeRepo.ContainsKey(sunSign);
        }

        public static void Add(string sunSign,HoroscopeModel horoscope)
        {
            if (!ContainsKey(sunSign)) 
                horoscopeRepo.Add(sunSign, horoscope);
        }

        public static HoroscopeModel Get(string sunSign)
        {
            return horoscopeRepo.GetValueOrDefault(sunSign);
        }

        public static void RemoveKey(string sunSign)
        {
            horoscopeRepo.Remove(sunSign);
        }
    }
}
