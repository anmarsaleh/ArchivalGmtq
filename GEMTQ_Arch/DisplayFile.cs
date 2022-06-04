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
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Design;
using System.Drawing.Printing;

namespace GEMTQ_Arch
{
    public partial class DisplayFile : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);
        selectdata sa = new selectdata();
        int id;
        int num;

        public DisplayFile()
        {
            InitializeComponent();
        }

        public void pic1(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pictureBox1.Image = pic.Image;

        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void DisplayFile_Load(object sender, EventArgs e)
        {

            id = Convert.ToInt32(FileDetails.getMainForm.dataGridView1.CurrentRow.Cells[0].Value);
            num = Convert.ToInt32(FileDetails.getMainForm.dataGridView1.CurrentRow.Cells[12].Value);
            sa.GET_data(id, num);
            string s = "select * from GetDATA where docid='" + id + "'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ext = dt.Rows[0]["ext"].ToString();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                da.Fill(dt);

                if (dr.Read())
                {
                    if (ext == ".txt")
                    {
                        richTextBox1.Visible = true;
                        richTextBox1.Rtf = dr["datafile"].ToString();

                    }
                    else if (ext == ".doc" || ext == ".docx")
                    {

                        richTextBox1.Visible = true;
                        richTextBox1.Rtf = dr["datafile"].ToString();

                    }
                    else if (ext == ".pdf")
                    {
                        byte[] result = (byte[])dr["datafile"];
                        string sFile = "E:\\test.pdf";
                        FileStream fs = File.Create(sFile);
                        fs.Close();
                        File.WriteAllBytes(@"E:\\test.pdf", result);
                        axAcroPDF1.Visible = true;
                        axAcroPDF1.src = "E:\\test.pdf";
                    }


                    else if (ext == ".jpeg")
                    {
                        Image img;
                        byte[] result;
                        int x = 600;
                        int y = 570;
                        for (int i = 0; i < num; i++)
                        {
                            PictureBox picture = new PictureBox();
                            result = (byte[])dt.Rows[i]["datafile"];
                            img = byteArrayToImage(result);
                            pictureBox1.Image = img;
                            pictureBox1.Show();
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            string PicName = "P" + Convert.ToString(i) + "";
                            picture.Name = PicName;
                            picture.Size = new Size(74, 59);
                            picture.Location = new Point(x, y);
                            picture.BackColor = Color.Red;
                            picture.BorderStyle = BorderStyle.FixedSingle;
                            picture.SizeMode = PictureBoxSizeMode.StretchImage;
                            this.Controls.Add(picture);
                            picture.Click += new EventHandler(pic1);
                            picture.Image = img;
                            picture.Show();
                            picture.Refresh();
                            x = x - 80;
                            img = null;
                        }


                    }

                }
                con.Close();


            }
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                con.Close();
            }

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

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            string s = "delete from GetDATA where DocID='" + Convert.ToInt32(FileDetails.getMainForm.dataGridView1.Rows[0].Cells[0].Value) + "'";
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
            Directory.Delete("E:\\test.pdf");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = (int)(pictureBox1.Top - (pictureBox1.Height * 0.025));
            pictureBox1.Left = (int)(pictureBox1.Left - (pictureBox1.Width * 0.025));
            pictureBox1.Height = (int)(pictureBox1.Height + (pictureBox1.Height * 0.05));
            pictureBox1.Width = (int)(pictureBox1.Width + (pictureBox1.Width * 0.05));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = (int)(pictureBox1.Top + (pictureBox1.Height * 0.025));
            pictureBox1.Left = (int)(pictureBox1.Left + (pictureBox1.Width * 0.025));
            pictureBox1.Height = (int)(pictureBox1.Height - (pictureBox1.Height * 0.05));
            pictureBox1.Width = (int)(pictureBox1.Width - (pictureBox1.Width * 0.05));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = img;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            img.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = img;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = "select *from GetDATA where DocID='" + Convert.ToInt32(FileDetails.getMainForm.dataGridView1.CurrentRow.Cells[0].Value) + "'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ext = dt.Rows[0]["ext"].ToString();
            if (ext == ".jpeg" || ext == ".jpg")
            {
                System.Drawing.Printing.PrintDocument myPrintDocument1 = new System.Drawing.Printing.PrintDocument();
                PrintDialog myPrinDialog1 = new PrintDialog();
                myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(myPrintDocument2_PrintPage);
                myPrinDialog1.Document = myPrintDocument1;

                if (myPrinDialog1.ShowDialog() == DialogResult.OK)
                {
                    myPrintDocument1.Print();
                }

            }
            else if (ext == ".txt" || ext == ".doc" || ext == ".docx")
            {
                PrintDocument doc = new PrintDocument();
                PrintDialog pd = new PrintDialog();
                PrintPreviewDialog ppd = new PrintPreviewDialog();
                ppd.Document = doc;
                pd.Document = doc;
                doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
                if (ppd.ShowDialog() == DialogResult.OK)
                {
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        doc.Print();
                    }
                }

            }

        }
        private void myPrintDocument2_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap myBitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(myBitmap1, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(myBitmap1, 0, 0);
            myBitmap1.Dispose();
        }
        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int x = 10;
            int y = 0;
            int charpos = 0;
            while (charpos < richTextBox1.Text.Length)
            {
                if (richTextBox1.Text[charpos] == '\n')
                {
                    charpos++;
                    y += 20;
                    x = 10;
                }
                else if (richTextBox1.Text[charpos] == '\r')
                {
                    charpos++;
                }
                else
                {
                    richTextBox1.Select(charpos, 1);
                    e.Graphics.DrawString(richTextBox1.SelectedText, richTextBox1.SelectionFont, new SolidBrush(richTextBox1.SelectionColor), new PointF(x, y));
                    x = x + 8;
                    charpos++;
                }
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            string s = "delete from GetDATA where DocID='" + Convert.ToInt32(FileDetails.getMainForm.dataGridView1.Rows[0].Cells[0].Value) + "'";
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
            Directory.Delete("E:\\test.pdf");


        }
    }
}
