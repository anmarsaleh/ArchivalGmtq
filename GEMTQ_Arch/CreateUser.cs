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
        public bool check_not_null()
        {
            if (textBox1.Text=="" || textBox2.Text=="" ||textBox4.Text=="" || mtxtDOB.Text == "")
            {
                MessageBox.Show("الرجاء تعبئة الحقول الفارغة");
                return false;

            }
            else
            {
                return true;
            }
        }
        public bool check_confirm_password()
        {
            if (textBox1.Text == textBox4.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           if(check_not_null()==true)
            {
                if (checkBox4.Checked == true && checkBox5.Checked == true)
                {
                    if (check_confirm_password()==true)
                    {
                        string s = "insert into Users values ('" + textBox2.Text + "','" + true + "',convert(date,'" + mtxtDOB.Text + "'),'" + Convert.ToBoolean(checkBox1.Checked) + "','" + Convert.ToBoolean(checkBox3.Checked) + "','" + Convert.ToBoolean(checkBox2.Checked) + "','" + false + "' ,'" + textBox4.Text + "','" + false + "','')";
                        SqlCommand cmd = new SqlCommand(s, con);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            label10.ForeColor = Color.White;
                           label10.Text="تمت عملية الأضافة بنجاح";

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                        finally
                        {
                            con.Close();
                        }
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
                        label10.ForeColor = Color.Red;
                      label10.Text="الرجاء ادخال كلمة المرور بشكل صحيح";
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
                                cmd.ExecuteNonQuery();
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
                            label10.ForeColor = Color.White;
                            label10.Text = "تمت عملية الأضافة بنجاح";
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
                            label10.ForeColor = Color.Red;
                            label10.Text = "الرجاء ادخال كلمة المرور بشكل صحيح";
                        }
                    }
                    else
                    {
                        if (checkBox4.Checked == false && checkBox5.Checked == true)
                        {
                            if (check_confirm_password()==true)
                            {
                                string s = "insert into Users values ('" + textBox2.Text + "','" + false + "',convert(date,'" + mtxtDOB.Text + "'),'" + checkBox1.Checked + "','" + checkBox3.Checked + "','" + checkBox2.Checked + "','" + false + "' ,'" + textBox4.Text + "','" + false + "','')";
                                SqlCommand cmd = new SqlCommand(s, con);
                                try
                                {
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("" + ex);
                                }
                                finally{
                                    con.Close();
                                }
                                label10.ForeColor = Color.White;
                                label10.Text = "تمت عملية الأضافة بنجاح";
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
                                label10.ForeColor = Color.Red;
                                label10.Text = "الرجاء ادخال كلمة المرور بشكل صحيح";
                            }
                        }
                        else
                        {
                            if (checkBox4.Checked == true && checkBox5.Checked == false)
                            {
                                if (check_confirm_password() == true)
                                {
                                    string s = "insert into Users values ('" + textBox2.Text + "','" + true + "',convert(date,'" + mtxtDOB.Text + "'),'" + checkBox1.Checked + "','" + checkBox3.Checked + "','" + checkBox2.Checked + "','" + true + "' ,'" + textBox4.Text + "','" + false + "','')";
                                    SqlCommand cmd = new SqlCommand(s, con);
                                    try
                                    {
                                        con.Open();
                                        cmd.ExecuteNonQuery();
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
                                    label10.ForeColor = Color.White;
                                    label10.Text = "تمت عملية الأضافة بنجاح";
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
                                    label10.ForeColor = Color.Red;
                                    label10.Text = "الرجاء ادخال كلمة المرور بشكل صحيح";
                                }
                            }
                        }

                    }


                }

            }
            else
            {
                return;
            }
        }

        private void mtxtDOB_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
