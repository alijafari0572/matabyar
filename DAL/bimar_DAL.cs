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
    public class bimar_DAL
    {
        //CRUD: Create - Read - Update - Delete
        DAL_Bank db = new DAL_Bank();
        public string Create(bimar B)
        {
            if (!Read(B))
                if (B.codemeli.Length==10)
                {
                    db.bimars.Add(B);
                    db.SaveChanges();
                    return "ثبت اطلاعات بیمار با موفقیت انجام شد";
                }
                else
                {
                    return "کد ملی نامعتبر است";
                }
            else
            {
                return "اطلاعت وارد شده تکراری است";
            }
        }
        public List<bimar> Read()
        {
            return db.bimars.ToList();
        }
        public bool Read(bimar B)
        {
            return db.bimars.Any(i => i.name == B.name && i.family == B.family && i.codemeli==B.codemeli);
        }
        public List<bimar> Read(string name)
        {
            return db.bimars.Where(i => i.name == name).ToList();
        }
        public bimar Read(int id)
        {
            return db.bimars.Where(i => i.id == id).Single();
        }
        public string Update(int id,bimar Bnew)
        {
            bimar B = new bimar();
            B = Read(id);
            B.name = Bnew.name;
            B.family = Bnew.family;
            B.fathername = Bnew.fathername;
            B.codemeli = Bnew.codemeli;
            B.tell = Bnew.tell;
            B.mobile = Bnew.mobile;
            B.datesabt = Bnew.datesabt;
            db.SaveChanges();
            return "ویرایش اطلاعات با موفقیت انجام شد";
        }
        public string Delete(int id)
        {
            bimar B = Read(id);
            db.bimars.Remove(B);
            db.SaveChanges();
            return "حذف اطلاعت با موفقیت انجام شد";
        }
        public int Number()
        {
            return db.bimars.Count<bimar>();
        }
        public DataTable ReadSQL()
        {
            var select = "SELECT TOP(100) PERCENT id, codesabt AS[کد ثبت], name AS نام, family AS[نام خانوادگی], fathername AS[نام پدر], codemeli AS[کد ملی], mobile AS موبایل, tell AS[تلفن ثابت], datesabt AS[تاریخ ثبت] FROM dbo.bimars ORDER BY[کد ثبت]";
            var c = new SqlConnection("Data Source=DESKTOP-5MG1QOL;     Initial Catalog=shop1;Integrated Security=true"); // Your Connection String here"
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
    }
}
