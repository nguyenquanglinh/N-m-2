namespace ToolFacebook
{
    partial class SelectUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectUser));
            this.btnAccep = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.selectObjUser = new ToolFacebook.SelectObj();
            this.SuspendLayout();
            // 
            // btnAccep
            // 
            this.btnAccep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccep.Location = new System.Drawing.Point(0, 175);
            this.btnAccep.Name = "btnAccep";
            this.btnAccep.Size = new System.Drawing.Size(75, 23);
            this.btnAccep.TabIndex = 1;
            this.btnAccep.Text = "Chọn xong";
            this.btnAccep.UseVisualStyleBackColor = true;
            this.btnAccep.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(211, 175);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // selectObjUser
            // 
            this.selectObjUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectObjUser.Location = new System.Drawing.Point(0, 0);
            this.selectObjUser.Name = "selectObjUser";
            this.selectObjUser.Size = new System.Drawing.Size(286, 141);
            this.selectObjUser.TabIndex = 2;
            // 
            // SelectUser
            // 
            this.AcceptButton = this.btnAccep;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(286, 200);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.selectObjUser);
            this.Controls.Add(this.btnAccep);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectUser";
            this.Text = "Chọn tài khoản đăng nhập";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAccep;
        private SelectObj selectObjUser;
        private System.Windows.Forms.Button btnClose;
    }
}