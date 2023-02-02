using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace HotelManagementSW
{
    public partial class LoginForm : Form
    {
        SqlConnection Con=new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\Hoteldb.mdf;Integrated Security=True;Connect Timeout=30");
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Con.Open();
            SqlDataAdapter sd=new SqlDataAdapter("select COUNT(*) from Staff_tbl where StaffName='"+usernametb.Text+"' and StaffPassword='"+passwordtb.Text+"'",Con);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            string a;
            if (dt.Rows[0][0].ToString()=="1")

            {
                Dashboard mf = new Dashboard();
                mf.Show();
                this.Hide();
                a = usernametb.Text;
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }

            Con.Close();
        }
    }
}
