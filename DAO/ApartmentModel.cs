using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DAO
{
    class ApartmentModel
    {
        public string apartId { get; set; }
        public double price { get; set; }
        public double area { get; set; }
        public string note { get; set; }
        public bool status { get; set; }
        public string familyId { get; set; }
        public string familyName { get; set; }
        public int numberMember { get; set; }
    }
}
