﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class tazrigh_DAL
    {
        //CRUD: Create - Read - Update - Delete
        DAL_Bank db = new DAL_Bank();
        public string Create(tazrigh TB, int id)
        {
            {//ایجاد رزرو
                db.tazrighs.Add(TB);
                db.SaveChanges();
                // return "ثبت اطلاعات بیمار با موفقیت انجام شد";
            }
            //ایجاد رابطه بین رزرو و بیمار
            tazrigh TB1 = db.tazrighs.Where(i => i.id == TB.id).Single();
            bimar B = db.bimars.Where(i => i.id == id).Single();
            TB1.bimsrs.Add(B);
            B.tazrighs.Add(TB1);
            db.SaveChanges();
            return "ثبت اطلاعات بیمار با موفقیت انجام شد";
        }
        public List<tazrigh> Read()
        {
            return db.tazrighs.ToList();
        }
        //public bool Read(reservbimar R)
        //{
        //    return db.reservbimars.Any(i => i.name == B.name && i.family == B.family && i.codemeli == B.codemeli);
        //}
        public List<tazrigh> Read(string date)
        {
            return db.tazrighs.Where(i => i.date == date).ToList();
        }
        public tazrigh Read(int id)
        {
            return db.tazrighs.Where(i => i.id == id).Single();
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
        public int facodtazrigh(string date)
        {
            List<tazrigh> P = new List<tazrigh>();
            P = db.tazrighs.Where(i => i.date == date).ToList();
            return P.Count();
        }
        public DataTable ReadSQL()
        {
            var select = "SELECT TOP(100) PERCENT dbo.bimars.id, dbo.bimars.codesabt AS[کد ثبت], dbo.reservbimars.codreserv AS[کد رزرو], dbo.bimars.name AS نام, dbo.bimars.family AS[نام خانوادگی], dbo.bimars.codemeli AS[کد ملی], dbo.bimars.mobile AS موبایل, dbo.bimars.tell AS تلفن, dbo.reservbimars.date AS تاریخ FROM dbo.bimars INNER JOIN dbo.reservbimarbimars ON dbo.bimars.id = dbo.reservbimarbimars.bimar_id INNER JOIN dbo.reservbimars ON dbo.reservbimarbimars.reservbimar_id = dbo.reservbimars.id ORDER BY[کد رزرو]";
            var c = new SqlConnection("Data Source=DESKTOP-5MG1QOL;     Initial Catalog=shop1;Integrated Security=true"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable ReadSQL(string date)
        {
            string str = "SELECT dbo.bimars.id, dbo.bimars.codesabt AS[کد ثبت], dbo.reservbimars.codreserv AS[کد رزرو], dbo.bimars.name AS نام, dbo.bimars.family AS[نام خانوادگی], dbo.bimars.codemeli AS[کد ملی], dbo.bimars.mobile AS موبایل, dbo.bimars.tell AS تلفن, dbo.reservbimars.date AS تاریخ FROM dbo.bimars INNER JOIN dbo.reservbimarbimars ON dbo.bimars.id = dbo.reservbimarbimars.bimar_id INNER JOIN dbo.reservbimars ON dbo.reservbimarbimars.reservbimar_id = dbo.reservbimars.id WHERE(dbo.reservbimars.date = N'" + date + "')";
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
