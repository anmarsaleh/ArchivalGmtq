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
            if (textBox1.Text == "")
            {
                MessageBox.Show("الرجاء ادخال اسم القسم");

            }
            else
            {
                string s = "insert into DepartmentArch values ('" + textBox1.Text + "' ) ";
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
                textBox1.Clear();
                MessageBox.Show("تمت الأضافة بنجاح");
                fillgraid();
                con.Close();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("لا يوجد اقسام بعد");


            }
            else
            {
                DialogResult result2 = MessageBox.Show("هل تريد حذف هذا القسم فعلا ؟", "حذف قسم", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result2 == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            //int i;
                            //i = dataGridView1.SelectedCells[0].RowIndex;
                            string s = "delete from DepartmentArch where DepartName='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ";
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
                            textBox1.Clear();
                            MessageBox.Show("تم الحذف بنجاح");
                            fillgraid();
                            con.Close();
                        }
                    }
                }

                else
                {
                    return;
                }

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("لا يوجد اقسام بعد");

            }
            else
            {

                if (textBox1.Text == "")
                {
                    MessageBox.Show("الرجاء ادخال اسم القسم الجديد");
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                    cmd.ExecuteNonQuery();
                    textBox1.Clear();
                    MessageBox.Show("تم التعديل بنجاح");
                    fillgraid();
                    con.Close();

                }

            }
        }

        }
    }

