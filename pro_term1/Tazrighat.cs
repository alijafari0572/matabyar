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
    public partial class Tazrighat : UserControl
    {
        public Tazrighat()
        {
            InitializeComponent();
        }
        bimar_BLL bll = new bimar_BLL();
        tazrigh_BLL tzll = new tazrigh_BLL();
        static public int id;//ایدی بیمار
        public int CP;
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
               
            }
        }

        private void Tazrighat_Load(object sender, EventArgs e)
        {
            PersianDateTime now = PersianDateTime.Now;
            TimeSpan persianTime = now.TimeOfDay;
            string persianFullDateTime = now.ToString("hh:mm"); // پنج شنبه 9 خرداد 1392 ساعت 11:37:57 ب.ظ
            guna2TextBox2.Text = persianFullDateTime;
            bPersianCalenderTextBox1.Today_Click(null, null);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tazrigh TB = new tazrigh();
            CP =tzll.facodtazrigh(bPersianCalenderTextBox1.Text) + 1;
            guna2TextBox1.Text = Convert.ToString(CP);
            TB.codtazrigh = CP;
            TB.date = bPersianCalenderTextBox1.Text;
            TB.time = guna2TextBox2.Text;

            //Create
            MessageBox.Show(tzll.Create(TB, id));

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void bPersianCalenderTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
