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
    public partial class ManageDist : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);
        int DistID;
        public ManageDist()
        {
            InitializeComponent();
        }

        void fillgraid()
        {
            string s = "select DistName from DistenationArch ";
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
            string s1 = "select isnull(max(DistenationArch.DistID),0)+1 from DistenationArch ";
            SqlCommand SMD = new SqlCommand(s1, con);
            try
            {
                con.Open();
                DistID = Convert.ToInt32(SMD.ExecuteScalar());
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
              label4.Text=  "الرجاء ادخال اسم الوجهة";

            }
            else
            {
                string NAME = textBox1.Text;
                string s = "insert into DistenationArch values ('"+DistID+"','" + NAME + "' ) ";
                SqlCommand cmd = new SqlCommand(s, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    AddFile.getMainForm.fiilcom2();
                    scannar.getMainForm.fiilcom2();
                    textBox1.Clear();
                    label4.ForeColor = Color.White;
                   label4.Text= "تمت الأضافة بنجاح";
                    fillgraid();
                    con.Close();

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

        private void ManageDist_Load(object sender, EventArgs e)
        {
            fillgraid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                label4.ForeColor = Color.Red;
               label4.Text= "لا يوجد وجهات بعد";

            }
            else
            {

                if (textBox1.Text == "")
                {
                    label4.ForeColor = Color.Red;
                 label4.Text=  "الرجاء ادخال اسم الوجهة الجديدة";
                }
                else
                {

                    int i;
                    i = dataGridView1.SelectedCells[0].RowIndex;
                    string s = "UPDATE DistenationArch SET DistName='" + textBox1.Text + "' where DistName= '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ";
                    SqlCommand cmd = new SqlCommand(s, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        label4.ForeColor = Color.Green;
                       label4.Text="تم التعديل بنجاح";
                        fillgraid();
                        con.Close();
                        AddFile.getMainForm.fiilcom2();
                        scannar.getMainForm.fiilcom2();
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

        private void ManageDist_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
