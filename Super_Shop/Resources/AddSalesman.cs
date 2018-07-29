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
    public partial class AddSalesman : Form
    {
        Salesman ss = new Salesman();
        Admin_Home a1;

        public AddSalesman(Admin_Home a1)
        {
            InitializeComponent();


            label11.Text = ss.SId;
            this.a1 = a1;
        }
        private void AddSalesman_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Admin Add Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Home a1 = new Admin_Home();
            a1.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Admin_Home a1 = new Admin_Home();
            a1.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ss.SId = ss.SId;
            ss.Name = textBox1.Text;
            
            ss.Password = textBox5.Text;
            ss.MobileNo = textBox6.Text;
            ss.Email = textBox4.Text;

            bool isChecked = radioButton1.Checked;
            if (isChecked)
            {
                ss.Gender = radioButton1.Text;
            }
            else
            {
                ss.Gender = radioButton2.Text;
            }
            ss.DateOfBirth = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            ss.Address = textBox7.Text;
            ss.Salary = Convert.ToInt64(textBox3.Text);



            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jahin\Documents\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            SqlCommand s = new SqlCommand("INSERT INTO Salesmaninfo(SId,name,password,email,DOB,gender,mobileNo,address,salary) values ('" + ss.SId + "','" + ss.Name + "','" + ss.Password + "','" + ss.Email + "','" + ss.DateOfBirth + "','" + ss.Gender + "','" + ss.MobileNo + "','" + ss.Address + "'," + ss.Salary+ ")", con);


            if (s.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("successfully Added Salesman", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {
                MessageBox.Show("Unsuccessfully Added", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }

            a1.Show();
            this.Hide();

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

       

        private void AddSalesman_Load(object sender, EventArgs e)
        {

        }
    }
}
