using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_term1
{
    public partial class Tanzimat : UserControl
    {
        public Tanzimat()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            sabtpezeshk form = new sabtpezeshk();
            form.ShowDialog(); // or form.ShowDialog(this);
            //bimar B = new bimar();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            sabtbime form = new sabtbime();
            form.ShowDialog(); // or form.ShowDialog(this);
            //bimar B = new bimar();
        }
    }
}
