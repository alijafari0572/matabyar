using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BE;

namespace DAL
{
    public class DAL_Bank : DbContext
    {
        public DAL_Bank() : base("pro_term1") { }
        public DbSet<bimar> bimars { get; set; }
        public DbSet<pazireshbimar> pazireshbimars { get; set; }
        public DbSet< reservbimar> reservbimars { get; set; }
        public DbSet<tazrigh>tazrighs { get; set;}
        public DbSet<daro> daros { get; set; }
        public DbSet<bimar_picture> bimar_pictures { get; set; }
        public DbSet<pezeshk> pezeshks { get; set; }
        public DbSet<pezeshk_picture> pezeshk_pictures { get; set; }
        public DbSet<bime> bimes { get; set; }
    }
}
