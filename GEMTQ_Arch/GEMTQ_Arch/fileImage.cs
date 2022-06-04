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
    public partial class fileImage : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MyCnn);
        selectdata sa = new selectdata();
        public fileImage()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileImage_Load(object sender, EventArgs e)
        {
            sa.GET_data(Convert.ToInt32(fileslist.getMainForm.dataGridView1.CurrentRow.Cells[0].Value));
            string s = "select *from DataTableTempSecondary where DocID='" + Convert.ToInt32(fileslist.getMainForm.dataGridView1.CurrentRow.Cells[0].Value) + "'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ext = dt.Rows[0]["Extintions"].ToString();
            string path = dt.Rows[0]["Datapath"].ToString();
            int dataid = Convert.ToInt32(dt.Rows[0]["DocID"]);
            if (ext == ".txt")
            {
                richTextBox1.Visible = true;
                richTextBox1.LoadFile(path);

            }
            else if (ext == ".doc" || ext == ".docx")
            {

                richTextBox1.Visible = true;
                richTextBox1.LoadFile(path);

            }
            else if (ext == ".pdf")
            {
                axAcroPDF1.Visible = true;
                axAcroPDF1.src = path;
            }
            else if(ext== ".jpeg" || ext == ".jpg")
            {
                string[] list = new string[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list[i] = dt.Rows[i]["Datapath"].ToString();

                    if (i == 0)
                    {
                        pictureBox1.Visible = true;
                        pictureBox1.Image = Image.FromFile(list[0]);
                    }
                    else if (i == 1)
                    {
                        pictureBox3.Visible = true;
                        pictureBox3.Image = Image.FromFile(list[1]);
                    }
                    else if (i == 2)
                    {
                        pictureBox4.Visible = true;
                        pictureBox4.Image = Image.FromFile(list[2]);

                    }
                    else if (i == 3)
                    {
                        pictureBox5.Visible = true;
                        pictureBox5.Image = Image.FromFile(list[3]);

                    }
                    else if (i == 4)
                    {
                        pictureBox6.Visible = true;
                        pictureBox6.Image = Image.FromFile(list[4]);

                    }
                    else if (i == 5)
                    {
                        pictureBox7.Visible = true;
                        pictureBox7.Image = Image.FromFile(list[5]);

                    }
                    else if (i == 6)
                    {
                        pictureBox8.Visible = true;
                        pictureBox8.Image = Image.FromFile(list[6]);

                    }
                    else if (i == 7)
                    {
                        pictureBox9.Visible = true;
                        pictureBox9.Image = Image.FromFile(list[7]);

                    }
                    else if (i == 8)
                    {
                        pictureBox10.Visible = true;
                        pictureBox10.Image = Image.FromFile(list[8]);

                    }
                    else if (i == 9)
                    {
                        pictureBox11.Visible = true;
                        pictureBox11.Image = Image.FromFile(list[9]);

                    }
                    else if (i == 10)
                    {
                        pictureBox12.Visible = true;
                        pictureBox12.Image = Image.FromFile(list[10]);

                    }
                    else if (i == 11)
                    {
                        pictureBox13.Visible = true;
                        pictureBox13.Image = Image.FromFile(list[11]);

                    }
                    else if (i == 12)
                    {
                        pictureBox14.Visible = true;
                        pictureBox14.Image = Image.FromFile(list[12]);

                    }
                    else if (i == 13)
                    {
                        pictureBox15.Visible = true;
                        pictureBox15.Image = Image.FromFile(list[13]);

                    }
                    else if (i == 14)
                    {
                        pictureBox16.Visible = true;
                        pictureBox16.Image = Image.FromFile(list[14]);

                    }
                    else if (i == 15)
                    {
                        pictureBox17.Visible = true;
                        pictureBox17.Image = Image.FromFile(list[15]);

                    }
                    else if (i > 15)
                    {
                        MessageBox.Show("لا يمكن عرض أكثر من 14 صورة");
                    }





                }








            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox3.Image;
            pictureBox3.Image = null;
            pictureBox3.Image = img;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox4.Image;
            pictureBox4.Image = null;
            pictureBox4.Image = img;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox5.Image;
            pictureBox5.Image = null;
            pictureBox5.Image = img;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox6.Image;
            pictureBox6.Image = null;
            pictureBox6.Image = img;

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox7.Image;
            pictureBox7.Image = null;
            pictureBox7.Image = img;

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox8.Image;
            pictureBox8.Image = null;
            pictureBox8.Image = img;

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox9.Image;
            pictureBox9.Image = null;
            pictureBox9.Image = img;

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox10.Image;
            pictureBox10.Image = null;
            pictureBox10.Image = img;

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox11.Image;
            pictureBox11.Image = null;
            pictureBox11.Image = img;

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox12.Image;
            pictureBox12.Image = null;
            pictureBox12.Image = img;

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox13.Image;
            pictureBox13.Image = null;
            pictureBox13.Image = img;

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox14.Image;
            pictureBox14.Image = null;
            pictureBox14.Image = img;

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox15.Image;
            pictureBox15.Image = null;
            pictureBox15.Image = img;

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox16.Image;
            pictureBox16.Image = null;
            pictureBox16.Image = img;

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            pictureBox1.Image = null;
            pictureBox1.Image = pictureBox17.Image;
            pictureBox17.Image = null;
            pictureBox17.Image = img;

        }

        private void fileImage_FormClosed(object sender, FormClosedEventArgs e)
        {
            string s = "delete from DataTableTempSecondary where DocID='" + Convert.ToInt32(fileslist.getMainForm.dataGridView1.CurrentRow.Cells[0].Value) + "'";
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
            string s = "select *from DataTableTempSecondary where DocID='" + Convert.ToInt32(fileslist.getMainForm.dataGridView1.CurrentRow.Cells[0].Value) + "'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ext = dt.Rows[0]["Extintions"].ToString();
            if(ext==".jpeg" || ext == ".jpg")
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
            else if (ext==".txt" || ext==".doc" || ext==".docx")
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
    }
    }

