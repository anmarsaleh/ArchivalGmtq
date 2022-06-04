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
            string s = "SELECT TransID as 'رقم', DocName as'اسم الملف' ,ReciveUserID as'رقم المستقبل' ,TransDate as'تاريخ الارسال' ,IsReciveFile as'حالة الاستقبل' ,ReciveDate as'تاريخ الاستقبال' ,TransNote as 'ملاحظاتي',RespondNote as 'ملاحظات المستقبل' FROM TransFiles ,DocumentsArch where DocumentsArch.DocID=TransFiles.DocID and TranUserID='" + Program.user_id + "'ORDER BY TransID DESC";
            SqlCommand sx = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(sx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "SELECT DocName as'اسم الملف' ,ReciveUserID as'رقم المستقبل' ,TransDate as'تاريخ الارسال' ,IsReciveFile as'حالة الاستقبل' ,ReciveDate as'تاريخ الاستقبال' ,TransNote as 'ملاحظاتي',RespondNote as 'ملاحظات المستقبل' FROM TransFiles ,DocumentsArch where DocumentsArch.DocID=TransFiles.DocID and TranUserID='" + Program.user_id + "' and DocName  like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = "SELECT DocName as'اسم الملف' ,ReciveUserID as'رقم المستقبل' ,TransDate as'تاريخ الارسال' ,IsReciveFile as'حالة الاستقبل' ,ReciveDate as'تاريخ الاستقبال' ,TransNote as 'ملاحظاتي',RespondNote as 'ملاحظات المستقبل' FROM TransFiles ,DocumentsArch where DocumentsArch.DocID=TransFiles.DocID and TranUserID='" + Program.user_id + "' and DocName  like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
