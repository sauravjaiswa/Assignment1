using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    static class SunSignRepository
    {
        private static readonly Dictionary<string, string> SunSignDictionary = new Dictionary<string, string>();

        static SunSignRepository()
        {
            //Console.WriteLine("Mapping dates...");
            MapDates();
        }

        private static void MapDates()
        {
            DateTime date, start, end;
            string sign = "";
            start = DateTime.Parse("01/01/2020");
            end = DateTime.Parse("31/12/2020");

            for (date = start; date <= end; date = date.AddDays(1))
            {
                if (date >= DateTime.Parse("01/01/2020") && date <= DateTime.Parse("19/01/2020"))
                {
                    sign = "Capricorn";
                }
                else if (date >= DateTime.Parse("20/01/2020") && date <= DateTime.Parse("18/02/2020"))
                {
                    sign = "Aquarius";
                }
                else if (date >= DateTime.Parse("19/02/2020") && date <= DateTime.Parse("20/03/2020"))
                {
                    sign = "Pisces";
                }
                else if (date >= DateTime.Parse("21/03/2020") && date <= DateTime.Parse("19/04/2020"))
                {
                    sign = "Aries";
                }
                else if (date >= DateTime.Parse("20/04/2020") && date <= DateTime.Parse("20/05/2020"))
                {
                    sign = "Taurus";
                }
                else if (date >= DateTime.Parse("21/05/2020") && date <= DateTime.Parse("20/06/2020"))
                {
                    sign = "Gemini";
                }
                else if (date >= DateTime.Parse("21/06/2020") && date <= DateTime.Parse("22/07/2020"))
                {
                    sign = "Cancer";
                }
                else if (date >= DateTime.Parse("23/07/2020") && date <= DateTime.Parse("22/08/2020"))
                {
                    sign = "Leo";
                }
                else if (date >= DateTime.Parse("23/08/2020") && date <= DateTime.Parse("22/09/2020"))
                {
                    sign = "Virgo";
                }
                else if (date >= DateTime.Parse("23/09/2020") && date <= DateTime.Parse("22/10/2020"))
                {
                    sign = "Libra";
                }
                else if (date >= DateTime.Parse("23/10/2020") && date <= DateTime.Parse("21/11/2020"))
                {
                    sign = "Scorpio";
                }
                else if (date >= DateTime.Parse("22/11/2020") && date <= DateTime.Parse("21/12/2020"))
                {
                    sign = "Sagittarius";
                }
                else if (date >= DateTime.Parse("22/12/2020") && date <= DateTime.Parse("31/12/2020"))
                {
                    sign = "Capricorn";
                }

                string dateTemp = date.ToString();
                string dateKey = dateTemp.Substring(0, dateTemp.LastIndexOf("-"));
                SunSignDictionary.Add(dateKey, sign);
            }
        }

        public static string GetSunSign(string date)
        {
            DateTime dateTemp = DateTime.Parse(date);
            date = dateTemp.ToShortDateString();

            return SunSignDictionary[date.Substring(0, date.LastIndexOf("-"))];
        }
    }
}
