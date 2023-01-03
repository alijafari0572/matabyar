using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class pezeshk_picture_BLL
    {
        pezeshk_picture_DAL DAL = new pezeshk_picture_DAL();

        public string Create(pezeshk_picture PP)
        {
            return DAL.create(PP);
        }
        public List<pezeshk_picture> Read()
        {
            return DAL.Read();
        }
        public pezeshk_picture Read(int id)
        {
            return DAL.Read(id);
        }

        public static implicit operator pezeshk_picture_BLL(bimar_picture_BLL v)
        {
            throw new NotImplementedException();
        }
    }
}
