using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSW
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            txttime.Text = time;
            //namelb.Text = b;
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2GradientPanel3.Controls.Clear();
            ClientForm cf = new ClientForm();
            cf.TopLevel = false;
            cf.AutoScroll = true;
            guna2GradientPanel3.Controls.Add(cf);
            cf.Show();

            
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2GradientPanel3.Controls.Clear();
            ReservationForm cf = new ReservationForm();
            cf.TopLevel = false;
            cf.AutoScroll = true;
            guna2GradientPanel3.Controls.Add(cf);
            cf.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2GradientPanel3.Controls.Clear();
            RoomForm cf = new RoomForm();
            cf.TopLevel = false;
            cf.AutoScroll = true;
            guna2GradientPanel3.Controls.Add(cf);
            cf.Show();
        }
        string b;

        public void ab(string a)
        {
            b= a.ToString();

        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            this.Hide();
            lf.Show();
        }
    }
}
