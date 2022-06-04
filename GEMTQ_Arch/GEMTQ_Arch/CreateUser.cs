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
    public partial class CreateUser : Form
    {
        
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);
        
        public CreateUser()
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(textBox1.Text!=null || textBox2.Text!=null || textBox4.Text != null)
            {
                if (checkBox4.Checked == true && checkBox5.Checked == true)
                {
                    if (textBox1.Text == textBox4.Text)
                    {
                        string s = "insert into Users values ('" + textBox2.Text + "','" + true + "',convert(date,'" + mtxtDOB.Text + "'),'" + Convert.ToBoolean(checkBox1.Checked) + "','" + Convert.ToBoolean(checkBox3.Checked) + "','" + Convert.ToBoolean(checkBox2.Checked) + "','" + false + "' ,'" + textBox4.Text + "','" + false + "','')";
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
                        MessageBox.Show("تمت عملية الأضافة بنجاح");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox4.Clear();
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        checkBox3.Checked = false;
                        checkBox4.Checked = false;
                        checkBox5.Checked = false;
                        mtxtDOB.Clear();
                    }
                    else
                    {
                        MessageBox.Show("الرجاء ادخال كلمة المرور بشكل صحيح");
                    }
                }
                else
                {
                    if (checkBox4.Checked == false && checkBox5.Checked == false)
                    {
                        if (textBox1.Text == textBox4.Text)
                        {
                            string s = "insert into Users values ('" + textBox2.Text + "','" + false + "',convert(date,'" + mtxtDOB.Text + "'),'" + checkBox1.Checked + "','" + checkBox3.Checked + "','" + checkBox2.Checked + "','" + true + "' ,'" + textBox4.Text + "','" + false + "','')";
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
                            MessageBox.Show("تمت عملية الأضافة بنجاح");
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox4.Clear();
                            checkBox1.Checked = false;
                            checkBox2.Checked = false;
                            checkBox3.Checked = false;
                            checkBox4.Checked = false;
                            checkBox5.Checked = false;
                            mtxtDOB.Clear();

                        }
                        else
                        {
                            MessageBox.Show("الرجاء ادخال كلمة المرور بشكل صحيح");
                        }
                    }
                    else
                    {
                        if (checkBox4.Checked == false && checkBox5.Checked == true)
                        {
                            if (textBox1.Text == textBox4.Text)
                            {
                                string s = "insert into Users values ('" + textBox2.Text + "','" + false + "',convert(date,'" + mtxtDOB.Text + "'),'" + checkBox1.Checked + "','" + checkBox3.Checked + "','" + checkBox2.Checked + "','" + false + "' ,'" + textBox4.Text + "','" + false + "','')";
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
                                MessageBox.Show("تمت عملية الأضافة بنجاح");
                                textBox1.Clear();
                                textBox2.Clear();
                                textBox4.Clear();
                                checkBox1.Checked = false;
                                checkBox2.Checked = false;
                                checkBox3.Checked = false;
                                checkBox4.Checked = false;
                                checkBox5.Checked = false;
                                mtxtDOB.Clear();

                            }
                            else
                            {
                                MessageBox.Show("الرجاء ادخال كلمة المرور بشكل صحيح");
                            }
                        }
                        else
                        {
                            if (checkBox4.Checked == true && checkBox5.Checked == false)
                            {
                                if (textBox1.Text == textBox4.Text)
                                {
                                    string s = "insert into Users values ('" + textBox2.Text + "','" + true + "',convert(date,'" + mtxtDOB.Text + "'),'" + checkBox1.Checked + "','" + checkBox3.Checked + "','" + checkBox2.Checked + "','" + true + "' ,'" + textBox4.Text + "','" + false + "','')";
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
                                    MessageBox.Show("تمت عملية الأضافة بنجاح");
                                    textBox1.Clear();
                                    textBox2.Clear();
                                    textBox4.Clear();
                                    checkBox1.Checked = false;
                                    checkBox2.Checked = false;
                                    checkBox3.Checked = false;
                                    checkBox4.Checked = false;
                                    checkBox5.Checked = false;
                                    mtxtDOB.Clear();

                                }
                                else
                                {
                                    MessageBox.Show("الرجاء ادخال كلمة المرور بشكل صحيح");
                                }
                            }
                        }

                    }


                }

            }
        }

        private void mtxtDOB_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
