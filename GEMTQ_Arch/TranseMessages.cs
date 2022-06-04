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
    public partial class TranseMessages : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);
        selectdata sa = new selectdata();
        public TranseMessages()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TranseMessages_Load(object sender, EventArgs e)
        {
                dataGridView1.DataSource =sa.transdata(Program.user_id) ;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "SELECT DocName as'اسم الملف' ,Users.UserName 'اسم المستقبل' ,TransDate as'تاريخ الارسال' ,IsReciveFile as'حالة الاستقبل' ,ReciveDate as'تاريخ الاستقبال' ,TransNote as 'ملاحظاتي',RespondNote as 'ملاحظات المستقبل' FROM DocumentsArch INNER JOIN  TransFiles ON DocumentsArch.DocID = TransFiles.DocID INNER JOIN  Users ON DocumentsArch.UserID = Users.UserID and TranUserID='" + Program.user_id + "' and    TransDate    like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = "SELECT DocName as'اسم الملف' ,Users.UserName 'اسم المستقبل' ,TransDate as'تاريخ الارسال' ,IsReciveFile as'حالة الاستقبل' ,ReciveDate as'تاريخ الاستقبال' ,TransNote as 'ملاحظاتي',RespondNote as 'ملاحظات المستقبل' FROM DocumentsArch INNER JOIN  TransFiles ON DocumentsArch.DocID = TransFiles.DocID INNER JOIN  Users ON DocumentsArch.UserID = Users.UserID and TranUserID='" + Program.user_id + "' and    TransDate    like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

        }
    }
}
