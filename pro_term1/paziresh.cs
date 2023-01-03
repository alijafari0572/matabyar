﻿using System;
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
using System.IO;

namespace pro_term1
{
    public partial class paziresh : UserControl
    {
        public paziresh()
        {
            InitializeComponent();
        }
        bimar_BLL bll = new bimar_BLL();
        pazireshbimar_BLL pbll = new pazireshbimar_BLL();
        bimar_picture_BLL bpll = new bimar_picture_BLL();
        static public int id;//ایدی بیمار
        static public int PBid;//ایدی پذیرش بیمار
        public int CP;
        private void paziresh_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            PersianDateTime now = PersianDateTime.Now;
            TimeSpan persianTime = now.TimeOfDay;
            string persianFullDateTime = now.ToString("hh:mm"); // پنج شنبه 9 خرداد 1392 ساعت 11:37:57 ب.ظ
            guna2TextBox2.Text = persianFullDateTime;
            bPersianCalenderTextBox1.Today_Click(null, null);

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            sabtnoskhe form = new sabtnoskhe();
            form.Show(); // or form.ShowDialog(this);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            sabtbimar form = new sabtbimar();
            form.ShowDialog(); // or form.ShowDialog(this);
            //bimar B = new bimar();
            if (id>0)
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
                // پر شدن اطلاعت در قسمت پذیرش
                
                pazireshbimar P = new pazireshbimar();
                CP = pbll.facodpaziresh(bPersianCalenderTextBox1.Text) + 1;
                P.codpaziresh = CP;
                guna2TextBox1.Text= Convert.ToString(CP);
                P.date = bPersianCalenderTextBox1.Text;
                P.time = guna2TextBox2.Text;
                //پر کردن عکس بیمار
                bimar_picture BP = bpll.Read(B.codesabt);
                guna2CirclePictureBox1.Image = Image.FromFile(BP.pictureAddress);

                

            }

            



        }

        private void bPersianCalenderTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            pazireshbimar P = new pazireshbimar();
            P.codpaziresh = CP;
            P.noekhedmat = comboBox1.Text;
            P.date = bPersianCalenderTextBox1.Text;
            P.time = guna2TextBox2.Text;
            //Create
            MessageBox.Show(pbll.Create(P,id));
            // استخراج ایدی پذیرش انجام شده

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            listpaziresh form = new listpaziresh();
            form.ShowDialog();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
