using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class pezeshk
    {
        public int id { get; set; }
        public int codpezeshk { get; set; }
        public string sex { get; set; }
        public string name { get; set; }
        public string nezam { get; set; }
        public string cod_melli { get; set; }
        public string bearthday { get; set; }
        public string General_or_specialist { get; set; }
        public string specialist_name { get; set; }
        public string tell { get; set; }
        public string mobile { get; set; }
        public string Email { get; set; }
        public string website { get; set; }
        public string whats_all { get; set; }
        public List<bimar> bimars { get; set; } = new List<bimar>();
    }
}
