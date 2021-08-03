using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment1
{
    public class ApiProcessor
    {
        static ApiProcessor()
        {
            Console.WriteLine("Trying");
            SunSignRepository.MapDates();
        }

        private static async Task<HoroscopeModel> GetHoroscopeAsync(string zodiac)
        {
            if (HoroscopeRepository.ContainsKey(zodiac))
            {
                return HoroscopeRepository.Get(zodiac);
            }
            else
            {
                Console.WriteLine("Calling API...");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign={zodiac}&day=today"),
                    Headers =
                    {
                        { "x-rapidapi-key", ApiClientHelper.RapidApiKey },
                        { "x-rapidapi-host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
                    },
                };

                using (HttpResponseMessage response = await ApiClientHelper.ApiClient.SendAsync(request))
                {

                    //Console.WriteLine("Trying...");
                    if (response.IsSuccessStatusCode)
                    {
                        response.EnsureSuccessStatusCode();
                        var horoscopeModel = await response.Content.ReadAsAsync<HoroscopeModel>();
                        HoroscopeRepository.Add(zodiac, horoscopeModel);

                        return horoscopeModel;
                    }
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }

        public static string GetSunSign(string dob)
        {
            return SunSignRepository.GetSunSign(dob);
        }

        public static async Task<string> GetHoroscope(string sunSign)
        {
            if (HoroscopeRepository.ContainsKey(sunSign))
                return HoroscopeRepository.Get(sunSign).Description;
            else
            {
                HoroscopeModel horoscope = await GetHoroscopeAsync(sunSign);
                return horoscope.Description;
            }
        }

        public static async Task<string> GetLuckyNumber(string sunSign)
        {
            if (HoroscopeRepository.ContainsKey(sunSign))
                return HoroscopeRepository.Get(sunSign).Lucky_number;
            else
            {
                HoroscopeModel horoscope = await GetHoroscopeAsync(sunSign);
                return horoscope.Lucky_number;
            }
        }
    }
}
