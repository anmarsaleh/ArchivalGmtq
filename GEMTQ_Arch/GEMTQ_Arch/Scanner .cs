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
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);
       static int count = 0;
        public scannar()
        {
            InitializeComponent();
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
                    MessageBox.Show("You do not have any WIA devices.");
                    this.Close();
                }
                else
                {
                    lbDevices.SelectedIndex = 0;
                }

                List<Image> images = WIAScanner.Scan((string)lbDevices.SelectedItem);
                foreach (Image image in images)
                {
                    pic_scan.Image = image;
                    pic_scan.Show();
                    pic_scan.SizeMode = PictureBoxSizeMode.StretchImage;
                    image.Save(@"E:\" + "scannar" +"_'"+count+"'"+ ".jpeg", ImageFormat.Jpeg);
                    if(pic_scan != null)
                    {
                        pictureBox17.Visible = false;
                        if (count == 0)
                        {
                            pictureBox17.Visible = false;
                            pictureBox2.Visible = true;
                            pictureBox2.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 1)
                        {
                            pictureBox17.Visible = false;
                            pictureBox3.Visible = true;
                            pictureBox3.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 2)
                        {
                            pictureBox17.Visible = false;

                            pictureBox4.Visible = true;
                            pictureBox4.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 3)
                        {
                            pictureBox17.Visible = false;

                            pictureBox5.Visible = true;
                            pictureBox5.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 4)
                        {
                            pictureBox17.Visible = false;

                            pictureBox6.Visible = true;
                            pictureBox6.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 5)
                        {
                            pictureBox17.Visible = false;

                            pictureBox7.Visible = true;
                            pictureBox7.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 6)
                        {
                            pictureBox17.Visible = false;

                            pictureBox8.Visible = true;
                            pictureBox8.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 7)
                        {
                            pictureBox17.Visible = false;

                            pictureBox9.Visible = true;
                            pictureBox9.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 8)
                        {
                            pictureBox17.Visible = false;

                            pictureBox10.Visible = true;
                            pictureBox10.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 9)
                        {
                            pictureBox17.Visible = false;

                            pictureBox11.Visible = true;
                            pictureBox11.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 10)
                        {
                            pictureBox17.Visible = false;

                            pictureBox12.Visible = true;
                            pictureBox12.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 11)
                        {
                            pictureBox17.Visible = false;

                            pictureBox13.Visible = true;
                            pictureBox13.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 12)
                        {
                            pictureBox17.Visible = false;

                            pictureBox14.Visible = true;
                            pictureBox14.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 13)
                        {
                            pictureBox17.Visible = false;

                            pictureBox15.Visible = true;
                            pictureBox15.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count == 14)
                        {
                            pictureBox17.Visible = false;

                            pictureBox16.Visible = true;
                            pictureBox16.Image = pic_scan.Image;
                            pic_scan.Image = null;
                        }
                        if (count > 14)
                        {
                            pictureBox17.Visible = false;

                            MessageBox.Show("لايمكن ادخال أكثر من 14 صورة ");
                        }
                    }
                }
              
                count++;

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
        
        private void button2_Click(object sender, EventArgs e)
        {
            Wait SS = new Wait();
            SS.ShowDialog();
            string s = "insert into DocumentsArch values ('" + comboBox1.SelectedValue + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.ToString() + "','" + comboBox2.SelectedValue + "','" + comboBox3.SelectedValue + "','" + textBox1.Text + "','" + textBox5.Text + "','.jpeg','" + dateTimePicker2.Value.ToString() + "','" + Program.user_id + "','" + DateTime.Now.ToString() + "')";
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
            for(int i=0; i<= count; i++)
            {
                string s12 = "INSERT DataTableTmp (DocID,DataFile)SELECT '" + id + "',DataFile.*FROM OPENROWSET (BULK '" + "E:\" + scannar +_'" + i + "'" + ".jpeg" + "', SINGLE_BLOB) DataFile  ";
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
                Directory.Delete("E:\" + scannar +_'" + i + "'" + ".jpeg");
            }
            MessageBox.Show("تمت أضافة الملف  بنجاح");


        }

        private void scannar_Load(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox2.Image;
            pictureBox2.Image = null;
            pictureBox2.Image = img;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox3.Image;
            pictureBox3.Image = null;
            pictureBox3.Image = img;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox4.Image;
            pictureBox4.Image = null;
            pictureBox4.Image = img;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox5.Image;
            pictureBox5.Image = null;
            pictureBox5.Image = img;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox6.Image;
            pictureBox6.Image = null;
            pictureBox6.Image = img;

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox7.Image;
            pictureBox7.Image = null;
            pictureBox7.Image = img;

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox8.Image;
            pictureBox8.Image = null;
            pictureBox8.Image = img;

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox9.Image;
            pictureBox9.Image = null;
            pictureBox9.Image = img;

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox10.Image;
            pictureBox10.Image = null;
            pictureBox10.Image = img;

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox11.Image;
            pictureBox11.Image = null;
            pictureBox11.Image = img;

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox12.Image;
            pictureBox12.Image = null;
            pictureBox12.Image = img;

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox13.Image;
            pictureBox13.Image = null;
            pictureBox13.Image = img;

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox14.Image;
            pictureBox14.Image = null;
            pictureBox14.Image = img;

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox15.Image;
            pictureBox15.Image = null;
            pictureBox15.Image = img;

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;

            Image img = pic_scan.Image;
            pic_scan.Image = null;
            pic_scan.Image = pictureBox16.Image;
            pictureBox16.Image = null;
            pictureBox16.Image = img;

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
    }
}
