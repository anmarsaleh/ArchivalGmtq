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
using System.Net;
using System.IO;

namespace GEMTQ_Arch
{
    public partial class TransFiles : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);

        public TransFiles()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userslist us = new userslist();
            us.ShowDialog();
            textBox2.Text=us.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label6.Text=us.dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fileslist fs = new fileslist();
            fs.ShowDialog();
            textBox1.Text = fs.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            label7.Text= fs.dataGridView1.CurrentRow.Cells[0].Value.ToString();

        }

        public bool check_not_null()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label8.ForeColor = Color.Red;
               label8.Text="الرجاء تحديد الملف أو الموظف المستقبل";
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (check_not_null()==true)
            {
                string s = "insert into TransFiles values ('" + Convert.ToInt32(label7.Text) + "','" + Program.user_id + "','" + Convert.ToInt32(label6.Text) + "','" + DateTime.Now.ToString() + "','" + false + "','','" + textBox3.Text + "','') ";
                SqlCommand cmd = new SqlCommand(s, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    SendFile sd = new SendFile();
                    sd.ShowDialog();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    string s1 = "select ReciveUserID as 'رقم المستقبل',DocName as'اسم الملف',IsReciveFile as'حالة الارسال',ReciveDate as'تاريخ الاستقبال',RespondNote as 'ملاحظات المستقبل' from TransFiles ,DocumentsArch where DocumentsArch.DocID=TransFiles.DocID and TranUserID='" + Program.user_id + "'";
                    SqlCommand sx = new SqlCommand(s1, con);
                    SqlDataAdapter da = new SqlDataAdapter(sx);
                    DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;

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

        }

       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TransFiles_Load(object sender, EventArgs e)
        {

        }
    }
}
