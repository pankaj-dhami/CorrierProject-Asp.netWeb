using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourrierBO.Model
{
    class ParcelDetails
    {
        public int ParcelId { get; set; }
        public int ParcelType { get; set; }
        public decimal Weight { get; set; }
        public decimal Width { get; set; }
        public decimal Breadth { get; set; }
        public decimal Height { get; set; }
    }
}
