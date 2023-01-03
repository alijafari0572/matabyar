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
    public class bime_BLL
    {
        bime_DAL DAL = new bime_DAL();
        public string Create(bime Bi)
        {
            return DAL.Create(Bi);
        }
        public List<bime> Read()
        {
            return DAL.Read();
        }
        public bime Read(int id)
        {
            return DAL.Read(id);
        }
        public List<bime> Read(string name)
        {
            return DAL.Read(name);
        }
        public string Update(int id, bime Binew)
        {
            return DAL.Update(id, Binew);
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
