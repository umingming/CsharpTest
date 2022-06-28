namespace Runch.View
{
    partial class CategoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryForm));
            this.btnJoin = new System.Windows.Forms.Button();
            this.ultraTabbedMdiManager1 = new Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkLikeAll = new System.Windows.Forms.CheckBox();
            this.cklLike = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cklDislike = new System.Windows.Forms.CheckedListBox();
            this.chkDislikeAll = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnMain = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnRecommend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabbedMdiManager1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnJoin
            // 
            this.btnJoin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.btnJoin.FlatAppearance.BorderSize = 0;
            this.btnJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoin.Font = new System.Drawing.Font("이사만루체 Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnJoin.ForeColor = System.Drawing.Color.White;
            this.btnJoin.Location = new System.Drawing.Point(49, 442);
            this.btnJoin.Margin = new System.Windows.Forms.Padding(2);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(343, 46);
            this.btnJoin.TabIndex = 14;
            this.btnJoin.Text = "RUN?";
            this.btnJoin.UseVisualStyleBackColor = false;
            this.btnJoin.Click += new System.EventHandler(this.SelectCategroy);
            // 
            // ultraTabbedMdiManager1
            // 
            this.ultraTabbedMdiManager1.MdiParent = this;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("한컴 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.textBox1.Location = new System.Drawing.Point(43, 4);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(84, 36);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "선호";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkLikeAll
            // 
            this.chkLikeAll.AutoSize = true;
            this.chkLikeAll.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkLikeAll.Location = new System.Drawing.Point(119, 8);
            this.chkLikeAll.Margin = new System.Windows.Forms.Padding(2);
            this.chkLikeAll.Name = "chkLikeAll";
            this.chkLikeAll.Size = new System.Drawing.Size(68, 27);
            this.chkLikeAll.TabIndex = 1;
            this.chkLikeAll.Text = "ALL";
            this.chkLikeAll.UseVisualStyleBackColor = true;
            this.chkLikeAll.Click += new System.EventHandler(this.LikeAll);
            this.chkLikeAll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectCateByEnterKeyDown);
            // 
            // cklLike
            // 
            this.cklLike.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cklLike.CheckOnClick = true;
            this.cklLike.ColumnWidth = 45;
            this.cklLike.Cursor = System.Windows.Forms.Cursors.Default;
            this.cklLike.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cklLike.FormattingEnabled = true;
            this.cklLike.Location = new System.Drawing.Point(35, 58);
            this.cklLike.Margin = new System.Windows.Forms.Padding(2);
            this.cklLike.MultiColumn = true;
            this.cklLike.Name = "cklLike";
            this.cklLike.Size = new System.Drawing.Size(182, 84);
            this.cklLike.TabIndex = 3;
            this.cklLike.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LikeOnlyByCheck);
            this.cklLike.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectCateByEnterKeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cklDislike);
            this.panel1.Controls.Add(this.chkDislikeAll);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.cklLike);
            this.panel1.Controls.Add(this.chkLikeAll);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(25, 238);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 178);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(190, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 136);
            this.label1.TabIndex = 7;
            // 
            // cklDislike
            // 
            this.cklDislike.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cklDislike.CheckOnClick = true;
            this.cklDislike.ColumnWidth = 45;
            this.cklDislike.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cklDislike.FormattingEnabled = true;
            this.cklDislike.Location = new System.Drawing.Point(218, 58);
            this.cklDislike.Margin = new System.Windows.Forms.Padding(2);
            this.cklDislike.MultiColumn = true;
            this.cklDislike.Name = "cklDislike";
            this.cklDislike.Size = new System.Drawing.Size(167, 84);
            this.cklDislike.TabIndex = 6;
            this.cklDislike.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.DislikeOnlyByCheck);
            this.cklDislike.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectCateByEnterKeyDown);
            // 
            // chkDislikeAll
            // 
            this.chkDislikeAll.AutoSize = true;
            this.chkDislikeAll.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkDislikeAll.Location = new System.Drawing.Point(302, 8);
            this.chkDislikeAll.Margin = new System.Windows.Forms.Padding(2);
            this.chkDislikeAll.Name = "chkDislikeAll";
            this.chkDislikeAll.Size = new System.Drawing.Size(68, 27);
            this.chkDislikeAll.TabIndex = 5;
            this.chkDislikeAll.Text = "ALL";
            this.chkDislikeAll.UseVisualStyleBackColor = true;
            this.chkDislikeAll.Click += new System.EventHandler(this.DislikeAll);
            this.chkDislikeAll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectCateByEnterKeyDown);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("한컴 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.textBox2.Location = new System.Drawing.Point(216, 4);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(84, 36);
            this.textBox2.TabIndex = 4;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "비선호";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.Transparent;
            this.btnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Font = new System.Drawing.Font("한컴 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnMain.Location = new System.Drawing.Point(4, -1);
            this.btnMain.Margin = new System.Windows.Forms.Padding(2);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(83, 82);
            this.btnMain.TabIndex = 25;
            this.btnMain.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMain.UseVisualStyleBackColor = false;
            this.btnMain.Click += new System.EventHandler(this.ShowMain);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("한컴 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnLogout.Location = new System.Drawing.Point(360, -1);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(83, 82);
            this.btnLogout.TabIndex = 24;
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.Logout);
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.Transparent;
            this.btnList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnList.FlatAppearance.BorderSize = 0;
            this.btnList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Font = new System.Drawing.Font("한컴 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnList.Location = new System.Drawing.Point(180, -1);
            this.btnList.Margin = new System.Windows.Forms.Padding(2);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(86, 82);
            this.btnList.TabIndex = 23;
            this.btnList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.ShowList);
            // 
            // btnRecommend
            // 
            this.btnRecommend.BackColor = System.Drawing.Color.Transparent;
            this.btnRecommend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRecommend.FlatAppearance.BorderSize = 0;
            this.btnRecommend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRecommend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRecommend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecommend.Font = new System.Drawing.Font("한컴 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRecommend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnRecommend.Location = new System.Drawing.Point(94, -1);
            this.btnRecommend.Margin = new System.Windows.Forms.Padding(2);
            this.btnRecommend.Name = "btnRecommend";
            this.btnRecommend.Size = new System.Drawing.Size(86, 82);
            this.btnRecommend.TabIndex = 22;
            this.btnRecommend.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecommend.UseVisualStyleBackColor = false;
            this.btnRecommend.Click += new System.EventHandler(this.RecommendLunch);
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(444, 638);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnRecommend);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Run for lunch";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Quit);
            this.Load += new System.EventHandler(this.InitCklCate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectCateByEnterKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabbedMdiManager1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnJoin;
        private Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager ultraTabbedMdiManager1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkLikeAll;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnRecommend;
        private System.Windows.Forms.CheckBox chkDislikeAll;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckedListBox cklDislike;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox cklLike;
    }
}