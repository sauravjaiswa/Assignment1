using System.Threading.Tasks;

namespace Assignment1
{
    public interface IHoroscope : ISunSign
    {
        Task GetHoroscope();
    }
}
