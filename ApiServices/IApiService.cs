using Refit;
using System.Threading.Tasks;

namespace Assignment1
{
    [Headers(new string[] { "Content-type: application/json",
                            "x-rapidapi-key: d38d73d424msh39e37145a05b762p1aa05fjsnae1b946853fa",
                            "x-rapidapi-host: sameer-kumar-aztro-v1.p.rapidapi.com" })]
    public interface IApiService
    {
        [Post("")]
        Task<HoroscopeModel> GetHoroscopeAsync([Query] string sign, [Query] string day = "today");
    }
}
