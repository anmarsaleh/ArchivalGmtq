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
namespace GEMTQ_Arch
{
    public partial class frm_signout : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);

        public frm_signout()
        {
            InitializeComponent();
        }



        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            string s = "Update Users set IsLogin='" + false + "' ,PcName='' where UserID='" + Program.user_id + "'";
            SqlCommand cmd = new SqlCommand(s, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                con.Close();
            }
            MainForm.getMainForm.Close();
            this.Hide();
            login ds = new login();
            ds.Show();
        }


        

    private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
