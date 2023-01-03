using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class bimar_picture_DAL
    {
        DAL_Bank db = new DAL_Bank();
        public string create(bimar_picture BP)
        {
            db.bimar_pictures.Add(BP);
            db.SaveChanges();
            return "ثبت اطلاعات بیمار با موفقیت انجام شد";
        }
        public List<bimar_picture> Read()
        {
            return db.bimar_pictures.ToList();
        }

        public bimar_picture Read(int id)
        {
           string idd = Convert.ToString(id);
            return db.bimar_pictures.Where(i => i.codsabtbimar == idd).SingleOrDefault();
        }
    }
}
