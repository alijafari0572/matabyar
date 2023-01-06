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
    public class bimar_BLL
    {
        bimar_DAL DAL = new bimar_DAL();
        public string Create(bimar B)
        {
            return DAL.Create(B);
        }
        public List<bimar> Read()
        {
            return  DAL.Read();
        }
        public bimar Read(int id)
        {
            return DAL.Read(id);
        }
        public List<bimar> Read(string name)
        {
            return DAL.Read(name);
        }
        public string Update(int id, bimar Bnew)
        {
            return DAL.Update(id, Bnew);
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
