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
        public void fiilcom1()
        {
            string s = "select * from KindDocuments";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "KindName";
                comboBox1.ValueMember = "KindID";

        }

        private void fileslist_Load(object sender, EventArgs e)
        {
            fiilcom1();
            string s = "SELECT [DocID] as N'رقم الملف' ,[KindID] AS N'رقم النوع' , [PublicN] AS N'الرقم العام' ,[InnerN] AS N'الرقم الخاص',[DateOfDoc] AS N'تاريخ الملف' ,[DistID] AS N'رقم الوجهة',[DepartID] AS N'رقم القسم',[SubjectDoc] AS N'موضوع الملف',[DocName] AS N'اسم الملف',[FILEex] AS N'أمتداد الملف',[RemaindDate] AS N'تاريخ التذكير' ,[CreatedDate]AS N'تاريخ الانشاء',[Num_of_files] AS N'عدد الملفات المرتبطة' FROM [dbo].[DocumentsArch]";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;



        }

        private void button3_Click(object sender, EventArgs e)
        {


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

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.SelectedValue);
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true)
            {
                if (textBox1.Text != "" && textBox2.Text!="" && textBox3.Text!="")
                {
                    string s = "SELECT [DocID] as N'رقم الملف' ,[KindID] AS N'رقم النوع' , [PublicN] AS N'الرقم العام' ,[InnerN] AS N'الرقم الخاص',[DateOfDoc] AS N'تاريخ الملف' ,[DistID] AS N'رقم الوجهة',[DepartID] AS N'رقم القسم',[SubjectDoc] AS N'موضوع الملف',[DocName] AS N'اسم الملف',[FILEex] AS N'أمتداد الملف',[RemaindDate] AS N'تاريخ التذكير' ,[CreatedDate]AS N'تاريخ الانشاء',[Num_of_files] AS N'عدد الملفات المرتبطة' FROM [dbo].[DocumentsArch] where  InnerN = '" + textBox1.Text+"' and PublicN = '"+textBox2.Text+"'and SubjectDoc = '"+textBox3.Text+"' and KindID ='"+id+"'";
                    SqlCommand cmd = new SqlCommand(s, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                }
                else
                {
                    return;
                }
            }

        }
    }
}
