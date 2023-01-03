using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class tazrigh
    {
        public int id { get; set; }
        public int codtazrigh { get; set; }//نفر چندم هست
        public string date { get; set; }
        public string time { get; set; }
        public List<bimar> bimsrs { get; set; } = new List<bimar>();
        public List<daro> daros { get; set; } = new List<daro>();//1=>N rite

    }
}
