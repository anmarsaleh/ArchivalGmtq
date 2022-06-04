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
using System.Net;
namespace GEMTQ_Arch
{
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);

        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=null || textBox2.Text != null)
            {
                string s = "select UserID ,UserName ,UserPW ,IsAdmin ,ActiveUser , PcName ,IsLogin from Users where UserName ='" + textBox1.Text + "' and  UserPW='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    bool admin = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]);
                    bool ActiveUser = Convert.ToBoolean(dt.Rows[0]["ActiveUser"]);
                    int id = Convert.ToInt32(dt.Rows[0]["UserID"]);
                    bool is_login = Convert.ToBoolean(dt.Rows[0]["IsLogin"]);

                    if (admin == true && ActiveUser == true)
                    {
                        this.Close();
                        string HostName = Dns.GetHostName().ToString();
                        string update = "update Users set PcName='" + HostName + "', IsLogin='" + true + "' WHERE UserID ='" + id + "'";
                        SqlCommand cmd1 = new SqlCommand(update, con);
                        try
                        {
                            con.Open();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                        cmd1.ExecuteNonQuery();
                        con.Close();
                        MainForm.getMainForm.toolsstripcancel.Enabled = true;
                        MainForm.getMainForm.toolsstripdecumment.Enabled = true;
                        MainForm.getMainForm.toolsstripaddfile.Enabled = true;
                        MainForm.getMainForm.toolsstripsend.Enabled = true;
                        MainForm.getMainForm.toolsstripdisplay.Enabled = true;
                        MainForm.getMainForm.toolsstriplogin.Enabled = false;
                        Program.user_id = Convert.ToInt32(dt.Rows[0]["UserID"]);
                        MainForm.getMainForm.changepassword.Enabled = true;
                        MainForm.getMainForm.toolscreateuser.Enabled = true;
                        MainForm.getMainForm.recivemessage.Enabled = true;
                        MainForm.getMainForm.filelist.Enabled = true;
                        MainForm.getMainForm.manageuser.Enabled = true;
                    }

                    else
                    {
                        if (admin == false && ActiveUser == true)
                        {
                            this.Close();
                            string HostName = Dns.GetHostName().ToString();

                            string update = "update Users set PcName='" + HostName + "', IsLogin='" + true + "' WHERE UserID ='" + id + "'";
                            SqlCommand cmd1 = new SqlCommand(update, con);
                            try
                            {
                                con.Open();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("" + ex);
                            }
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            MainForm.getMainForm.toolsstripcancel.Enabled = true;
                            MainForm.getMainForm.toolsstripaddfile.Enabled = true;
                            MainForm.getMainForm.toolsstripsend.Enabled = true;
                            MainForm.getMainForm.toolsstripdisplay.Enabled = true;
                            Program.user_id = Convert.ToInt32(dt.Rows[0]["UserID"]);
                            MainForm.getMainForm.changepassword.Enabled = true;
                            MainForm.getMainForm.toolscreateuser.Enabled = false;

                        }
                        else
                        {
                            MessageBox.Show("أن هذا الحساب غير مفعل");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
