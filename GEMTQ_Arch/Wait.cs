using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEMTQ_Arch
{
    public partial class Wait : Form
    {
        public Wait()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
            timer1.Enabled = false;

        }

        private void Wait_Load(object sender, EventArgs e)
        {
           

        }
    }
}
