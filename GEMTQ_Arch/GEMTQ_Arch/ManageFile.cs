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
    public partial class ManageFile : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);

        public ManageFile()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s= "DELETE FROM [dbo].[DocumentsArch] WHERE DocID='" + Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value)+"'";

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
            fiilgraid();
        }

        private void ManageFile_Load(object sender, EventArgs e)
        {
            fiilgraid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "select DocID as  'رقم الملف',KindName as  'نوع الملف',PublicN as  'الرقم العام',InnerN as  'الرقم  الخاص',DateOfDoc as  'تاريخ الملف',DistName as  'وجهة الملف',DepartName as  'قسم الملف',SubjectDoc as  'موضوع الملف',DocName as  'اسم الملف',FILEex as  'امتداد الملف',RemaindDate as  'تاريخ التذكير',CreatedDate as  'تاريخ الانشاء' from DepartmentArch ,DistenationArch,DocumentsArch,KindDocuments where DocumentsArch.DistID=DistenationArch.DistID and DocumentsArch.KindID=KindDocuments.KindID and DocumentsArch.DepartID=DepartmentArch.DepartID and  DocName like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = "select DocID as  'رقم الملف',KindName as  'نوع الملف',PublicN as  'الرقم العام',InnerN as  'الرقم  الخاص',DateOfDoc as  'تاريخ الملف',DistName as  'وجهة الملف',DepartName as  'قسم الملف',SubjectDoc as  'موضوع الملف',DocName as  'اسم الملف',FILEex as  'امتداد الملف',RemaindDate as  'تاريخ التذكير',CreatedDate as  'تاريخ الانشاء' from DepartmentArch ,DistenationArch,DocumentsArch,KindDocuments where DocumentsArch.DistID=DistenationArch.DistID and DocumentsArch.KindID=KindDocuments.KindID and DocumentsArch.DepartID=DepartmentArch.DepartID and  DocName like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        public void fiilgraid()
        {
            string s = "select DocID as  'رقم الملف',KindName as  'نوع الملف',PublicN as  'الرقم العام',InnerN as  'الرقم  الخاص',DateOfDoc as  'تاريخ الملف',DistName as  'وجهة الملف',DepartName as  'قسم الملف',SubjectDoc as  'موضوع الملف',DocName as  'اسم الملف',FILEex as  'امتداد الملف',RemaindDate as  'تاريخ التذكير',CreatedDate as  'تاريخ الانشاء' from DepartmentArch ,DistenationArch,DocumentsArch,KindDocuments where DocumentsArch.DistID=DistenationArch.DistID and DocumentsArch.KindID=KindDocuments.KindID and DocumentsArch.DepartID=DepartmentArch.DepartID";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
