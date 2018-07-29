using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Shop
{
    public partial class HomeDelivary : MetroFramework.Forms.MetroForm
    {
        DataTable t = new DataTable();
        DataTable t1 = new DataTable();
        Salesman_Home shm;
        Databasecon db = new Databasecon();
        string pp="1";
        string pp1="1";
        string radio;
        int cc; int cc1;
        public HomeDelivary()
        {
            InitializeComponent();
        }
        public HomeDelivary(Salesman_Home shm,string ss)
        {
            InitializeComponent();
            this.shm = shm;
            label3.Text = ss;
            label5.Hide();

            t.Rows.Clear();
            dataGridView1.DataSource = t;
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# pro\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();

            string sl = string.Format("SELECT * FROM Orderdetails");

            SqlCommand s = new SqlCommand(sl, con1);

            SqlDataAdapter dt = new SqlDataAdapter(s);
            dt.Fill(t);
            dataGridView1.DataSource = t;
           

        }

        private void HomeDelivary_Load(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            shm.Show();
            this.Hide();
        }

        private void HomeDelivary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {


           
            bool isChecked = radioButton1.Checked;
            bool ischeck1 = radioButton2.Checked;
            if (isChecked)
            {
                radio = radioButton1.Text;
            }
            else if (ischeck1)
            {
                radio = radioButton2.Text;
            }
            else
            {
                radio = "Unserved";
            }
            if (pp.Equals("1"))
            {
                label5.Show();
            }
            else
            {
                timer1.Start();
                cc = db.UpdateOrderDetailsForSalesman(pp, radio);
                cc1 = db.UpdateOrderInfoForSalesman(pp, radio);
                label5.Hide();
                
            }
          

           /* t1.Rows.Clear();
            dataGridView2.DataSource = t1;
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jahin\Documents\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();

            string sl = string.Format("SELECT * FROM Orderinfo1 where OId ='{0}' Or CId='{1}'",textBox1.Text,textBox1.Text);

            SqlCommand s = new SqlCommand(sl, con1);

            SqlDataAdapter dt = new SqlDataAdapter(s);
            dt.Fill(t1);
            dataGridView2.DataSource = t1;*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
            string n = dataGridView1.SelectedCells[0].Value.ToString();
            
            int len=n.Length;
            string m=n.Substring(1,1);
            string m1 = n.Substring(0,len);
            if (m.Equals("-"))
            {
                pp = dataGridView1.SelectedCells[0].Value.ToString();
               //label5.Hide();
                //order details show

                t1.Rows.Clear();
                dataGridView2.DataSource = t1;
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# pro\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                con1.Open();

                string sl = string.Format("SELECT * FROM Orderinfo1 where OId ='{0}' Or CId='{1}'",pp, pp);

                SqlCommand s = new SqlCommand(sl, con1);

                SqlDataAdapter dt = new SqlDataAdapter(s);
                dt.Fill(t1);
                dataGridView2.DataSource = t1;
               // label5.Hide();
                //textBox1.Clear();
            }
            else if (m1.Equals("unserved") || m.Equals("-"))
            {
                if (m.Equals("-"))
                {
                    pp1 = dataGridView1.SelectedCells[0].Value.ToString();
                }
                button2.Text = "Served Order Now";
               // label5.Hide();
                t1.Rows.Clear();
                //textBox1.Enabled = false;
            }
            else
            {
                ///label5.Show();
                t1.Rows.Clear();
               //textBox1.Clear();
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.DeleteOrderDetailsForSalesman(pp);
            db.DeleteOrderInfoForSalesman(pp);

            t.Rows.Clear();
            dataGridView1.DataSource = t;
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# pro\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();

            string sl = string.Format("SELECT * FROM Orderdetails");

            SqlCommand s = new SqlCommand(sl, con1);

            SqlDataAdapter dt = new SqlDataAdapter(s);
            dt.Fill(t);
            dataGridView1.DataSource = t;

            //
            t1.Rows.Clear();
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
               progressBar1.Value = 0;
               if (cc == 1)
               {

                   t.Rows.Clear();
                   dataGridView1.DataSource = t;
                   SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# pro\try table with\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
                   con1.Open();

                   string sl = string.Format("SELECT * FROM Orderdetails");

                   SqlCommand s = new SqlCommand(sl, con1);

                   SqlDataAdapter dt = new SqlDataAdapter(s);
                   dt.Fill(t);
                   dataGridView1.DataSource = t;

                    MessageBox.Show("Order Update successfully", "You can order now !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               }
               else
               {
                 
                   MessageBox.Show("Order update deleted", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               }

            }
            else
            {

                progressBar1.Value++;
            
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
