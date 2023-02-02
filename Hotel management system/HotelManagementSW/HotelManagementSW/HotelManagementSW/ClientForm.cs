using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelManagementSW
{
    public partial class ClientForm : Form

    {

        public ClientForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\Hoteldb.mdf;Integrated Security=True;Connect Timeout=30");

        public void datagrid()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "select * from Client_tbl";
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
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            int id = int.Parse(clientid.Text);
            String name = clientnametb.Text;
            int pno = int.Parse(clientphontb.Text);
            String cont = clientcountrytb.Text;

            try
            {
                string qry = "update Client_tbl set  ClientName='"+clientnametb.Text+"', ClientPhone='"+clientphontb.Text+"', ClientCountry='"+clientcountrytb.Text+ "' where ClientId='" + clientid.Text + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           

            int id = int.Parse(clientid.Text);
            String name = clientnametb.Text;
            int pno = int.Parse(clientphontb.Text);
            String cont = clientcountrytb.Text;

            try
            {
                string qry = "insert into Client_tbl values('" + id + "','" + name + "','" + pno + "','" + cont + "')";
                SqlCommand cmd = new SqlCommand(qry, con);
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           

            try
            {
                string qry = "delete from Client_tbl where ClientId='"+clientid.Text+"'";
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

        private void ClientForm_Load(object sender, EventArgs e)
        {
            datagrid();
            
               
        }
    }
}
    
            
        
    

