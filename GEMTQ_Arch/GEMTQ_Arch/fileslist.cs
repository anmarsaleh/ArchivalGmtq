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
using System.IO;
namespace GEMTQ_Arch
{
    public partial class fileslist : Form
    {
        private static fileslist frm;
        
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);

        public fileslist()
        {
            if (frm == null)
                frm = this;

            InitializeComponent();
        }
        static void frm_FORMClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static fileslist getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new fileslist();
                    frm.FormClosed += new FormClosedEventHandler(frm_FORMClosed);
                }
                return frm;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileslist_Load(object sender, EventArgs e)
        {

            string s = "select DocID as  'رقم الملف',KindName as  'نوع الملف',PublicN as  'الرقم العام',InnerN as  'الرقم  الخاص',DateOfDoc as  'تاريخ الملف',DistName as  'وجهة الملف',DepartName as  'قسم الملف',SubjectDoc as  'موضوع الملف',DocName as  'اسم الملف',FILEex as  'امتداد الملف',RemaindDate as  'تاريخ التذكير',CreatedDate as  'تاريخ الانشاء' from DepartmentArch ,DistenationArch,DocumentsArch,KindDocuments where DocumentsArch.DistID=DistenationArch.DistID and DocumentsArch.KindID=KindDocuments.KindID and DocumentsArch.DepartID=DepartmentArch.DepartID";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "select DocID as  'رقم الملف',KindName as  'نوع الملف',PublicN as  'الرقم العام',InnerN as  'الرقم  الخاص',DateOfDoc as  'تاريخ الملف',DistName as  'وجهة الملف',DepartName as  'قسم الملف',SubjectDoc as  'موضوع الملف',DocName as  'اسم الملف',FILEex as  'امتداد الملف',RemaindDate as  'تاريخ التذكير',CreatedDate as  'تاريخ الانشاء' from DepartmentArch ,DistenationArch,DocumentsArch,KindDocuments where DocumentsArch.DistID=DistenationArch.DistID and DocumentsArch.KindID=KindDocuments.KindID and DocumentsArch.DepartID=DepartmentArch.DepartID and  DocName like '%"+textBox1.Text+"%'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileImage im = new fileImage();
            im.ShowDialog();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Close();
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
    }
}
