using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class bime_DAL
    {
        //CRUD: Create - Read - Update - Delete
        DAL_Bank db = new DAL_Bank();
        public string Create(bime Bi)
        {
            if (!Read(Bi))
            {
                db.bimes.Add(Bi);
                db.SaveChanges();
                return "ثبت اطلاعات بیمار با موفقیت انجام شد";
            }   
            else
            {
                return "اطلاعت وارد شده تکراری است";
            }
        }
        public List<bime> Read()
        {
            return db.bimes.ToList();
        }
        public bool Read(bime Bi)
        {
            return db.bimes.Any(i => i.name == Bi.name);
        }
        public List<bime> Read(string name)
        {
            return db.bimes.Where(i => i.name == name).ToList();
        }
        public bime Read(int id)
        {
            return db.bimes.Where(i => i.id == id).Single();
        }
        public string Update(int id, bime Binew)
        {
            bime Bi = new bime();
            Bi = Read(id);
            Bi.codbime = Binew.codbime;
            Bi.codbime_marcaz = Binew.codbime_marcaz;
            Bi.name = Binew.name;
            Bi.tarefemotakhses = Binew.tarefemotakhses;
            Bi.tarefeomomi = Binew.tarefeomomi;
            Bi.what = Bi.what;
            db.SaveChanges();
            return "ویرایش اطلاعات با موفقیت انجام شد";
        }
        public string Delete(int id)
        {
            bime Bi = Read(id);
            db.bimes.Remove(Bi);
            db.SaveChanges();
            return "حذف اطلاعت با موفقیت انجام شد";
        }
        public int Number()
        {
            return db.bimes.Count<bime>();
        }
        public DataTable ReadSQL()
        {
            var select = "SELECT TOP (100) PERCENT id, codbime AS [کد بیمه], codbime_marcaz AS [کد مرکز بیمه], name AS [نام بیمه], tarefeomomi AS [تعرفه عمومی], tarefemotakhses AS [تعرفه متخصص] FROM dbo.bimes ORDER BY[کد بیمه]";
            var c = new SqlConnection("Data Source=DESKTOP-5MG1QOL;     Initial Catalog=shop1;Integrated Security=true"); // Your Connection String here"
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
    }
}
