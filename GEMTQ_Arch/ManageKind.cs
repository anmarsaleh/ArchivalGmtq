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
    public partial class ManageKind : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);
        int KindID;
        public ManageKind()
        {
            InitializeComponent();
        }
        void fillgraid()
        {
            string s = "select KindName from KindDocuments ";
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
            string s1 = "select isnull(max(KindDocuments.KindID),0)+1 from KindDocuments ";
            SqlCommand SMD = new SqlCommand(s1, con);
            try
            {
                con.Open();
                KindID = Convert.ToInt32(SMD.ExecuteScalar());
                con.Close();
            }
            catch (SqlException EX)
            {
                MessageBox.Show("" + EX);

            }
            finally
            {
                con.Close();
            }

            if (textBox1.Text == "")
            {
                label4.ForeColor = Color.Red;
                label4.Text=   "الرجاء ادخال اسم النوع";

            }
            else
            {
                string path = "E:\\";
                string s = "insert into KindDocuments values ( '"+KindID+"','" + path + "','" + textBox1.Text + "' ) ";
                SqlCommand cmd = new SqlCommand(s, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    label4.ForeColor = Color.White;
                    label4.Text="تمت الأضافة بنجاح";
                    fillgraid();
                    con.Close();
                    AddFile.getMainForm.fiilcom1();
                    scannar.getMainForm.fiilcom1();
                    textBox1.Clear();

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

        private void ManageKind_Load(object sender, EventArgs e)
        {
            fillgraid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                label4.ForeColor = Color.Red;
                label4.Text="لا يوجد وجهات بعد";

            }
            else
            {

                if (textBox1.Text == "")
                {
                    label4.ForeColor = Color.Red;
                   label4.Text="الرجاء ادخال اسم النوع الجديد";
                }
                else
                {

                    int i;
                    i = dataGridView1.SelectedCells[0].RowIndex;
                    string Oldpath = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string s = "UPDATE KindDocuments SET KindName='" + textBox1.Text + "' where KindName= '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ";
                    SqlCommand cmd = new SqlCommand(s, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        label4.ForeColor = Color.White;
                        label4.Text="تم التعديل بنجاح";
                        fillgraid();
                        con.Close();
                        AddFile.getMainForm.fiilcom1();
                        scannar.getMainForm.fiilcom1();
                        textBox1.Clear();


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


        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void ManageKind_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}