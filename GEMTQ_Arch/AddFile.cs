using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Data.SqlClient;
using System.Data;
namespace GEMTQ_Arch
{
    public partial class AddFile : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);
        string ext;
        byte[] datafile;
        private static AddFile frm;
        selectdata sa = new selectdata();
        int docid;
        public AddFile()
        {
            if (frm == null)
                frm = this;
            InitializeComponent();
        }
        static void frm_FORMClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static AddFile getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new AddFile();
                    frm.FormClosed += new FormClosedEventHandler(frm_FORMClosed);
                }
                return frm;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            scannar cb = new scannar();
            cb.ShowDialog();
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
            openFileDialog1.Filter = "Files (txt,doc,docx)|*.txt;*.doc;*.docx ;*.pdf";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK  )

            {
                int size = Convert.ToInt32( new FileInfo(openFileDialog1.FileName).Length);
                 ext = Path.GetExtension(openFileDialog1.FileName);
                if (ext == ".txt" && size < 102400)
                {
                    axAcroPDF1.Visible = false;
                    label15.Text = openFileDialog1.FileName;
                    richTextBox1.Text = File.ReadAllText(label15.Text);
                    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                    datafile = System.IO.File.ReadAllBytes(label15.Text);
                    richTextBox1.Visible = true;
                   
                }

           else     if (ext == ".pdf" && size < 10240000)
                {
                    axAcroPDF1.Visible = true;
                    richTextBox1.Visible = false;
                    label15.Text = openFileDialog1.FileName;
                    axAcroPDF1.src = label15.Text;
                    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                    datafile = System.IO.File.ReadAllBytes(label15.Text);
                }

                else if (ext == ".doc" || ext == ".docx" && size < 102400)
                    {
                        richTextBox1.Visible = true;
                        axAcroPDF1.Visible = false;
                        openFileDialog1.Title = "Word File";
                        openFileDialog1.InitialDirectory = openFileDialog1.FileName;
                        openFileDialog1.RestoreDirectory = true;
                        label15.Text = openFileDialog1.FileName.ToString();

                        try
                        {

                            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                            object miss = System.Reflection.Missing.Value;
                            object path = label15.Text;
                            object readOnly = true;
                            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                            docs.ActiveWindow.Selection.WholeStory();
                            docs.ActiveWindow.Selection.Copy();
                            IDataObject data = Clipboard.GetDataObject();
                            richTextBox1.Text = data.GetData(DataFormats.Text).ToString();
                        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                        datafile = encoding.GetBytes(richTextBox1.Text);

                    }

                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                    }
                else
                {
                    label8.ForeColor = Color.Red;
                    label8.Text = "حجم الملف كبير جدا";
                  

                }


            }
            }

       
        private void button2_Click(object sender, EventArgs e)
        {
            if (check_not_null()==true && check_true_value()==true && check_file() == true)
            {

                string s = "select isnull(max(DocumentsArch.DocID),0)+1 from DocumentsArch ";
                SqlCommand cmd = new SqlCommand(s, con);
                try
                {
                    con.Open();
                    int num_of_file = 0;
                    docid = Convert.ToInt32(cmd.ExecuteScalar());
                    int kind =Convert.ToInt32( comboBox1.SelectedValue);
                    string publicn = textBox2.Text;
                    string innern = textBox3.Text;
                    string DateOfDoc = dateTimePicker1.Value.ToShortDateString();
                    int dist = Convert.ToInt32(comboBox1.SelectedValue);
                    int dept = Convert.ToInt32(comboBox1.SelectedValue);
                    string subject = textBox1.Text;
                    string docname = "" + docid + "_" + kind + "_";
                    string RemaindDate = dateTimePicker2.Value.ToShortDateString();
                    int user = Program.user_id;
                    string create = DateTime.Now.ToShortDateString();
                    Wait asa = new Wait();
                    asa.ShowDialog();
                    sa.insertdata(docid, kind, publicn, innern, DateOfDoc, dist, dept, subject, docname, ext, RemaindDate, user, create, datafile, num_of_file);
                    Properties.Settings.Default.state = true;
                    sa.exeproc(docid);

                }
                catch (SqlException ex)
                {

                    MessageBox.Show("" + ex);
                }
                finally
                {
                    con.Close();
                }
                label8.ForeColor = Color.White;
                label8.Text = "تمت الاضافة بنجاح";
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                dateTimePicker1.ResetText();
                dateTimePicker2.ResetText();
                comboBox1.ResetText();
                comboBox2.ResetText();
                comboBox3.ResetText();

            }
            else
            {
                return;
                
            }


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
        public void fiilcom2()
        {
            string s1 = "select * from DistenationArch";
            SqlCommand cmd1 = new SqlCommand(s1, con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            System.Data.DataTable dt1 = new System.Data.DataTable();
                da1.Fill(dt1);
                comboBox2.DataSource = dt1;
                comboBox2.DisplayMember = "DistName";
                comboBox2.ValueMember = "DistID";

        }

        public void fiilcom3()
        {
            string s2 = "select * from DepartmentArch";
            SqlCommand cmd2 = new SqlCommand(s2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            System.Data.DataTable dt2 = new System.Data.DataTable();
                da2.Fill(dt2);
                comboBox3.DataSource = dt2;
                comboBox3.DisplayMember = "DepartName";
                comboBox3.ValueMember = "DepartID";




        }
        private void AddFile_Load(object sender, EventArgs e)
        {
            fiilcom1();
            fiilcom2();
            fiilcom3();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {


        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public bool check_not_null()
        {
             if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.SelectedIndex <0 || comboBox2.SelectedIndex <0 || comboBox3.SelectedIndex <0)
            {


            label8.ForeColor = Color.Red;
            label8.Text= "الرجاء تعبئة الحقول الفارغة";
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool check_true_value()
        {
            
            if(textBox1.Text is string && textBox2.Text is string  && textBox3.Text is string)
            {
                return true;
            }
            else
            {
             label8.ForeColor = Color.Red;
             label8.Text="الرجاء تعبئة الحقول بالقيم الصحيحة";
                return false;

            }
        }

        public bool check_file()
        {
            if(axAcroPDF1.src==null && richTextBox1.Text=="")
            {
               label8.ForeColor = Color.Red;
               label8.Text="المعلومات المدخلة غير مقترنة بملف";
                return false;
            }
            else 
            {
                return true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManageKind mg = new ManageKind();
            mg.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ManageDist md = new ManageDist();
            md.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ManageDepart md = new ManageDepart();
            md.Show();
        }
    }
        }
    


