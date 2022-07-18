namespace TuVanMuaMayTinh_HCG_Nhom5
{
    partial class BTL_HCG
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxHoi = new System.Windows.Forms.GroupBox();
            this.btNext = new System.Windows.Forms.Button();
            this.comboBoxTraLoi = new System.Windows.Forms.ComboBox();
            this.lbCauHoi = new System.Windows.Forms.Label();
            this.groupBoxTuVan = new System.Windows.Forms.GroupBox();
            this.groupBoxProgess = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btLamMoi = new System.Windows.Forms.Button();
            this.iTalk_ProgressBar1 = new iTalk_ProgressBar();
            this.groupBoxHoi.SuspendLayout();
            this.groupBoxTuVan.SuspendLayout();
            this.groupBoxProgess.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxHoi
            // 
            this.groupBoxHoi.Controls.Add(this.pictureBox1);
            this.groupBoxHoi.Controls.Add(this.btLamMoi);
            this.groupBoxHoi.Controls.Add(this.btNext);
            this.groupBoxHoi.Controls.Add(this.comboBoxTraLoi);
            this.groupBoxHoi.Controls.Add(this.lbCauHoi);
            this.groupBoxHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBoxHoi.Location = new System.Drawing.Point(13, 77);
            this.groupBoxHoi.Name = "groupBoxHoi";
            this.groupBoxHoi.Size = new System.Drawing.Size(363, 446);
            this.groupBoxHoi.TabIndex = 0;
            this.groupBoxHoi.TabStop = false;
            // 
            // btNext
            // 
            this.btNext.Image = global::TuVanMuaMayTinh_HCG_Nhom5.Properties.Resources.next_button;
            this.btNext.Location = new System.Drawing.Point(198, 363);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(137, 55);
            this.btNext.TabIndex = 2;
            this.btNext.Text = "Tiếp theo";
            this.btNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // comboBoxTraLoi
            // 
            this.comboBoxTraLoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTraLoi.FormattingEnabled = true;
            this.comboBoxTraLoi.Location = new System.Drawing.Point(24, 276);
            this.comboBoxTraLoi.Name = "comboBoxTraLoi";
            this.comboBoxTraLoi.Size = new System.Drawing.Size(311, 28);
            this.comboBoxTraLoi.TabIndex = 1;
            // 
            // lbCauHoi
            // 
            this.lbCauHoi.AutoSize = true;
            this.lbCauHoi.Location = new System.Drawing.Point(21, 238);
            this.lbCauHoi.Name = "lbCauHoi";
            this.lbCauHoi.Size = new System.Drawing.Size(75, 20);
            this.lbCauHoi.TabIndex = 0;
            this.lbCauHoi.Text = "Câu hỏi!";
            // 
            // groupBoxTuVan
            // 
            this.groupBoxTuVan.Controls.Add(this.groupBoxProgess);
            this.groupBoxTuVan.Controls.Add(this.treeView1);
            this.groupBoxTuVan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBoxTuVan.Location = new System.Drawing.Point(382, 77);
            this.groupBoxTuVan.Name = "groupBoxTuVan";
            this.groupBoxTuVan.Size = new System.Drawing.Size(591, 446);
            this.groupBoxTuVan.TabIndex = 1;
            this.groupBoxTuVan.TabStop = false;
            this.groupBoxTuVan.Text = "CÂY QUYẾT ĐỊNH";
            this.groupBoxTuVan.Enter += new System.EventHandler(this.groupBoxTuVan_Enter);
            // 
            // groupBoxProgess
            // 
            this.groupBoxProgess.Controls.Add(this.label1);
            this.groupBoxProgess.Controls.Add(this.iTalk_ProgressBar1);
            this.groupBoxProgess.Location = new System.Drawing.Point(6, 42);
            this.groupBoxProgess.Name = "groupBoxProgess";
            this.groupBoxProgess.Size = new System.Drawing.Size(585, 398);
            this.groupBoxProgess.TabIndex = 6;
            this.groupBoxProgess.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(151, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Khởi tạo cây quyết định..";
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.treeView1.Location = new System.Drawing.Point(6, 42);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(579, 398);
            this.treeView1.TabIndex = 0;
            this.treeView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseMove);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dlToolStripMenuItem,
            this.luatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(10);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10);
            this.menuStrip1.Size = new System.Drawing.Size(985, 64);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dlToolStripMenuItem
            // 
            this.dlToolStripMenuItem.Name = "dlToolStripMenuItem";
            this.dlToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.dlToolStripMenuItem.Size = new System.Drawing.Size(83, 44);
            this.dlToolStripMenuItem.Text = "Dữ liệu";
            this.dlToolStripMenuItem.Click += new System.EventHandler(this.dlToolStripMenuItem_Click);
            // 
            // luatToolStripMenuItem
            // 
            this.luatToolStripMenuItem.Name = "luatToolStripMenuItem";
            this.luatToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.luatToolStripMenuItem.Size = new System.Drawing.Size(99, 44);
            this.luatToolStripMenuItem.Text = "Giải thích";
            this.luatToolStripMenuItem.Click += new System.EventHandler(this.luatToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TuVanMuaMayTinh_HCG_Nhom5.Properties.Resources.analytics__1_;
            this.pictureBox1.Location = new System.Drawing.Point(63, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btLamMoi
            // 
            this.btLamMoi.Image = global::TuVanMuaMayTinh_HCG_Nhom5.Properties.Resources.refresh;
            this.btLamMoi.Location = new System.Drawing.Point(24, 363);
            this.btLamMoi.Name = "btLamMoi";
            this.btLamMoi.Size = new System.Drawing.Size(141, 55);
            this.btLamMoi.TabIndex = 3;
            this.btLamMoi.Text = "Làm mới";
            this.btLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLamMoi.UseVisualStyleBackColor = true;
            this.btLamMoi.Click += new System.EventHandler(this.btLamMoi_Click);
            // 
            // iTalk_ProgressBar1
            // 
            this.iTalk_ProgressBar1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.iTalk_ProgressBar1.Location = new System.Drawing.Point(187, 49);
            this.iTalk_ProgressBar1.Maximum = ((long)(100));
            this.iTalk_ProgressBar1.MinimumSize = new System.Drawing.Size(100, 100);
            this.iTalk_ProgressBar1.Name = "iTalk_ProgressBar1";
            this.iTalk_ProgressBar1.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.iTalk_ProgressBar1.ProgressColor2 = System.Drawing.Color.Blue;
            this.iTalk_ProgressBar1.ProgressShape = iTalk_ProgressBar._ProgressShape.Round;
            this.iTalk_ProgressBar1.Size = new System.Drawing.Size(230, 230);
            this.iTalk_ProgressBar1.TabIndex = 5;
            this.iTalk_ProgressBar1.Value = ((long)(0));
            this.iTalk_ProgressBar1.Click += new System.EventHandler(this.iTalk_ProgressBar1_Click);
            // 
            // BTL_HCG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(985, 535);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBoxTuVan);
            this.Controls.Add(this.groupBoxHoi);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BTL_HCG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tư vấn mua laptop";
            this.Load += new System.EventHandler(this.BTL_HCG_Load);
            this.groupBoxHoi.ResumeLayout(false);
            this.groupBoxHoi.PerformLayout();
            this.groupBoxTuVan.ResumeLayout(false);
            this.groupBoxProgess.ResumeLayout(false);
            this.groupBoxProgess.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxHoi;
        private System.Windows.Forms.Button btLamMoi;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.ComboBox comboBoxTraLoi;
        private System.Windows.Forms.Label lbCauHoi;
        private System.Windows.Forms.GroupBox groupBoxTuVan;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolTip toolTip1;
        private iTalk_ProgressBar iTalk_ProgressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem luatToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxProgess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

