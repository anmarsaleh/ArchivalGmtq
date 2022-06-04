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
        //byte[] datafile;
        private static AddFile frm;
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
                    //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                    richTextBox1.Visible = true;
                   
                }

           else     if (ext == ".pdf" && size < 10240000)
                {
                    axAcroPDF1.Visible = true;
                    richTextBox1.Visible = false;
                    label15.Text = openFileDialog1.FileName;
                    axAcroPDF1.src = label15.Text;
                    //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                    //datafile = System.IO.File.ReadAllBytes(label15.Text);
                }

                else if (ext == ".doc" || ext == ".docx" && size < 102400)
                    {
                    richTextBox1.Visible = true;
                    axAcroPDF1.Visible = false;
                    //string filePath = null;
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
                            //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                            //datafile = encoding.GetBytes(richTextBox1.Text);   

                    }

                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                    }
                else
                {
                    MessageBox.Show("حجم الملف كبير جدا");

                }


            }
            }

        private void button2_Click(object sender, EventArgs e)
        {

            if(textBox1.Text!=null || textBox2.Text!=null || textBox3.Text!=null || textBox5.Text!=null)
            {
                Wait asa = new Wait();
                asa.ShowDialog();
                string s = "insert into DocumentsArch values ('" + comboBox1.SelectedValue + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.ToString() + "','" + comboBox2.SelectedValue + "','" + comboBox3.SelectedValue + "','" + textBox1.Text + "','" + textBox5.Text + "','" + ext + "','" + dateTimePicker2.Value.ToString() + "','" + Program.user_id + "','" + DateTime.Now.ToString() + "')";
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
                    string s1 = "SELECT TOP 1 [DocID] FROM DocumentsArch ORDER BY [DocID] DESC";
                    SqlCommand cmd1 = new SqlCommand(s1, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    int id = Convert.ToInt32(dt.Rows[0]["DocID"]);
                    string s12 = "INSERT DataTableTmp (DocID,DataFile)SELECT '" + id + "',DataFile.*FROM OPENROWSET (BULK '" +label15.Text + "', SINGLE_BLOB) DataFile  ";
                    SqlCommand cmdq = new SqlCommand(s12, con);
                    try
                    {
                        con.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                    cmdq.ExecuteNonQuery();
                    con.Close();
                    Add_sec asd = new Add_sec();
                    asd.ShowDialog();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                dateTimePicker1.ResetText();
                dateTimePicker2.ResetText();
            }
        }

        private void AddFile_Load(object sender, EventArgs e)
        {
            string s = "select * from KindDocuments";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "KindName";
            comboBox1.ValueMember = "KindID";

            string s1 = "select * from DistenationArch";
            SqlCommand cmd1 = new SqlCommand(s1, con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            System.Data.DataTable dt1 = new System.Data.DataTable();
            da1.Fill(dt1);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "DistName";
            comboBox2.ValueMember = "DistID";


            string s2 = "select * from DepartmentArch";
            SqlCommand cmd2 = new SqlCommand(s2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            System.Data.DataTable dt2 = new System.Data.DataTable();
            da2.Fill(dt2);
            comboBox3.DataSource = dt2;
            comboBox3.DisplayMember = "DepartName";
            comboBox3.ValueMember = "DepartID";


        }
    }
        }
    


