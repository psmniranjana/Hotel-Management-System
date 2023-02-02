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
    public partial class RoomForm : Form
    {
        public RoomForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\Hoteldb.mdf;Integrated Security=True;Connect Timeout=30");

        public void datagrid()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "select * from Room_tbl";
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(ds);

                dgv.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
            private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int rmid = int.Parse(roomid.Text);
            string rmtp = roomtype.Text;
            int rmpn = int.Parse(roomphone.Text);
            int rmf = int.Parse(roomf.Text);

            try
            {
                string qry = "insert into Room_tbl values('" + rmid + "','" + rmtp+ "','" + rmpn + "','"+rmf+"')";
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

  

        private void RoomForm_Load(object sender, EventArgs e)
        {
            datagrid();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            roomid.Clear();
            roomtype.Clear();
            roomphone.Clear();
            roomf.Clear();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            int rmid = int.Parse(roomid.Text);
            string rmtp = roomtype.Text;
            int rmpn = int.Parse(roomphone.Text);
            int rmf = int.Parse(roomf.Text);

            try
            {
                string qry = "update Room_tbl set RoomPhone='"+roomphone.Text+"', RoomFree='"+roomfee.Text+"', RoomType='"+roomtype.Text+"' where RoomId='"+roomid.Text+"'";
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
    }
}
