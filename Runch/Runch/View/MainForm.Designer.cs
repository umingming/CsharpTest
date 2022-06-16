namespace Runch.View
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
            this.btnRecommend = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnUserIcon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btnRecommend.Location = new System.Drawing.Point(43, 270);
            this.btnRecommend.Name = "btnRecommend";
            this.btnRecommend.Size = new System.Drawing.Size(155, 140);
            this.btnRecommend.TabIndex = 0;
            this.btnRecommend.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecommend.UseVisualStyleBackColor = false;
            this.btnRecommend.Click += new System.EventHandler(this.RecommendLunch);
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.Transparent;
            this.btnList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnList.FlatAppearance.BorderSize = 0;
            this.btnList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Font = new System.Drawing.Font("한컴 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnList.Location = new System.Drawing.Point(254, 274);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(135, 130);
            this.btnList.TabIndex = 1;
            this.btnList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.ListRestaurant);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(231)))), ((int)(((byte)(253)))));
            this.btnUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUser.BackgroundImage")));
            this.btnUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnUser.Location = new System.Drawing.Point(332, 203);
            this.btnUser.Margin = new System.Windows.Forms.Padding(0);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(88, 40);
            this.btnUser.TabIndex = 0;
            this.btnUser.UseVisualStyleBackColor = false;
            // 
            // btnUserIcon
            // 
            this.btnUserIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnUserIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUserIcon.BackgroundImage")));
            this.btnUserIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserIcon.FlatAppearance.BorderSize = 0;
            this.btnUserIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserIcon.Location = new System.Drawing.Point(313, 211);
            this.btnUserIcon.Name = "btnUserIcon";
            this.btnUserIcon.Size = new System.Drawing.Size(24, 24);
            this.btnUserIcon.TabIndex = 3;
            this.btnUserIcon.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("한컴 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(69, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "점심 추천";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("한컴 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(271, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "식당 목록";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(444, 639);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRecommend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUserIcon);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnList);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "aim Systems";
            this.Load += new System.EventHandler(this.InitUserInfo);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRecommend;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnUserIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}