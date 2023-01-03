using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using System.IO;

namespace pro_term1
{
    public partial class moshakhsat_pezeshk : Form
    {
        public moshakhsat_pezeshk()
        {
            InitializeComponent();
        }
        public Form form = new Form();
        pezeshk_BLL Pbll = new pezeshk_BLL();
        pezeshk_picture_BLL Ppll = new pezeshk_picture_BLL();
        public bool flag;
        public int idP;
        OpenFileDialog f = new OpenFileDialog();
        Image Pic;
        private void moshakhsat_pezeshk_Load(object sender, EventArgs e)
        {
            PersianDateTime now = PersianDateTime.Now;
            TimeSpan persianTime = now.TimeOfDay;
            string persianFullDateTime = now.ToString("hh:mm"); // پنج شنبه 9 خرداد 1392 ساعت 11:37:57 ب.ظ
            bPersianCalenderTextBox1.Today_Click(null, null);
            if (flag)
            {
                guna2TextBox2.Text = (Convert.ToString(Pbll.Number() + 1001));
            }



            else if (!flag)
            {
                pezeshk P = Pbll.Read(idP);
                guna2TextBox1.Text = P.name;
                guna2TextBox2.Text = Convert.ToString(P.codpezeshk);
                guna2TextBox3.Text = P.nezam;
                guna2TextBox4.Text = P.cod_melli;
                guna2TextBox5.Text = P.tell;
                guna2TextBox7.Text = P.mobile;
                guna2TextBox8.Text = P.Email;
                guna2TextBox9.Text = P.website;
                richTextBoxEx1.Text = P.whats_all;
                guna2ComboBox1.Text = P.sex;
                guna2ComboBox2.Text = P.General_or_specialist;
                guna2ComboBox3.Text = P.specialist_name;
                maskedTextBox1.Text = P.bearthday;

                //
                guna2Button3.Text = "ویرایش";

            }
        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void labelX9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            pezeshk P = new pezeshk();
            //bimar_picture BP = new bimar_picture();

            P.codpezeshk = Convert.ToInt32(guna2TextBox2.Text);
            P.name = guna2TextBox1.Text;
            P.nezam = guna2TextBox3.Text;
            P.cod_melli = guna2TextBox4.Text;
            P.tell = guna2TextBox5.Text;
            P.mobile = guna2TextBox7.Text;
            P.Email = guna2TextBox8.Text;
            P.website = guna2TextBox9.Text;
            P.sex = guna2ComboBox1.Text;
            P.General_or_specialist = guna2ComboBox2.Text;
            P.specialist_name = guna2ComboBox3.Text;
            P.bearthday = maskedTextBox1.Text;
            P.whats_all = richTextBoxEx1.Text;
            //ذخیره تصویر
            //BP.Name = guna2TextBox2.Text + guna2TextBox3.Text;
            //BP.codsabtbimar = guna2TextBox1.Text;
            //BP.pictureAddress = SavePic(guna2TextBox1.Text);

            if (flag)
            {
                //Create
                MessageBox.Show(Pbll.Create(P));
                //MessageBox.Show(bpll.Create(BP));
                //رفرش دیتا گرید
                ((sabtpezeshk)Application.OpenForms["sabtpezeshk"]).dataGridViewX1.DataSource = Pbll.Read().ToList(); ;
                this.Close();


            }
            else if (!flag)
            {
                //Update
                MessageBox.Show(Pbll.Update(idP, P));
                //رفرش دیتا گرید 
                ((sabtpezeshk)Application.OpenForms["sabtpezeshk"]).dataGridViewX1.DataSource = Pbll.Read().ToList(); ;
                this.Close();
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void moshakhsat_pezeshk_FormClosing(object sender, FormClosingEventArgs e)
        {
            sabtpezeshk frm = new sabtpezeshk();// refresh datagridview
            frm.RefreshGrid();
        }
    }
}
