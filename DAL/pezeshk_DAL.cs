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
    public class pezeshk_DAL
    {
        //CRUD: Create - Read - Update - Delete
        DAL_Bank db = new DAL_Bank();
        public string Create(pezeshk P)
        {
            if (!Read(P))
                if (P.cod_melli.Length == 10)
                {
                    db.pezeshks.Add(P);
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
        public List<pezeshk> Read()
        {
            return db.pezeshks.ToList();
        }
        public bool Read(pezeshk P)
        {
            return db.pezeshks.Any(i => i.name == P.name && i.nezam == P.nezam);
        }
        public List<pezeshk> Read(string name)
        {
            return db.pezeshks.Where(i => i.name == name).ToList();
        }
        public pezeshk Read(int id)
        {
            return db.pezeshks.Where(i => i.id == id).Single();
        }
        public string Update(int id, pezeshk Pnew)
        {
            pezeshk P = new pezeshk();
            P = Read(id);
            P.sex = Pnew.sex;
            P.name = Pnew.name;
            P.nezam = Pnew.nezam;
            P.cod_melli = Pnew.cod_melli;
            P.bearthday = Pnew.bearthday;
            P.General_or_specialist = Pnew.General_or_specialist;
            P.specialist_name = Pnew.specialist_name;
            P.tell = Pnew.tell;
            P.mobile = Pnew.mobile;
            P.Email = Pnew.Email;
            P.website = Pnew.website;
            P.whats_all = Pnew.whats_all;
            db.SaveChanges();
            return "ویرایش اطلاعات با موفقیت انجام شد";
        }
        public string Delete(int id)
        {
            pezeshk P = Read(id);
            db.pezeshks.Remove(P);
            db.SaveChanges();
            return "حذف اطلاعت با موفقیت انجام شد";
        }
        public int Number()
        {
            return db.pezeshks.Count<pezeshk>();
        }
        public DataTable ReadSQL()
        {
            var select = "SELECT TOP(100) PERCENT id, codpezeshk AS[کد پزشک], sex AS جنسیت, name AS[نام و نام خانوادگی], nezam AS نظام, cod_melli AS[کد ملی], General_or_specialist AS[عمومی یا متخصص], specialist_name AS تخصص, tell AS تلفن, mobile AS موبایل, Email AS ایمیل, website AS وبسایت, whats_all AS توضیحات, bearthday AS[تاریخ تولد] FROM dbo.pezeshks ORDER BY[کد پزشک]";  
            var c = new SqlConnection("Data Source=DESKTOP-5MG1QOL;     Initial Catalog=shop1;Integrated Security=true"); // Your Connection String here"
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
    }
}
