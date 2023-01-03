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
     public class pazireshbimar_BLL
    {
        pazireshbimar_DAL DAL = new pazireshbimar_DAL();
        public string Create(pazireshbimar P,int id)
        {
            return DAL.Create(P,id);
        }

        public int facodpaziresh(string date)
        {
            return DAL.facodpaziresh(date);
        }

        public static implicit operator pazireshbimar_BLL(pazireshbimar v)
        {
            throw new NotImplementedException();
        }
        public List<pazireshbimar> Read()
        {
            return DAL.Read().ToList();
        }
        public List<pazireshbimar> Read(string date)
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
