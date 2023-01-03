using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class tazrigh_BLL
    {
        tazrigh_DAL DAL = new tazrigh_DAL();
        public string Create(tazrigh TB, int id)
        {
            return DAL.Create(TB, id);
        }

        public int facodtazrigh(string date)
        {
            return DAL.facodtazrigh(date);
        }

        public List<tazrigh> Read()
        {
            return DAL.Read().ToList();
        }
        public List<tazrigh> Read(string date)
        {
            return DAL.Read(date);
        }
        public DataTable ReadSQL()
        {
            return DAL.ReadSQL();
        }
        public DataTable ReadSQL(string date)
        {
            return DAL.ReadSQL(date);
        }
    }
}
