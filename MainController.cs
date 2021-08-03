using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class MainController
    {
        private readonly IDateOfBirth _dob;

        public MainController(IDateOfBirth dob)
        {
            _dob = dob;
        }

        public void DisplayResult()
        {
            _dob.Display();
        }
    }
}
