namespace Runch.View
{
    partial class JoinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoinForm));
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIdChecked = new System.Windows.Forms.Button();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnIdUnChecked = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.Font = new System.Drawing.Font("한컴 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtId.Location = new System.Drawing.Point(60, 230);
            this.txtId.Margin = new System.Windows.Forms.Padding(0);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(259, 26);
            this.txtId.TabIndex = 1;
            this.txtId.Text = "사원 번호";
            this.txtId.Click += new System.EventHandler(this.InitIdByClick);
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            this.txtId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckIdByEnterKeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(48, 227);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 34);
            this.label1.TabIndex = 0;
            // 
            // btnIdChecked
            // 
            this.btnIdChecked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(231)))), ((int)(((byte)(253)))));
            this.btnIdChecked.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIdChecked.BackgroundImage")));
            this.btnIdChecked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIdChecked.FlatAppearance.BorderSize = 0;
            this.btnIdChecked.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIdChecked.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdChecked.Location = new System.Drawing.Point(355, 226);
            this.btnIdChecked.Margin = new System.Windows.Forms.Padding(2);
            this.btnIdChecked.Name = "btnIdChecked";
            this.btnIdChecked.Size = new System.Drawing.Size(36, 36);
            this.btnIdChecked.TabIndex = 3;
            this.btnIdChecked.TabStop = false;
            this.btnIdChecked.UseVisualStyleBackColor = false;
            this.btnIdChecked.Click += new System.EventHandler(this.CheckId);
            // 
            // cmbGroup
            // 
            this.cmbGroup.BackColor = System.Drawing.Color.White;
            this.cmbGroup.Font = new System.Drawing.Font("한컴 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(48, 336);
            this.cmbGroup.Margin = new System.Windows.Forms.Padding(10);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(342, 34);
            this.cmbGroup.TabIndex = 4;
            this.cmbGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InvalidateInput);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(48, 281);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 34);
            this.label2.TabIndex = 33;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("한컴 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtName.Location = new System.Drawing.Point(60, 286);
            this.txtName.Margin = new System.Windows.Forms.Padding(0);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(259, 26);
            this.txtName.TabIndex = 3;
            this.txtName.Text = "이름";
            this.txtName.Click += new System.EventHandler(this.InitNameByClick);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JoinByEnterKeyDown);
            // 
            // cmbPosition
            // 
            this.cmbPosition.BackColor = System.Drawing.Color.White;
            this.cmbPosition.Font = new System.Drawing.Font("한컴 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(48, 389);
            this.cmbPosition.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(342, 34);
            this.cmbPosition.TabIndex = 5;
            this.cmbPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InvalidateInput);
            // 
            // btnJoin
            // 
            this.btnJoin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.btnJoin.FlatAppearance.BorderSize = 0;
            this.btnJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoin.Font = new System.Drawing.Font("이사만루체 Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnJoin.ForeColor = System.Drawing.Color.White;
            this.btnJoin.Location = new System.Drawing.Point(48, 444);
            this.btnJoin.Margin = new System.Windows.Forms.Padding(2);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(343, 46);
            this.btnJoin.TabIndex = 0;
            this.btnJoin.Text = "JOIN";
            this.btnJoin.UseVisualStyleBackColor = false;
            this.btnJoin.Click += new System.EventHandler(this.Join);
            // 
            // btnIdUnChecked
            // 
            this.btnIdUnChecked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(231)))), ((int)(((byte)(253)))));
            this.btnIdUnChecked.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIdUnChecked.BackgroundImage")));
            this.btnIdUnChecked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIdUnChecked.FlatAppearance.BorderSize = 0;
            this.btnIdUnChecked.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnIdUnChecked.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIdUnChecked.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdUnChecked.Location = new System.Drawing.Point(355, 226);
            this.btnIdUnChecked.Margin = new System.Windows.Forms.Padding(2);
            this.btnIdUnChecked.Name = "btnIdUnChecked";
            this.btnIdUnChecked.Size = new System.Drawing.Size(36, 36);
            this.btnIdUnChecked.TabIndex = 2;
            this.btnIdUnChecked.UseVisualStyleBackColor = false;
            this.btnIdUnChecked.Click += new System.EventHandler(this.CheckId);
            // 
            // JoinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(444, 638);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIdUnChecked);
            this.Controls.Add(this.btnIdChecked);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "JoinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Run for lunch";
            this.Load += new System.EventHandler(this.InitCmb);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIdChecked;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnIdUnChecked;
    }
}