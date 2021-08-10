using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class HoroscopeModel
    {
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("compatibility")]
        public string Compatibility { get; set; }
        [JsonProperty("current_date")]
        public string Current_date { get; set; }
        [JsonProperty("date_range")]
        public string Date_range { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("lucky_number")]
        public string Lucky_number { get; set; }
        [JsonProperty("lucky_time")]
        public string Lucky_time { get; set; }
        [JsonProperty("mood")]
        public string Mood { get; set; }
    }
}
