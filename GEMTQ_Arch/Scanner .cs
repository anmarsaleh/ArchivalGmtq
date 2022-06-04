using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WIATest;
using System.IO;
using System.Data.SqlClient;
namespace GEMTQ_Arch
{
    public partial class scannar : Form
    {
        private static scannar frm;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);
        static int count = 0;
        Image[] images;
        selectdata sa = new selectdata();
        public scannar()
        {
            if (frm == null)
                frm = this;

            InitializeComponent();
        }
        static void frm_FORMClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static scannar getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new scannar();
                    frm.FormClosed += new FormClosedEventHandler(frm_FORMClosed);
                }
                return frm;
            }
        }

        //button click event
        private void btn_scan_Click(object sender, EventArgs e)
        {

            try
            {
                List<string> devices = WIAScanner.GetDevices();

                foreach (string device in devices)
                {
                    lbDevices.Items.Add(device);
                }
                if (lbDevices.Items.Count == 0)
                {
                    label8.ForeColor = Color.Red;
                    label8.Text="You do not have any WIA devices.";
                    this.Close();
                }
                else
                {
                    lbDevices.SelectedIndex = 0;
                }

                images = WIAScanner.Scan((string)lbDevices.SelectedItem).ToArray();
                PictureBox[] picture = new PictureBox[images.Length];
                int x = 1113;
                int y = 269;
                for (int i = 0; i < images.Length; i++)
                {
                    pic_scan.Image = images[i];
                    pic_scan.Show();
                    pic_scan.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(picture[i]);
                    picture[i].Visible = true;
                    picture[i].Show();
                    picture[i].Image = pic_scan.Image;
                    picture[i].Size = new Size(74, 59);
                    picture[i].Location = new Point(x,y);
                    picture[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    x = x - 106;
                    if (picture[i].Location.X ==panel1.Location.X)
                    {
                        x = x + 417;
                        y = y + 88;

                    }

                    count++;  
               } 
          
         
              



            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        private void Home_SizeChanged(object sender, EventArgs e)
        {
            int pheight = this.Size.Height - 153;
            pic_scan.Size = new Size(pheight - 150, pheight);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool check_not_null()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.SelectedIndex <= 0 || comboBox2.SelectedIndex <= 0 || comboBox3.SelectedIndex <= 0)
            {

                label8.ForeColor = Color.Red;
                label8.Text="الرجاء تعبئة الحقول الفارغة";
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool check_true_value()
        {

            if (textBox1.Text is string && textBox2.Text is string && textBox3.Text is string)
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
            if (images==null && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.SelectedIndex > 0 && comboBox2.SelectedIndex > 0 && comboBox3.SelectedIndex > 0)
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
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (check_not_null() == true && check_true_value() == true && check_file()==true)
            {

                Wait SS = new Wait();
                SS.ShowDialog();

                string s = "select isnull(max(DocumentsArch.DocID),0)+1 from DocumentsArch ";
                SqlCommand cmd = new SqlCommand(s, con);
                try
                {
                    con.Open();
                    int docid = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    int kind = Convert.ToInt32(comboBox1.SelectedValue);
                    string publicn = textBox2.Text;
                    string innern = textBox3.Text;
                    string DateOfDoc = dateTimePicker1.Value.ToShortDateString();
                    int dist = Convert.ToInt32(comboBox2.SelectedValue);
                    int dept = Convert.ToInt32(comboBox3.SelectedValue);
                    string subject = textBox1.Text;
                    string docname = "" + docid + "_" + kind + "_";
                    string RemaindDate = dateTimePicker2.Value.ToShortDateString();
                    int user = Program.user_id;
                    string create = DateTime.Now.ToShortDateString();
                    Wait asa = new Wait();
                    asa.ShowDialog();
                    string ext = ".jpeg";
                    sa.insertintodoc(docid,kind, publicn, innern, DateOfDoc, dist, dept, subject, docname, ext, RemaindDate, user, create , images.Length);
                    //byte[] data = new byte[images.Length];
                    //byte[] data1;
                    for (int i = 0; i < images.Length; i++)
                    {
                        byte[] data =  (byte[])(new ImageConverter()).ConvertTo(images[i], typeof(byte[]));
                        //data1= ImageToByteArray(images[i]);
                        sa.insertintodatatemp(docid, data);
                    }
                    label8.ForeColor = Color.White;
                    label8.Text="تمت الاضافة بنجاح";
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    dateTimePicker1.ResetText();
                    dateTimePicker2.ResetText();
                    Properties.Settings.Default.state = true;
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    comboBox3.ResetText();
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
            else
            {
                return;
            }
        }

        private void scannar_Load(object sender, EventArgs e)
        {
            fiilcom1();
            fiilcom2();
            fiilcom3();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pic_scan.Top = (int)(pic_scan.Top - (pic_scan.Height * 0.025));
            pic_scan.Left = (int)(pic_scan.Left - (pic_scan.Width * 0.025));
            pic_scan.Height = (int)(pic_scan.Height + (pic_scan.Height * 0.05));
            pic_scan.Width = (int)(pic_scan.Width + (pic_scan.Width * 0.05));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pic_scan.Top = (int)(pic_scan.Top + (pic_scan.Height * 0.025));
            pic_scan.Left = (int)(pic_scan.Left + (pic_scan.Width * 0.025));
            pic_scan.Height = (int)(pic_scan.Height - (pic_scan.Height * 0.05));
            pic_scan.Width = (int)(pic_scan.Width - (pic_scan.Width * 0.05));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image img = pic_scan.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pic_scan.Image = img;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Image img = pic_scan.Image;
            img.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pic_scan.Image = img;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ManageKind md = new ManageKind();
            md.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ManageDepart bf = new ManageDepart();
            bf.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ManageDist ds = new ManageDist();
            ds.Show();
        }

    }
}
