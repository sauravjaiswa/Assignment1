using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment1
{
    public class ApiProcessor
    {
        private readonly HoroscopeRepository _horoscopeRepository;
        private readonly SunSignRepository _sunSignRepository;

        public ApiProcessor()
        {
            _sunSignRepository = new SunSignRepository();
            _horoscopeRepository = new HoroscopeRepository();
        }

        private async Task<HoroscopeModel> GetHoroscopeAsync(string zodiac)
        {
            if (_horoscopeRepository.ContainsKey(zodiac))
            {
                return _horoscopeRepository.Get(zodiac);
            }
            else
            {
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
                    if (response.IsSuccessStatusCode)
                    {
                        response.EnsureSuccessStatusCode();
                        var horoscopeModel = await response.Content.ReadAsAsync<HoroscopeModel>();
                        _horoscopeRepository.Add(zodiac, horoscopeModel);
                        
                        return horoscopeModel;
                    }
                    throw new Exception(response.StatusCode.ToString());
                }

            }

        }

        public string GetSunSign(string dob)
        {
            return _sunSignRepository.GetSunSign(dob);
        }

        public async Task<string> GetHoroscope(string sunSign)
        {
            if (_horoscopeRepository.ContainsKey(sunSign))
                return _horoscopeRepository.Get(sunSign).Description;
            else
            {
                HoroscopeModel horoscope = await GetHoroscopeAsync(sunSign);
                return horoscope.Description;
            }
        }

        public async Task<string> GetLuckyNumber(string sunSign)
        {
            if (_horoscopeRepository.ContainsKey(sunSign))
                return _horoscopeRepository.Get(sunSign).Lucky_number;
            else
            {
                HoroscopeModel horoscope = await GetHoroscopeAsync(sunSign);
                return horoscope.Lucky_number;
            }
        }
    }
}
