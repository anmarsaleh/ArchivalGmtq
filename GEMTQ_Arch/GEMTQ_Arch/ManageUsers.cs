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
    public partial class ManageUsers : Form
    {
        public int UserID ;
        public string UserName ;
        public bool ActiveUser ;
        public string EndActive ;
        public bool CanModyfied ;
        public bool CanDelete ;
        public bool CanView ;
        public bool IsAdmin;
        public string UserPW;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);
        private static ManageUsers frm;
        public ManageUsers()
        {
            if (frm == null)
                frm = this;

            InitializeComponent();
        }
        static void frm_FORMClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static ManageUsers getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new ManageUsers();
                    frm.FormClosed += new FormClosedEventHandler(frm_FORMClosed);
                }
                return frm;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = "SELECT [UserID] as'رقم المستخدم' ,[UserName] as'اسم المستخدم' ,[ActiveUser] as'حالة الحساب مفعل/غير مفعل' ,[EndActive] as'تاريخ انتهاء الصلاحية',[CanModyfied] as'صلاحيات التعديل',[CanDelete] as'صلاحيات الحذف' ,[CanView] as'صلاحيات العرض' ,[IsAdmin] as'نوع المستخدم مدير/موظف',[UserPW] as'كلمة المرور' ,[IsLogin] as'حالة الدخول مسجل/غير مسجل'  ,[PcName] as'الحاسب الشخصي' FROM [dbo].[Users] where  UserName like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "SELECT [UserID] as'رقم المستخدم' ,[UserName] as'اسم المستخدم' ,[ActiveUser] as'حالة الحساب مفعل/غير مفعل' ,[EndActive] as'تاريخ انتهاء الصلاحية',[CanModyfied] as'صلاحيات التعديل',[CanDelete] as'صلاحيات الحذف' ,[CanView] as'صلاحيات العرض' ,[IsAdmin] as'نوع المستخدم مدير/موظف',[UserPW] as'كلمة المرور' ,[IsLogin] as'حالة الدخول مسجل/غير مسجل'  ,[PcName] as'الحاسب الشخصي' FROM [dbo].[Users] where  UserName like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateUser ds = new CreateUser();
            ds.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "DELETE FROM [dbo].[Users] WHERE UserID='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) + "'";

            SqlCommand cmd = new SqlCommand(s, con);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            cmd.ExecuteNonQuery();
            con.Close();
            fillgraid();

        }
        public void fillgraid()
        {
            string s = "SELECT [UserID] as'رقم المستخدم' ,[UserName] as'اسم المستخدم' ,[ActiveUser] as'حالة الحساب مفعل/غير مفعل' ,[EndActive] as'تاريخ انتهاء الصلاحية',[CanModyfied] as'صلاحيات التعديل',[CanDelete] as'صلاحيات الحذف' ,[CanView] as'صلاحيات العرض' ,[IsAdmin] as'نوع المستخدم مدير/موظف',[UserPW] as'كلمة المرور' ,[IsLogin] as'حالة الدخول مسجل/غير مسجل'  ,[PcName] as'الحاسب الشخصي' FROM [dbo].[Users]";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string a = "select * from  Users where DATEDIFF(day,GETDATE(),EndActive)=0";
            SqlCommand cmd1 = new SqlCommand(a, con);
            SqlDataAdapter daa = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            daa.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("تم ايجاد'" + dt.Rows.Count.ToString() + "' حسابات  منتهية الصلاحية ", "حذف المستخدمين", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    string s = "delete from Users where DATEDIFF(day,GETDATE(),EndActive)=0";
                    SqlCommand cmd = new SqlCommand(s, con);
                    try
                    {
                        con.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم حذف جميع الحسابات المنتهية الصلاحية");

                }
                else
                {
                    return;
                }


            }
            else
            {
                MessageBox.Show("لا يوجد حسابات منتهية الصلاحية بعد");
            }

        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            fillgraid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                 UserID =Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value);
                 UserName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                 ActiveUser =Convert.ToBoolean( dataGridView1.CurrentRow.Cells[2].Value);
                 EndActive =Convert.ToDateTime( dataGridView1.CurrentRow.Cells[3].Value).ToShortDateString();
                 CanModyfied= Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value);
                 CanDelete= Convert.ToBoolean(dataGridView1.CurrentRow.Cells[5].Value);
                 CanView= Convert.ToBoolean(dataGridView1.CurrentRow.Cells[6].Value);
                 IsAdmin= Convert.ToBoolean(dataGridView1.CurrentRow.Cells[7].Value);
                 UserPW= dataGridView1.CurrentRow.Cells[8].Value.ToString();
                UpdateUsers ds = new UpdateUsers();
                ds.ShowDialog();

            }
        }
    }
}
