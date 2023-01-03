using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_term1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            paziresh s = new paziresh();
            panel2.Controls.Clear();
            panel2.Controls.Add(s);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PersianDateTime now = PersianDateTime.Now;
            string persianFullDateTime = now.ToString("dddd d MMMM yyyy ساعت hh:mm:ss tt");
            label1.Text = persianFullDateTime;
            label1.Font = new Font("",15);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Reservtime s = new Reservtime();
            panel2.Controls.Clear();
            panel2.Controls.Add(s);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Tazrighat s = new Tazrighat();
            panel2.Controls.Clear();
            panel2.Controls.Add(s);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Tanzimat s = new Tanzimat();
            panel2.Controls.Clear();
            panel2.Controls.Add(s);
        }
    }
}
