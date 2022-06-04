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
    public partial class ManageDepart : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);
        int DepartID;
        public ManageDepart()
        {
           
            InitializeComponent();



        }

        void fillgraid()
        {
            string s = "select DepartName from DepartmentArch ";
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

        private void ManageDepart_Load(object sender, EventArgs e)
        {
            fillgraid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            string s1 = "select isnull(max(DepartmentArch.DepartID),0)+1 from DepartmentArch ";
            SqlCommand SMD = new SqlCommand(s1, con);
            try
            {
                con.Open();
                DepartID = Convert.ToInt32(SMD.ExecuteScalar());
                con.Close();
            }
            catch(SqlException EX)
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
                label4.Text="الرجاء ادخال اسم القسم";

            }
            else
            {
                string NAME = textBox1.Text;
                string s = "insert into DepartmentArch values ( '" + DepartID + "','" + NAME  + "' ) ";
                SqlCommand cmd = new SqlCommand(s, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    AddFile.getMainForm.fiilcom3();
                    scannar.getMainForm.fiilcom3();
                    textBox1.Clear();
                    label4.ForeColor = Color.White;
                    label4.Text="تمت الأضافة بنجاح";
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

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                label4.ForeColor = Color.Red;
                label4.Text = "لا يوجد اقسام بعد";


            }
            else
            {

                if (textBox1.Text == "")
                {
                    label4.ForeColor = Color.Red;
                  label4.Text=  "الرجاء ادخال اسم القسم الجديد";
                }
                else
                {

                    int i;
                    i = dataGridView1.SelectedCells[0].RowIndex;
                    string s = "UPDATE DepartmentArch SET [DepartName]='" + textBox1.Text + "' where [DepartName]= '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ";
                    SqlCommand cmd = new SqlCommand(s, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        label4.ForeColor = Color.White;
                        label4.Text="تم التعديل بنجاح";
                        fillgraid();
                        con.Close();
                        AddFile.getMainForm.fiilcom3();
                        scannar.getMainForm.fiilcom3();
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

        private void ManageDepart_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
    }

