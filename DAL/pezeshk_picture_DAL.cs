using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class pezeshk_picture_DAL
    {
        DAL_Bank db = new DAL_Bank();
        public string create(pezeshk_picture PP)
        {
            db.pezeshk_pictures.Add(PP);
            db.SaveChanges();
            return "ثبت اطلاعات بیمار با موفقیت انجام شد";
        }
        public List<pezeshk_picture> Read()
        {
            return db.pezeshk_pictures.ToList();
        }

        public pezeshk_picture Read(int id)
        {
            string idd = Convert.ToString(id);
            return db.pezeshk_pictures.Where(i => i.codsabtpezeshk == idd).SingleOrDefault();
        }
    }
}
