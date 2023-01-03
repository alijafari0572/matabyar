using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class pazireshbimar
    {
        public int id { get; set; }
        public int codpaziresh { get; set; }
        public string noekhedmat { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public List<bimar> bimsrs { get; set; } = new List<bimar>();

    }
}
