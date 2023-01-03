using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class bimar_picture_BLL
    {
        bimar_picture_DAL DAL = new bimar_picture_DAL();

        public string Create(bimar_picture BP)
        {
            return DAL.create(BP);
        }
        public List<bimar_picture> Read()
        {
            return DAL.Read();
        }
        public bimar_picture Read(int id)
        {
            return DAL.Read(id);
        }
    }
}
