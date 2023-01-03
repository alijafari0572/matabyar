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
    public class reservbimar_BLL
    {
        reservbimar_DAL DAL = new reservbimar_DAL();
        public string Create(reservbimar R, int id)
        {
            return DAL.Create(R, id);
        }

        public int facodreserv(string date)
        {
            return DAL.facodreserv(date);
        }

        //public static implicit operator pazireshbimar_BLL(pazireshbimar v)
        //{
        //    throw new NotImplementedException();
        //}
        public List<reservbimar> Read()
        {
            return DAL.Read().ToList();
        }
        public List<reservbimar> Read(string date)
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

        public static implicit operator reservbimar_BLL(pazireshbimar_BLL v)
        {
            throw new NotImplementedException();
        }
    }
}
