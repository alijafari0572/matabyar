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
    public partial class moshakhsat_bimar : Form
    {
        public moshakhsat_bimar()
        {
            InitializeComponent();
        }
        public Form form = new Form();
        bimar_BLL bll = new bimar_BLL();
        bimar_picture_BLL bpll = new bimar_picture_BLL();
        public bool flag;
        public int id;
        OpenFileDialog f = new OpenFileDialog();
        Image Pic;
        private void moshakhsat_bimar_Load(object sender, EventArgs e)
        {
            PersianDateTime now = PersianDateTime.Now;
            TimeSpan persianTime = now.TimeOfDay;
            string persianFullDateTime = now.ToString("hh:mm"); // پنج شنبه 9 خرداد 1392 ساعت 11:37:57 ب.ظ
            bPersianCalenderTextBox1.Today_Click(null, null);
            if (flag)
            {
                guna2TextBox1.Text= (Convert.ToString(bll.Number()+1001));
            }



            else if (!flag)
            {
                bimar B = bll.Read(id);
                guna2TextBox1.Text =Convert.ToString(B.codesabt);
                guna2TextBox2.Text = B.name;
                guna2TextBox3.Text = B.family;
                guna2TextBox4.Text = B.fathername;
                guna2TextBox5.Text = B.mobile;
                guna2TextBox6.Text = B.tell;
                guna2TextBox7.Text = B.codemeli;

                //
                guna2Button3.Text = "ویرایش";

            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void moshakhsat_bimar_FormClosing(object sender, FormClosingEventArgs e)
        {
            sabtbimar frm = new sabtbimar();// refresh datagridview
            frm.RefreshGrid();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        string SavePic(string code)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Pictures\";
            if (Directory.Exists(appPath) == false)
            {
                Directory.CreateDirectory(appPath);
            }
            string iName = code + ".jpg";
            try
            {
                // <---
                string filepath = f.FileName;    // <---
                File.Copy(filepath, appPath + iName); // <---

            }
            catch (Exception exp)
            {
                MessageBox.Show("Unable to save file " + exp.Message);
            }
            return appPath + iName;
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            bimar B = new bimar();
            bimar_picture BP = new bimar_picture();

            B.codesabt = Convert.ToInt32(guna2TextBox1.Text);
            B.name = guna2TextBox2.Text;
            B.family = guna2TextBox3.Text;
            B.fathername = guna2TextBox4.Text;
            B.mobile = guna2TextBox5.Text;
            B.tell = guna2TextBox6.Text;
            B.codemeli = guna2TextBox7.Text;
            B.datesabt = bPersianCalenderTextBox1.Text;
            //ذخیره تصویر
            BP.Name= guna2TextBox2.Text+ guna2TextBox3.Text;
            BP.codsabtbimar = guna2TextBox1.Text;
            BP.pictureAddress = SavePic(guna2TextBox1.Text);

            if (flag)
            {
                //Create
                MessageBox.Show(bll.Create(B));
                MessageBox.Show(bpll.Create(BP));
                //رفرش دیتا گرید
                ((sabtbimar)Application.OpenForms["sabtbimar"]).dataGridViewX1.DataSource = bll.Read().ToList(); ;
                this.Close();


            }
            else if (!flag)
            {
                //Update
                MessageBox.Show(bll.Update(id, B));
                //رفرش دیتا گرید 
                ((sabtbimar)Application.OpenForms["sabtbimar"]).dataGridViewX1.DataSource = bll.Read().ToList(); ;
                this.Close();
            }

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            f.Filter = "JPG(*.JPG)|*.JPG";

            if (f.ShowDialog() == DialogResult.OK)
            {
                Pic = Image.FromFile(f.FileName);
                guna2CirclePictureBox1.Image = Pic;
            }
        }

        private void tabControlPanel1_Click(object sender, EventArgs e)
        {

        }

        private void labelX32_Click(object sender, EventArgs e)
        {

        }

        private void tabControlPanel3_Click(object sender, EventArgs e)
        {

        }

        
    }
}
