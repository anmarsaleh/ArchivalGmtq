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
    public partial class FileDetails : Form
    {
        private static FileDetails frm;


        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);

        public FileDetails()
        {
            if (frm == null)
                frm = this;

            InitializeComponent();
            
        }
        static void frm_FORMClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FileDetails getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new FileDetails();
                    frm.FormClosed += new FormClosedEventHandler(frm_FORMClosed);
                }
                return frm;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FileDetails_Load(object sender, EventArgs e)
        {
            List<object> destList = new List<object>();
            foreach (DataGridViewRow row in reciveFiles.getMainForm.dataGridView1.SelectedRows)
                destList.Add(row.DataBoundItem);
               dataGridView1.DataSource = destList;
            //string a = "select IsReciveFile from TransFiles where TransID='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value) + "'";
            //SqlCommand sas = new SqlCommand(a, con);
            //SqlDataAdapter daa = new SqlDataAdapter(sas);
            //DataTable dt1 = new DataTable();
            //daa.Fill(dt1);
            //string isrecive = dt1.Rows[0]["IsReciveFile"].ToString();
            //if (isrecive == "false")
            //{
            if(dataGridView1.CurrentRow.Cells[1].Value != null)
            {
                string s = "update TransFiles set IsReciveFile='" + true + "' where TransID='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value) + "'";
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
                string s1 = "SELECT TransFiles.DocID as 'رقم الملف',TransID as 'رقم', DocName as'اسم الملف' ,TransDate as'تاريخ الارسال' ,IsReciveFile as'حالة الاستقبال' ,ReciveDate as'تاريخ الاستقبال' ,TransNote as 'ملاحظات المرسل',RespondNote as 'ملاحظاتي' FROM TransFiles ,DocumentsArch where DocumentsArch.DocID=TransFiles.DocID and TranUserID='" + Program.user_id + "'ORDER BY TransID DESC";
                SqlCommand sx = new SqlCommand(s1, con);
                SqlDataAdapter da = new SqlDataAdapter(sx);
                DataTable dt = new DataTable();
                da.Fill(dt);
                reciveFiles.getMainForm.dataGridView1.DataSource = dt;
                fillgraid();


            }
        }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "update TransFiles set RespondNote='" + textBox1.Text + "' where TransID='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value) + "'";
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
            string s1 = "SELECT TransFiles.DocID as 'رقم الملف', TransID as 'رقم', DocName as'اسم الملف' ,TransDate as'تاريخ الارسال' ,IsReciveFile as'حالة الاستقبال' ,ReciveDate as'تاريخ الاستقبال' ,TransNote as 'ملاحظات المرسل',RespondNote as 'ملاحظاتي' FROM TransFiles ,DocumentsArch where DocumentsArch.DocID=TransFiles.DocID and TranUserID='" + Program.user_id + "'ORDER BY TransID DESC";
            SqlCommand sx = new SqlCommand(s1, con);
            SqlDataAdapter da = new SqlDataAdapter(sx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            reciveFiles.getMainForm.dataGridView1.DataSource = dt;
            textBox1.Clear();
            fillgraid();
        }
        public void fillgraid()
        {
            string s2 = "SELECT TransFiles.DocID as 'رقم الملف', TransID as 'رقم', DocName as'اسم الملف' ,TransDate as'تاريخ الارسال' ,IsReciveFile as'حالة الاستقبال' ,ReciveDate as'تاريخ الاستقبال' ,TransNote as 'ملاحظات المرسل',RespondNote as 'ملاحظاتي' FROM TransFiles ,DocumentsArch where DocumentsArch.DocID=TransFiles.DocID and TransID='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value) + "'";
            SqlCommand sw = new SqlCommand(s2, con);
            SqlDataAdapter daa = new SqlDataAdapter(sw);
            DataTable dta = new DataTable();
            daa.Fill(dta);
            this.dataGridView1.DataSource = dta;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayFile ds = new DisplayFile();
            ds.ShowDialog();
        }
    }
}
