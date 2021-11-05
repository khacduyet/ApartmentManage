using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DAO
{
    class ServiceBillModel
    {
        public string id { get; set; }
        public string note { get; set; }
        public double total { get; set; }
        public string empName { get; set; }
        public string familyId { get; set; }
        public string familyName { get; set; }
    }
}
