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
    public partial class UpdateUsers : Form
    {
        int userid;
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);

        public UpdateUsers()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool check_not_null()
        {
            if ( textBox2.Text == "" || textBox4.Text == "" || mtxtDOB.Text == "")
            {
                label6.ForeColor = Color.Red;
               label6.Text="الرجاء تعبئة الحقول الفارغة";
                return false;

            }
            else
            {
                return true;
            }
        }

        private void UpdateUsers_Load(object sender, EventArgs e)
        {
            userid = ManageUsers.getMainForm.UserID;
            textBox2.Text = ManageUsers.getMainForm.UserName;
            checkBox4.Checked = ManageUsers.getMainForm.ActiveUser;
            mtxtDOB.Text = ManageUsers.getMainForm.EndActive;
            checkBox1.Checked = ManageUsers.getMainForm.CanModyfied;
            checkBox2.Checked = ManageUsers.getMainForm.CanView;
            checkBox3.Checked = ManageUsers.getMainForm.CanDelete;
            checkBox5.Checked = ManageUsers.getMainForm.IsAdmin;
            textBox4.Text = ManageUsers.getMainForm.UserPW;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (check_not_null() == true)
            {
                string s = "UPDATE [Users]  set [UserName]='" + textBox2.Text + "',[ActiveUser]='" + checkBox4.Checked + "',[EndActive]=convert(date,'" + Convert.ToDateTime(mtxtDOB.Text).ToShortDateString() + "'),[CanModyfied]='" + checkBox1.Checked + "',[CanDelete]='" + checkBox3.Checked + "',[CanView]='" + checkBox2.Checked + "',[IsAdmin]='" + checkBox5.Checked + "',[UserPW]='" + textBox4.Text + "'WHERE UserID='" + userid + "'";
                SqlCommand cmd = new SqlCommand(s, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    label6.ForeColor = Color.White;
                    label6.Text="تم تعديل المستخدم بنجاح";
                    textBox2.Text = null;
                    checkBox4.Checked = false;
                    mtxtDOB.Mask = null;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox5.Checked = false;
                    textBox4.Text = null;
                    this.Close();
                    ManageUsers.getMainForm.fillgraid();

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
            else
            {
                return;
            }
        }
    }
}
