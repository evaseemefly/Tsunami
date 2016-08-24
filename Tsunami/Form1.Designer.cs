namespace Tsunami
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lv_fileInfo = new System.Windows.Forms.ListView();
            this.col_fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_Start = new System.Windows.Forms.ToolStripButton();
            this.tsb_CloseSong = new System.Windows.Forms.ToolStripButton();
            this.tsb_StopWatch = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(211, 14);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(747, 198);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lv_fileInfo);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(0, 398);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(964, 218);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "地震信息";
            // 
            // lv_fileInfo
            // 
            this.lv_fileInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_fileName});
            this.lv_fileInfo.Location = new System.Drawing.Point(6, 14);
            this.lv_fileInfo.Name = "lv_fileInfo";
            this.lv_fileInfo.Size = new System.Drawing.Size(199, 198);
            this.lv_fileInfo.TabIndex = 3;
            this.lv_fileInfo.UseCompatibleStateImageBehavior = false;
            this.lv_fileInfo.View = System.Windows.Forms.View.Details;
            this.lv_fileInfo.Click += new System.EventHandler(this.lv_fileInfo_Click);
            // 
            // col_fileName
            // 
            this.col_fileName.Text = "文件名称";
            this.col_fileName.Width = 180;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(964, 372);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Start,
            this.tsb_StopWatch,
            this.tsb_CloseSong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(964, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_Start
            // 
            this.tsb_Start.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Start.Image")));
            this.tsb_Start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Start.Name = "tsb_Start";
            this.tsb_Start.Size = new System.Drawing.Size(76, 22);
            this.tsb_Start.Text = "启动监控";
            this.tsb_Start.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsb_CloseSong
            // 
            this.tsb_CloseSong.Image = ((System.Drawing.Image)(resources.GetObject("tsb_CloseSong.Image")));
            this.tsb_CloseSong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_CloseSong.Name = "tsb_CloseSong";
            this.tsb_CloseSong.Size = new System.Drawing.Size(76, 22);
            this.tsb_CloseSong.Text = "关闭报警";
            this.tsb_CloseSong.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tsb_StopWatch
            // 
            this.tsb_StopWatch.Image = ((System.Drawing.Image)(resources.GetObject("tsb_StopWatch.Image")));
            this.tsb_StopWatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_StopWatch.Name = "tsb_StopWatch";
            this.tsb_StopWatch.Size = new System.Drawing.Size(76, 22);
            this.tsb_StopWatch.Text = "关闭监控";
            this.tsb_StopWatch.Click += new System.EventHandler(this.toolStripButton3_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 616);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "国家海洋局海啸预警系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_Start;
        private System.Windows.Forms.ToolStripButton tsb_CloseSong;
        private System.Windows.Forms.ListView lv_fileInfo;
        private System.Windows.Forms.ColumnHeader col_fileName;
        private System.Windows.Forms.ToolStripButton tsb_StopWatch;
    }
}

