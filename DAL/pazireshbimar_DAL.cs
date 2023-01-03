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
    public class pazireshbimar_DAL
    {

        //CRUD: Create - Read - Update - Delete
        DAL_Bank db = new DAL_Bank();
        public string Create(pazireshbimar P,int id)
        {
                {//ایجاد پذیرش
                    db.pazireshbimars.Add(P);
                    db.SaveChanges();
                   // return "ثبت اطلاعات بیمار با موفقیت انجام شد";
                }
            //ایجاد رابطه بین پذیرش و بیمار
            pazireshbimar P1 = db.pazireshbimars.Where(i => i.id == P.id).Single();
            bimar B = db.bimars.Where(i => i.id == id).Single();
            P1.bimsrs.Add(B);
            B.pazireshbimars.Add(P1);
            db.SaveChanges();
            return "ثبت اطلاعات بیمار با موفقیت انجام شد";
        }
        public List<pazireshbimar> Read()
        {
            return db.pazireshbimars.ToList();
        }
        //public bool Read(pazireshbimar P)
        //{
        //    return db.pazireshbimars.Any(i => i.name == B.name && i.family == B.family && i.codemeli == B.codemeli);
        //}
        public List<pazireshbimar> Read(string date)
        {
            return db.pazireshbimars.Where(i => i.date == date).ToList();
        }
        public pazireshbimar Read(int id)
        {
            return db.pazireshbimars.Where(i => i.id == id).Single();
        }
        //public string Update(int id, bimar Bnew)
        //{
        //    bimar B = new bimar();
        //    B = Read(id);
        //    B.name = Bnew.name;
        //    B.family = Bnew.family;
        //    B.fathername = Bnew.fathername;
        //    B.codemeli = Bnew.codemeli;
        //    B.tell = Bnew.tell;
        //    B.mobile = Bnew.mobile;
        //    B.datesabt = Bnew.datesabt;
        //    db.SaveChanges();
        //    return "ویرایش اطلاعات با موفقیت انجام شد";
        //}
        //public string Delete(int id)
        //{
        //    bimar B = Read(id);
        //    db.bimars.Remove(B);
        //    db.SaveChanges();
        //    return "حذف اطلاعت با موفقیت انجام شد";
        //}
        public int facodpaziresh(string date)
        {
           List<pazireshbimar> P = new List<pazireshbimar>();
           P = db.pazireshbimars.Where(i => i.date == date).ToList();
            return P.Count();
        }
        public DataTable ReadSQL()
        {
            var select = "SELECT TOP(100) PERCENT dbo.bimars.codesabt AS[کد ثبت], dbo.pazireshbimars.codpaziresh AS[کد پذیرش], dbo.bimars.name AS نام, dbo.bimars.family AS[نام خانوادگی], dbo.bimars.fathername AS[نام پدر], dbo.bimars.codemeli AS[کد ملی], dbo.bimars.mobile AS موبایل, dbo.bimars.tell AS تلفن, dbo.pazireshbimars.date FROM dbo.bimars INNER JOIN dbo.pazireshbimarbimars ON dbo.bimars.id = dbo.pazireshbimarbimars.bimar_id INNER JOIN dbo.pazireshbimars ON dbo.pazireshbimarbimars.pazireshbimar_id = dbo.pazireshbimars.id ORDER BY[کد پذیرش]";
            var c = new SqlConnection("Data Source=DESKTOP-5MG1QOL;     Initial Catalog=shop1;Integrated Security=true"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable ReadSQL(string date)
        {
            string str = "SELECT TOP (100) PERCENT dbo.bimars.codesabt AS[کد ثبت], dbo.pazireshbimars.codpaziresh AS[کد پذیرش], dbo.bimars.name AS نام, dbo.bimars.family AS[نام خانوادگی], dbo.bimars.fathername AS[نام پدر], dbo.bimars.codemeli AS[کد ملی], dbo.bimars.mobile AS موبایل, dbo.bimars.tell AS تلفن, dbo.pazireshbimars.date FROM dbo.bimars INNER JOIN dbo.pazireshbimarbimars ON dbo.bimars.id = dbo.pazireshbimarbimars.bimar_id INNER JOIN dbo.pazireshbimars ON dbo.pazireshbimarbimars.pazireshbimar_id = dbo.pazireshbimars.id WHERE(dbo.pazireshbimars.date = N'" + date +"') ORDER BY[کد پذیرش]";
            var select = str;
            var c = new SqlConnection("Data Source=DESKTOP-5MG1QOL;     Initial Catalog=shop1;Integrated Security=true"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
    }
}
