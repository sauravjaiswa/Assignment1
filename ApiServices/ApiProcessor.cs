using Refit;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment1
{
    [Headers("Content-Type: application/json")]
    public interface IApiService
    {
        [Post("")]
        Task<HoroscopeModel> GetHoroscopeAsync([Query] string sign, [Query] string day = "today");
    }
    public class ApiProcessor
    {
        private readonly string baseUrl = "https://sameer-kumar-aztro-v1.p.rapidapi.com/";

        private async Task<HoroscopeModel> GetHoroscopeAsync(string zodiac)
        {
            //if (HoroscopeRepository.LastUpdate == "17368")//DateTime.Now.ToShortDateString()
            //{
            //    Console.WriteLine("TEST - "+HoroscopeRepository.LastUpdate);
            //    HoroscopeRepository.Clear();
            //}

            if (HoroscopeRepository.ContainsKey(zodiac))
            {
                return HoroscopeRepository.Get(zodiac);
            }
            else
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{baseUrl}?sign={zodiac}&day=today"),
                    Headers =
                    {
                        { "x-rapidapi-key", ApiClientHelper.RapidApiKey },
                        { "x-rapidapi-host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
                    },
                };

                using (HttpResponseMessage response = await ApiClientHelper.ApiClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        response.EnsureSuccessStatusCode();
                        var horoscopeModel = await response.Content.ReadAsAsync<HoroscopeModel>();
                        HoroscopeRepository.Add(zodiac, horoscopeModel);
                        
                        return horoscopeModel;
                    }
                    throw new Exception(response.StatusCode.ToString());
                }

            }

        }

        public string GetSunSign(string dob)
        {
            return SunSignRepository.GetSunSign(dob);
        }

        public async Task<string> GetHoroscope(string sunSign)
        {
            if (HoroscopeRepository.ContainsKey(sunSign))
                return HoroscopeRepository.Get(sunSign).Description;
            else
            {
                HoroscopeModel horoscope = await GetHoroscopeAsync(sunSign);
                return horoscope.Description;
            }
        }

        public async Task<string> GetLuckyNumber(string sunSign)
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
