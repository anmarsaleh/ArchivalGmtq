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
    public partial class userslist : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);

        public userslist()
        {
            InitializeComponent();
            string s = "select UserID as 'رقم المستخدم',UserName as 'اسم المستخدم', ActiveUser as 'الحساب مفعل',IsAdmin as 'مدير أو موظف' from Users";
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

        private void userslist_Load(object sender, EventArgs e)
        {
           
           
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "select UserID as 'رقم المستخدم',UserName as 'اسم المستخدم', ActiveUser as 'الحساب مفعل',IsAdmin as 'مدير أو موظف' from Users where  UserName like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = "select UserID as 'رقم المستخدم',UserName as 'اسم المستخدم', ActiveUser as 'الحساب مفعل',IsAdmin as 'مدير أو موظف' from Users where  UserName like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
