namespace GEMTQ_Arch
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ملفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolscreateuser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsstriplogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsstripcancel = new System.Windows.Forms.ToolStripMenuItem();
            this.changepassword = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelprogram = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsstripdecumment = new System.Windows.Forms.ToolStripMenuItem();
            this.ادارةالوجهاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ادارةالانواعToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ادارةالملفاتToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ادارةالملفاتToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageuser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsstripaddfile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsstripsend = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsstripdisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.استعراضالملفاتالمرسلةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recivemessage = new System.Windows.Forms.ToolStripMenuItem();
            this.filelist = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ملفToolStripMenuItem,
            this.toolsstripdecumment,
            this.toolsstripaddfile,
            this.toolsstripsend,
            this.toolsstripdisplay});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(188, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 430, 2);
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1191, 82);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ملفToolStripMenuItem
            // 
            this.ملفToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ملفToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolscreateuser,
            this.toolsstriplogin,
            this.toolsstripcancel,
            this.changepassword,
            this.cancelprogram});
            this.ملفToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ملفToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ملفToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ملفToolStripMenuItem.Image")));
            this.ملفToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ملفToolStripMenuItem.Name = "ملفToolStripMenuItem";
            this.ملفToolStripMenuItem.Size = new System.Drawing.Size(62, 78);
            this.ملفToolStripMenuItem.Text = "ملف";
            this.ملفToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.ملفToolStripMenuItem.Click += new System.EventHandler(this.ملفToolStripMenuItem_Click);
            // 
            // toolscreateuser
            // 
            this.toolscreateuser.BackColor = System.Drawing.SystemColors.MenuBar;
            this.toolscreateuser.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolscreateuser.Name = "toolscreateuser";
            this.toolscreateuser.Size = new System.Drawing.Size(202, 28);
            this.toolscreateuser.Text = "أنشاء حساب";
            this.toolscreateuser.Click += new System.EventHandler(this.تسجيلالدخولToolStripMenuItem_Click);
            // 
            // toolsstriplogin
            // 
            this.toolsstriplogin.BackColor = System.Drawing.SystemColors.MenuBar;
            this.toolsstriplogin.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolsstriplogin.Name = "toolsstriplogin";
            this.toolsstriplogin.Size = new System.Drawing.Size(202, 28);
            this.toolsstriplogin.Text = "تسجيل الدخول";
            this.toolsstriplogin.Click += new System.EventHandler(this.تسجيلالدخولToolStripMenuItem1_Click);
            // 
            // toolsstripcancel
            // 
            this.toolsstripcancel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.toolsstripcancel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolsstripcancel.Name = "toolsstripcancel";
            this.toolsstripcancel.Size = new System.Drawing.Size(202, 28);
            this.toolsstripcancel.Text = "تسجيل خروج";
            this.toolsstripcancel.Click += new System.EventHandler(this.تسجيلخروجToolStripMenuItem_Click);
            // 
            // changepassword
            // 
            this.changepassword.BackColor = System.Drawing.SystemColors.MenuBar;
            this.changepassword.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.changepassword.Name = "changepassword";
            this.changepassword.Size = new System.Drawing.Size(202, 28);
            this.changepassword.Text = "تغيير كلمة المرور";
            this.changepassword.Click += new System.EventHandler(this.changepassword_Click);
            // 
            // cancelprogram
            // 
            this.cancelprogram.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cancelprogram.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cancelprogram.Name = "cancelprogram";
            this.cancelprogram.Size = new System.Drawing.Size(202, 28);
            this.cancelprogram.Text = "أيقاف التشغيل";
            this.cancelprogram.Click += new System.EventHandler(this.أيقافالتشغيلToolStripMenuItem_Click);
            // 
            // toolsstripdecumment
            // 
            this.toolsstripdecumment.BackColor = System.Drawing.SystemColors.MenuBar;
            this.toolsstripdecumment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ادارةالوجهاتToolStripMenuItem,
            this.ادارةالانواعToolStripMenuItem,
            this.ادارةالملفاتToolStripMenuItem1,
            this.ادارةالملفاتToolStripMenuItem2,
            this.manageuser});
            this.toolsstripdecumment.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolsstripdecumment.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolsstripdecumment.Image = ((System.Drawing.Image)(resources.GetObject("toolsstripdecumment.Image")));
            this.toolsstripdecumment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsstripdecumment.Name = "toolsstripdecumment";
            this.toolsstripdecumment.Size = new System.Drawing.Size(109, 78);
            this.toolsstripdecumment.Text = "ادارة الوثائق";
            this.toolsstripdecumment.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // ادارةالوجهاتToolStripMenuItem
            // 
            this.ادارةالوجهاتToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ادارةالوجهاتToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ادارةالوجهاتToolStripMenuItem.Name = "ادارةالوجهاتToolStripMenuItem";
            this.ادارةالوجهاتToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.ادارةالوجهاتToolStripMenuItem.Text = "ادارة الوجهات";
            this.ادارةالوجهاتToolStripMenuItem.Click += new System.EventHandler(this.ادارةالوجهاتToolStripMenuItem_Click);
            // 
            // ادارةالانواعToolStripMenuItem
            // 
            this.ادارةالانواعToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ادارةالانواعToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ادارةالانواعToolStripMenuItem.Name = "ادارةالانواعToolStripMenuItem";
            this.ادارةالانواعToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.ادارةالانواعToolStripMenuItem.Text = "ادارة الانواع";
            this.ادارةالانواعToolStripMenuItem.Click += new System.EventHandler(this.ادارةالانواعToolStripMenuItem_Click);
            // 
            // ادارةالملفاتToolStripMenuItem1
            // 
            this.ادارةالملفاتToolStripMenuItem1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ادارةالملفاتToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ادارةالملفاتToolStripMenuItem1.Name = "ادارةالملفاتToolStripMenuItem1";
            this.ادارةالملفاتToolStripMenuItem1.Size = new System.Drawing.Size(200, 28);
            this.ادارةالملفاتToolStripMenuItem1.Text = "ادارة الاقسام";
            this.ادارةالملفاتToolStripMenuItem1.Click += new System.EventHandler(this.ادارةالملفاتToolStripMenuItem1_Click);
            // 
            // ادارةالملفاتToolStripMenuItem2
            // 
            this.ادارةالملفاتToolStripMenuItem2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ادارةالملفاتToolStripMenuItem2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ادارةالملفاتToolStripMenuItem2.Name = "ادارةالملفاتToolStripMenuItem2";
            this.ادارةالملفاتToolStripMenuItem2.Size = new System.Drawing.Size(200, 28);
            this.ادارةالملفاتToolStripMenuItem2.Text = "ادارة الملفات";
            this.ادارةالملفاتToolStripMenuItem2.Click += new System.EventHandler(this.ادارةالملفاتToolStripMenuItem2_Click);
            // 
            // manageuser
            // 
            this.manageuser.BackColor = System.Drawing.SystemColors.MenuBar;
            this.manageuser.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.manageuser.Name = "manageuser";
            this.manageuser.Size = new System.Drawing.Size(200, 28);
            this.manageuser.Text = "ادارة المستخدمين";
            this.manageuser.Click += new System.EventHandler(this.ادارةالمستخدمينToolStripMenuItem_Click);
            // 
            // toolsstripaddfile
            // 
            this.toolsstripaddfile.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolsstripaddfile.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolsstripaddfile.Image = ((System.Drawing.Image)(resources.GetObject("toolsstripaddfile.Image")));
            this.toolsstripaddfile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsstripaddfile.Name = "toolsstripaddfile";
            this.toolsstripaddfile.Size = new System.Drawing.Size(98, 78);
            this.toolsstripaddfile.Text = "أضافة ملف";
            this.toolsstripaddfile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolsstripaddfile.Click += new System.EventHandler(this.أضافةملفToolStripMenuItem_Click);
            // 
            // toolsstripsend
            // 
            this.toolsstripsend.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolsstripsend.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolsstripsend.Image = ((System.Drawing.Image)(resources.GetObject("toolsstripsend.Image")));
            this.toolsstripsend.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsstripsend.Name = "toolsstripsend";
            this.toolsstripsend.Size = new System.Drawing.Size(98, 78);
            this.toolsstripsend.Text = "أرسال ملف";
            this.toolsstripsend.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolsstripsend.Click += new System.EventHandler(this.أرسالملفToolStripMenuItem_Click);
            // 
            // toolsstripdisplay
            // 
            this.toolsstripdisplay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.استعراضالملفاتالمرسلةToolStripMenuItem,
            this.recivemessage,
            this.filelist});
            this.toolsstripdisplay.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolsstripdisplay.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolsstripdisplay.Image = ((System.Drawing.Image)(resources.GetObject("toolsstripdisplay.Image")));
            this.toolsstripdisplay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsstripdisplay.Name = "toolsstripdisplay";
            this.toolsstripdisplay.Size = new System.Drawing.Size(95, 78);
            this.toolsstripdisplay.Text = "استعراض ";
            this.toolsstripdisplay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolsstripdisplay.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolsstripdisplay.Click += new System.EventHandler(this.استعراضالملفاتToolStripMenuItem_Click);
            // 
            // استعراضالملفاتالمرسلةToolStripMenuItem
            // 
            this.استعراضالملفاتالمرسلةToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuBar;
            this.استعراضالملفاتالمرسلةToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.استعراضالملفاتالمرسلةToolStripMenuItem.Name = "استعراضالملفاتالمرسلةToolStripMenuItem";
            this.استعراضالملفاتالمرسلةToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.استعراضالملفاتالمرسلةToolStripMenuItem.Text = "البريد الصادر";
            this.استعراضالملفاتالمرسلةToolStripMenuItem.Click += new System.EventHandler(this.استعراضالملفاتالمرسلةToolStripMenuItem_Click);
            // 
            // recivemessage
            // 
            this.recivemessage.BackColor = System.Drawing.SystemColors.MenuBar;
            this.recivemessage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.recivemessage.Name = "recivemessage";
            this.recivemessage.Size = new System.Drawing.Size(170, 28);
            this.recivemessage.Text = "البريد الوارد";
            this.recivemessage.Click += new System.EventHandler(this.استعراضكلالملفاتToolStripMenuItem_Click);
            // 
            // filelist
            // 
            this.filelist.BackColor = System.Drawing.SystemColors.MenuBar;
            this.filelist.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.filelist.Name = "filelist";
            this.filelist.Size = new System.Drawing.Size(170, 28);
            this.filelist.Text = "قائمة الملفات";
            this.filelist.Click += new System.EventHandler(this.استعراضكلالملفاتToolStripMenuItem1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1163, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(262, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1191, 427);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الواجهة الرئيسية";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem ملفToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ادارةالوجهاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ادارةالانواعToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ادارةالملفاتToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ادارةالملفاتToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem استعراضالملفاتالمرسلةToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem toolscreateuser;
        public System.Windows.Forms.ToolStripMenuItem toolsstriplogin;
        public System.Windows.Forms.ToolStripMenuItem toolsstripcancel;
        public System.Windows.Forms.ToolStripMenuItem toolsstripdecumment;
        public System.Windows.Forms.ToolStripMenuItem toolsstripaddfile;
        public System.Windows.Forms.ToolStripMenuItem toolsstripsend;
        public System.Windows.Forms.ToolStripMenuItem toolsstripdisplay;
        public System.Windows.Forms.ToolStripMenuItem changepassword;
        public System.Windows.Forms.ToolStripMenuItem recivemessage;
        public System.Windows.Forms.ToolStripMenuItem filelist;
        public System.Windows.Forms.ToolStripMenuItem manageuser;
        public System.Windows.Forms.ToolStripMenuItem cancelprogram;
    }
}