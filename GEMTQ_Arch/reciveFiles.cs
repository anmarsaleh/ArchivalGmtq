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
    public partial class reciveFiles : Form
    {
        private static reciveFiles frm;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);
        selectdata sa = new selectdata();
        public reciveFiles()
        {
            if (frm == null)
                frm = this;

            InitializeComponent();
        }
        static void frm_FORMClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static reciveFiles getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new reciveFiles();
                    frm.FormClosed += new FormClosedEventHandler(frm_FORMClosed);
                }
                return frm;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reciveFiles_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

                dataGridView1.DataSource = sa.recivedata(Program.user_id);



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "SELECT TransFiles.DocID as 'رقم الملف',Users.UserName 'اسم المرسل',TransID as '  رقم النقل', DocName as'اسم الملف' ,TransDate as'تاريخ الارسال' ,IsReciveFile as'حالة الاستقبال' ,ReciveDate as'تاريخ الاستقبال' ,TransNote as 'ملاحظات المرسل',RespondNote as 'ملاحظاتي' FROM DocumentsArch INNER JOIN  TransFiles ON DocumentsArch.DocID = TransFiles.DocID INNER JOIN  Users ON DocumentsArch.UserID = Users.UserID and ReciveUserID ='" + Program.user_id + "'ORDER BY TransID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FileDetails df = new FileDetails();
            df.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = "SELECT TransFiles.DocID as 'رقم الملف',Users.UserName 'اسم المرسل',TransID as '  رقم النقل', DocName as'اسم الملف' ,TransDate as'تاريخ الارسال' ,IsReciveFile as'حالة الاستقبال' ,ReciveDate as'تاريخ الاستقبال' ,TransNote as 'ملاحظات المرسل',RespondNote as 'ملاحظاتي' FROM DocumentsArch INNER JOIN  TransFiles ON DocumentsArch.DocID = TransFiles.DocID INNER JOIN  Users ON DocumentsArch.UserID = Users.UserID and ReciveUserID ='" + Program.user_id + "'ORDER BY TransID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;


        }
    }
}
