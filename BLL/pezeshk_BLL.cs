using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using System.Data;

namespace BLL
{
    public class pezeshk_BLL
    {
        pezeshk_DAL DAL = new pezeshk_DAL();
        public string Create(pezeshk P)
        {
            return DAL.Create(P);
        }
        public List<pezeshk> Read()
        {
            return DAL.Read();
        }
        public pezeshk Read(int id)
        {
            return DAL.Read(id);
        }
        public List<pezeshk> Read(string name)
        {
            return DAL.Read(name);
        }
        public string Update(int id, pezeshk Pnew)
        {
            return DAL.Update(id, Pnew);
        }
        public string Delet(int id)
        {
            return DAL.Delete(id);
        }
        public int Number()
        {
            return DAL.Number();
        }
        public DataTable ReadSQL()
        {
            return DAL.ReadSQL();
        }
    }
}
