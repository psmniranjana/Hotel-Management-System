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
    public partial class ReservationForm : Form
    {
        public ReservationForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\Hoteldb.mdf;Integrated Security=True;Connect Timeout=30");

        public void datagrid()
        {
             SqlDataAdapter adapter= new SqlDataAdapter();
            String sql = "select * from Reservation_tbl";
            DataSet ds=new DataSet();

            try
            {
                con.Open();
                adapter=new SqlDataAdapter(sql,con);
                adapter.Fill(ds);

                dgv.DataSource = ds.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int cltid = int.Parse(clientid.Text);
            int resid = int.Parse(reservid.Text);
            int rmid=int.Parse(roomid.Text);
            string datin = datein.Value.ToString("yyyy-MM-dd");
            string datout = dateout.Value.ToString("yyyy-MM-dd");

            try
            {
                string qry = "insert into Reservation_tbl values('" + cltid + "','" + resid + "','" + rmid + "','" + datin + "','" + datout + "')";
                SqlCommand cmd = new SqlCommand(qry,con);
                con.Open();
                cmd.ExecuteNonQuery();
                
                con.Close();
                datagrid();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            datagrid();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
          
            try
            {
                string qry = "update Reservation_tbl set RoomId='"+roomid.Text+"' where ResId='"+reservid.Text+"'";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                datagrid();
                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            clientid.Clear();
            reservid.Clear();
            roomid.Clear();
        }
    }
}
