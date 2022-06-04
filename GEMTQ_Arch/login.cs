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
            Application.ExitThread();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fiilUsers()
        {
            try
            {
                con.Open();
                string s = "select * from Users";
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "UserName";
                    comboBox1.ValueMember = "UserID";
                    con.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex);
            }

            finally
            {
                con.Close();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int uID = Convert.ToInt32(comboBox1.SelectedValue);
            if  (textBox2.Text != "")
            {
                string s = "select UserID ,UserName ,UserPW ,IsAdmin ,ActiveUser , PcName ,IsLogin from Users where UserID ='" + uID + "' and  UserPW='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int idr = dt.Rows.Count;
                if (idr > 0)
                {
                    
                    bool admin = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]);
                    bool ActiveUser = Convert.ToBoolean(dt.Rows[0]["ActiveUser"]);
                    int id = Convert.ToInt32(dt.Rows[0]["UserID"]);
                    bool is_login = Convert.ToBoolean(dt.Rows[0]["IsLogin"]);

                    if (admin == true && ActiveUser == true)
                    {
                        this.Hide();
                        string HostName = Dns.GetHostName().ToString();
                        string update = "update Users set PcName='" + HostName + "', IsLogin='" + true + "' WHERE UserID ='" + id + "'";
                        SqlCommand cmd1 = new SqlCommand(update, con);
                        try
                        {
                            con.Open();
                            cmd1.ExecuteNonQuery();
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
                        MainForm fn = new MainForm();
                        fn.Show();
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
                        MainForm.getMainForm.cancelprogram.Enabled = true;
                    }

                    else
                    {
                        if (admin == false && ActiveUser == true)
                        {
                            this.Hide();
                            string HostName = Dns.GetHostName().ToString();

                            string update = "update Users set PcName='" + HostName + "', IsLogin='" + true + "' WHERE UserID ='" + id + "'";
                            SqlCommand cmd1 = new SqlCommand(update, con);
                            try
                            {
                                con.Open();
                                cmd1.ExecuteNonQuery();
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
                            MainForm fn = new MainForm();
                            fn.Show();

                            MainForm.getMainForm.toolsstripcancel.Enabled = true;
                            MainForm.getMainForm.toolsstripaddfile.Enabled = true;
                            MainForm.getMainForm.toolsstripsend.Enabled = true;
                            MainForm.getMainForm.toolsstripdisplay.Enabled = true;
                            Program.user_id = Convert.ToInt32(dt.Rows[0]["UserID"]);
                            MainForm.getMainForm.changepassword.Enabled = true;
                            MainForm.getMainForm.toolscreateuser.Enabled = false;
                            MainForm.getMainForm.cancelprogram.Enabled = true;
                            MainForm.getMainForm.recivemessage.Enabled = true;
                            MainForm.getMainForm.filelist.Enabled = true;

                        }
                        else
                        {
                            label3.ForeColor = Color.Red;
                            label3.Text = "أن هذا الحساب غير مفعل";
                        }

                    }
                }

            }
            else
                {
                    label3.ForeColor = Color.Red;
                    label3.Text = "الرجاء ادخال كلمة المرور";
                    return;
                }
            }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
          fiilUsers();
        }

        private void login_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Focus();
        }
    }
}
