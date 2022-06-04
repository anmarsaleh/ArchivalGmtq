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
    public partial class ChangePassword : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "select UserPW from Users where UserID='" + Program.user_id + "'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
                da.Fill(dt);

            string password = dt.Rows[0]["UserPW"].ToString();
            string s1 = textBox1.Text;

            if (s1.Trim() != password.Trim())
            {
                label5.ForeColor = Color.Red;
                    
                    label5.Text="الرجاء التأكد من كلمة المرور القديمة ";
            }
            else
            {
                string update = "update Users set UserPW='" + textBox2.Text + "' where UserID='" + Program.user_id + "' ";
                SqlCommand cms = new SqlCommand(update, con);
                try
                {
                    con.Open();
                    cms.ExecuteNonQuery();
                    con.Close();
                    label5.ForeColor = Color.White;
                    label5.Text=   "تم تعديل كلمة المرور بنجاح";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
                finally
                {
                    con.Close();
                }
            }


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
