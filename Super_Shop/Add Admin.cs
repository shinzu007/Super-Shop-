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
    public partial class Add_Admin : Form
    {
        Databasecon cn = new Databasecon();

        Admin aa = new Admin();
        Admin_Home a;

        public Add_Admin(Admin_Home a)
        {
            InitializeComponent();
            label11.Text = aa.AID;
            this.a = a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Home a = new Admin_Home();
            a.Show();
            this.Hide();
            
        }

        private void Add_Admin_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            aa.AID = aa.AID;
            aa.Name = textBox1.Text;
            aa.Password = textBox5.Text;
            aa.Email=textBox4.Text;
            aa.MobileNo = textBox3.Text;
            bool isChecked = radioButton1.Checked;
            if (isChecked)
            {
                aa.Gender = radioButton1.Text;
            }
            else
            {
                aa.Gender = radioButton2.Text;
            }
            aa.DateOfBirth = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            aa.Address = textBox7.Text;

           // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jahin\Documents\Super_shop_test_1.mdf;Integrated Security=True;Connect Timeout=30");
           // con.Open();

           // SqlCommand s = new SqlCommand("INSERT INTO Admininfo (AId,name,password,email,DOB,gender,mobileNo,address) values ('" + aa.AID + "','" + aa.Name + "','" + aa.Password + "','" + aa.Email + "','" + aa.DateOfBirth + "','" + aa.Gender + "','" + aa.MobileNo + "','" + aa.Address + "')", con);


           /* if (s.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("successfully Added Salesman", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {
                MessageBox.Show("Unsuccessfully Added", "Congrate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }*/

           //  con.Close();


          //  MessageBox.Show("Admin Add Successfully","Welcome",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

            cn.Insert(aa.AID, aa.Name , aa.Password, aa.Email,  aa.DateOfBirth , aa.Gender , aa.MobileNo, aa.Address);
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          //  Admin_Home a = new Admin_Home();
            a.Show();
            this.Hide();
        }



        private void Add_Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
