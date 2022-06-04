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
    public partial class FileDetails : Form
    {
        private static FileDetails frm;


        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);
        selectdata sa = new selectdata();
        public FileDetails()
        {
            if (frm == null)
                frm = this;

            InitializeComponent();
            
        }
        static void frm_FORMClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FileDetails getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new FileDetails();
                    frm.FormClosed += new FormClosedEventHandler(frm_FORMClosed);
                }
                return frm;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FileDetails_Load(object sender, EventArgs e)
        {
            List<object> destList = new List<object>();
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewRow row in reciveFiles.getMainForm.dataGridView1.SelectedRows)
                destList.Add(row.DataBoundItem);
               dataGridView1.DataSource = destList;
            if(dataGridView1.Rows.Count != 0)
            {
                string s = "update TransFiles set IsReciveFile='" + true + "' where TransID='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) + "'";
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
                reciveFiles.getMainForm.dataGridView1.DataSource = sa.recivedata(Program.user_id);
                fillgraid();


            }
        }
     

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "update TransFiles set RespondNote='" + textBox1.Text + "' where TransID='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) + "'";
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
            reciveFiles.getMainForm.dataGridView1.DataSource = sa.recivedata(Program.user_id);
            textBox1.Clear();
            fillgraid();
        }
        public void fillgraid()
        {
                this.dataGridView1.DataSource = sa.DetailTrans(Convert.ToInt32(reciveFiles.getMainForm.dataGridView1.CurrentRow.Cells[0].Value));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayFile ds = new DisplayFile();
            ds.ShowDialog();
        }
    }
}
