using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourrierBO.Model
{
    class City
    {
         public int CityId { get; set; }
         public string City { get; set; }
         public int Country { get; set; }
         public int State { get; set; }
         public int PinCode { get; set; }

    }
}
