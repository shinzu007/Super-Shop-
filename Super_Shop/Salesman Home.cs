using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Shop
{
    public partial class Salesman_Home : Form
    {
        PasswordChange p;
        public Salesman_Home()
        {
            InitializeComponent();
        }
        public Salesman_Home(PasswordChange p)
        {
            InitializeComponent();
            this.p = p;
           
        }
        public Salesman_Home( string nm)
        {
            InitializeComponent();
      
            label28.Text = nm;
        }


        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn l = new LogIn();
            l.Show();
            this.Hide();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information f1 = new Information();
            f1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LogIn l = new LogIn();
            l.Show();
            this.Hide();
            }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nm = label28.Text;
            PasswordChangeS p3 = new PasswordChangeS(this,nm);
            p3.Show();
            this.Hide();
        }

        private void Salesman_Home_Load(object sender, EventArgs e)
        {

        }

        private void rectangleShape4_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void homeDelivaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeDelivary hm = new HomeDelivary(this, label28.Text);
            hm.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
