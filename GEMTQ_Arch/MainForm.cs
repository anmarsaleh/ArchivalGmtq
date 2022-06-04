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
using System.Net.Sockets;
using System.Threading;
using System.IO;
namespace GEMTQ_Arch
{
    public partial class MainForm : Form
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);

        private static MainForm frm;

        public MainForm()
        {
            if (frm == null)
                frm = this;
            InitializeComponent();
            this.toolsstripcancel.Enabled = false;
            this.toolsstripdecumment.Enabled = false;
            this.toolsstripaddfile.Enabled = false;
            this.toolsstripsend.Enabled = false;
            this.toolsstripdisplay.Enabled = false;
            this.toolsstriplogin.Enabled = true;
            this.toolscreateuser.Enabled = false;
            this.changepassword.Enabled = false;
            this.recivemessage.Enabled = false;
            this.filelist.Enabled = false;
            this.manageuser.Enabled = false;
            this.cancelprogram.Enabled = false;
        }
        static void frm_FORMClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static MainForm getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new MainForm();
                    frm.FormClosed += new FormClosedEventHandler(frm_FORMClosed);
                }
                return frm;
            }
        }

        private void استعراضالملفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUser cm = new CreateUser();
            cm.ShowDialog();
        }

        private void تسجيلالدخولToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            login lg = new login();
            lg.ShowDialog();
        }

        private void تسجيلخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_signout sd = new frm_signout();
            sd.ShowDialog();

        }

        private void ادارةالوجهاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDist ds = new ManageDist();
            ds.ShowDialog();
        }

        private void ادارةالانواعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageKind kd = new ManageKind();
            kd.ShowDialog();

        }

        private void ادارةالملفاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManageDepart fd = new ManageDepart();
            fd.ShowDialog();
        }

        private void ادارةالملفاتToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ManageFile md = new ManageFile();
            md.ShowDialog();
        }

        private void أضافةملفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFile ad = new AddFile();
            ad.ShowDialog();
        }

        private void أرسالملفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransFiles re = new TransFiles();
            re.ShowDialog();
        }

        private void استعراضكلالملفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reciveFiles msg = new reciveFiles();
            msg.ShowDialog();

        }

        private void استعراضالملفاتالمرسلةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TranseMessages wq = new TranseMessages();
            wq.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ملفToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changepassword_Click(object sender, EventArgs e)
        {
            ChangePassword cd = new ChangePassword();
            cd.ShowDialog();
        }

        private void استعراضكلالملفاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fileslist ss = new fileslist();
            ss.ShowDialog();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }
    


        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ادارةالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsers ms = new ManageUsers();
            ms.ShowDialog();
        }

        private void أيقافالتشغيلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "Update Users set IsLogin='" + false + "' ,PcName='' where UserID='" + Program.user_id + "'";
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

            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.MinimizeBox = true;
        }
    }
}
