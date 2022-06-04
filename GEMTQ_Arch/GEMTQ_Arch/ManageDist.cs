﻿using System;
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
            if (textBox1.Text == "")
            {
                MessageBox.Show("الرجاء ادخال اسم الوجهة");

            }
            else
            {
                string s = "insert into DistenationArch values ('" + textBox1.Text + "' ) ";
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

        private void ManageDist_Load(object sender, EventArgs e)
        {
            fillgraid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("لا يوجد وجهات بعد");

            }
            else
            {

                if (textBox1.Text == "")
                {
                    MessageBox.Show("الرجاء ادخال اسم الوجهة الجديدة");
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("لا يوجد وجهات بعد");


            }
            else
            {
                DialogResult result2 = MessageBox.Show("هل تريد حذف هذه الوجهة فعلا ؟", "حذف وجهة", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result2 == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            //int i;
                            //i = dataGridView1.SelectedCells[0].RowIndex;
                            string s = "delete from DistenationArch where DistName='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ";
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
    }
}
