namespace Runch.View
{
    partial class DetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.txtAdoption = new System.Windows.Forms.TextBox();
            this.txtSignature = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtRecentAdoption = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBlock = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnBlockTxt = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUnblock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(434, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 9;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtAdoption
            // 
            this.txtAdoption.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdoption.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAdoption.Location = new System.Drawing.Point(240, 154);
            this.txtAdoption.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdoption.Name = "txtAdoption";
            this.txtAdoption.Size = new System.Drawing.Size(120, 24);
            this.txtAdoption.TabIndex = 15;
            this.txtAdoption.Text = "3932";
            // 
            // txtSignature
            // 
            this.txtSignature.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSignature.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSignature.Location = new System.Drawing.Point(240, 127);
            this.txtSignature.Margin = new System.Windows.Forms.Padding(2);
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.Size = new System.Drawing.Size(120, 24);
            this.txtSignature.TabIndex = 12;
            this.txtSignature.Text = "연어초밥";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(149, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "선정 횟수:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(149, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "추천 메뉴:";
            // 
            // txtCategory
            // 
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCategory.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCategory.Location = new System.Drawing.Point(354, 78);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(2);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(65, 24);
            this.txtCategory.TabIndex = 11;
            this.txtCategory.Text = "/";
            this.txtCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("한컴 고딕", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtName.Location = new System.Drawing.Point(-1, 52);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(469, 58);
            this.txtName.TabIndex = 10;
            this.txtName.Text = "사카나";
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRecentAdoption
            // 
            this.txtRecentAdoption.BackColor = System.Drawing.Color.White;
            this.txtRecentAdoption.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecentAdoption.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRecentAdoption.Location = new System.Drawing.Point(235, 181);
            this.txtRecentAdoption.Margin = new System.Windows.Forms.Padding(2);
            this.txtRecentAdoption.Multiline = true;
            this.txtRecentAdoption.Name = "txtRecentAdoption";
            this.txtRecentAdoption.Size = new System.Drawing.Size(125, 49);
            this.txtRecentAdoption.TabIndex = 17;
            this.txtRecentAdoption.Text = "3932";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(133, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "마지막 선정:";
            // 
            // btnBlock
            // 
            this.btnBlock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBlock.BackgroundImage")));
            this.btnBlock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBlock.FlatAppearance.BorderSize = 0;
            this.btnBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlock.Location = new System.Drawing.Point(161, 8);
            this.btnBlock.Margin = new System.Windows.Forms.Padding(2);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(24, 24);
            this.btnBlock.TabIndex = 18;
            this.btnBlock.UseVisualStyleBackColor = true;
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(22, 7);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(24, 24);
            this.btnEdit.TabIndex = 19;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(91, 7);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 24);
            this.button3.TabIndex = 20;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBlockTxt
            // 
            this.btnBlockTxt.FlatAppearance.BorderSize = 0;
            this.btnBlockTxt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBlockTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlockTxt.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBlockTxt.Location = new System.Drawing.Point(176, 2);
            this.btnBlockTxt.Margin = new System.Windows.Forms.Padding(2);
            this.btnBlockTxt.Name = "btnBlockTxt";
            this.btnBlockTxt.Size = new System.Drawing.Size(110, 34);
            this.btnBlockTxt.TabIndex = 21;
            this.btnBlockTxt.Text = "차단";
            this.btnBlockTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBlockTxt.UseVisualStyleBackColor = true;
            this.btnBlockTxt.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button5.Location = new System.Drawing.Point(37, 2);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(74, 34);
            this.button5.TabIndex = 22;
            this.button5.Text = "수정";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("한컴 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(107, 2);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 34);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "삭제";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUnblock
            // 
            this.btnUnblock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUnblock.BackgroundImage")));
            this.btnUnblock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUnblock.FlatAppearance.BorderSize = 0;
            this.btnUnblock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUnblock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnblock.Location = new System.Drawing.Point(161, 8);
            this.btnUnblock.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnblock.Name = "btnUnblock";
            this.btnUnblock.Size = new System.Drawing.Size(24, 24);
            this.btnUnblock.TabIndex = 24;
            this.btnUnblock.UseVisualStyleBackColor = true;
            this.btnUnblock.Visible = false;
            this.btnUnblock.Click += new System.EventHandler(this.btnUnblock_Click);
            // 
            // DetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(470, 229);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnBlock);
            this.Controls.Add(this.txtRecentAdoption);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAdoption);
            this.Controls.Add(this.txtSignature);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnUnblock);
            this.Controls.Add(this.btnBlockTxt);
            this.Controls.Add(this.btnDelete);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtAdoption;
        private System.Windows.Forms.TextBox txtSignature;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtRecentAdoption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBlock;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnBlockTxt;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUnblock;
    }
}