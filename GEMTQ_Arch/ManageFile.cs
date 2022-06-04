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
                cmd.ExecuteNonQuery();
                con.Close();
                fiilgraid();

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

        private void ManageFile_Load(object sender, EventArgs e)
        {
            fiilgraid();
            fiilcom1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        public void fiilgraid()
        {
            string s = "SELECT [DocID] as N'رقم الملف' ,[KindID] AS N'رقم النوع' , [PublicN] AS N'الرقم العام' ,[InnerN] AS N'الرقم الخاص',[DateOfDoc] AS N'تاريخ الملف' ,[DistID] AS N'رقم الوجهة',[DepartID] AS N'رقم القسم',[SubjectDoc] AS N'موضوع الملف',[DocName] AS N'اسم الملف',[FILEex] AS N'أمتداد الملف',[RemaindDate] AS N'تاريخ التذكير' ,[CreatedDate]AS N'تاريخ الانشاء',[Num_of_files] AS N'عدد الملفات المرتبطة' FROM [dbo].[DocumentsArch]";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.SelectedValue);
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    string s = "SELECT [DocID] as N'رقم الملف' ,[KindID] AS N'رقم النوع' , [PublicN] AS N'الرقم العام' ,[InnerN] AS N'الرقم الخاص',[DateOfDoc] AS N'تاريخ الملف' ,[DistID] AS N'رقم الوجهة',[DepartID] AS N'رقم القسم',[SubjectDoc] AS N'موضوع الملف',[DocName] AS N'اسم الملف',[FILEex] AS N'أمتداد الملف',[RemaindDate] AS N'تاريخ التذكير' ,[CreatedDate]AS N'تاريخ الانشاء',[Num_of_files] AS N'عدد الملفات المرتبطة' FROM [dbo].[DocumentsArch] where  InnerN = '" + textBox1.Text + "' and PublicN = '" + textBox2.Text + "'and SubjectDoc = '" + textBox3.Text + "' and KindID ='" + id + "'";
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
