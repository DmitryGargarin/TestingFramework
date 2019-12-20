using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameWork.Models
{
    class FlightModel
    {
        public string destinationCity;
        public string departureCity;

        public FlightModel(string dest, string dep)
        {
            destinationCity = dest;
            departureCity = dep;
        }
    }
}
