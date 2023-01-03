using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace pro_term1
{
    public partial class Reservtime : UserControl
    {
        public Reservtime()
        {
            InitializeComponent();
        }
        bimar_BLL bll = new bimar_BLL();
        reservbimar_BLL rbll = new reservbimar_BLL();
        static public int id;//ایدی بیمار
        public int CP;

        private void Reservtime_Load(object sender, EventArgs e)
        {
            PersianDateTime now = PersianDateTime.Now;
            TimeSpan persianTime = now.TimeOfDay;
            string persianFullDateTime = now.ToString("hh:mm"); // پنج شنبه 9 خرداد 1392 ساعت 11:37:57 ب.ظ
            guna2TextBox2.Text = persianFullDateTime;
            bPersianCalenderTextBox1.Today_Click(null, null);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            sabtbimar form = new sabtbimar();
            form.ShowDialog(); // or form.ShowDialog(this);
                               //bimar B = new bimar();
            if (id > 0)
            {
                //پر شدن قسمت های اطلاعت بیمار
                bimar B = bll.Read(id);
                guna2TextBox9.Text = Convert.ToString(B.codesabt);
                guna2TextBox3.Text = B.name;
                guna2TextBox4.Text = B.family;
                //guna2TextBox5.Text = B.fathername;
                guna2TextBox6.Text = B.mobile;
                guna2TextBox7.Text = B.tell;
                guna2TextBox5.Text = B.codemeli;
                // پر شدن اطلاعت در قسمت رزرو
                reservbimar R = new reservbimar();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            reservbimar R = new reservbimar();
            CP = rbll.facodreserv(bPersianCalenderTextBox1.Text) + 1;
            guna2TextBox1.Text = Convert.ToString(CP);
            R.codreserv = CP;
            R.date = bPersianCalenderTextBox1.Text;
            R.time = guna2TextBox2.Text;
            //Create
            MessageBox.Show(rbll.Create(R, id));
            // استخراج ایدی پذیرش انجام شده
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            listreserv form = new listreserv();
            form.ShowDialog();
        }
    }
}
