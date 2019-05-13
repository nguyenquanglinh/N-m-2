namespace ToolFacebook
{
    partial class ChangeUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUser));
            this.btnUpdatePass = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.userFormChangeUser = new ToolFacebook.UserForm();
            this.SuspendLayout();
            // 
            // btnUpdatePass
            // 
            this.btnUpdatePass.Location = new System.Drawing.Point(28, 90);
            this.btnUpdatePass.Name = "btnUpdatePass";
            this.btnUpdatePass.Size = new System.Drawing.Size(100, 37);
            this.btnUpdatePass.TabIndex = 1;
            this.btnUpdatePass.Text = "Cập nhật mật khẩu";
            this.btnUpdatePass.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpdatePass.UseVisualStyleBackColor = true;
            this.btnUpdatePass.Click += new System.EventHandler(this.btnUpdatePass_Click);
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(157, 90);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(87, 23);
            this.Remove.TabIndex = 2;
            this.Remove.Text = "Xóa tài khoản";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(112, 148);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Location = new System.Drawing.Point(157, 119);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(87, 23);
            this.btnChangePass.TabIndex = 4;
            this.btnChangePass.Text = "Đổi mật khẩu";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click_1);
            // 
            // userFormChangeUser
            // 
            this.userFormChangeUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.userFormChangeUser.Location = new System.Drawing.Point(0, 0);
            this.userFormChangeUser.Name = "userFormChangeUser";
            this.userFormChangeUser.Size = new System.Drawing.Size(272, 77);
            this.userFormChangeUser.TabIndex = 0;
            // 
            // ChangeUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 183);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.btnUpdatePass);
            this.Controls.Add(this.userFormChangeUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeUser";
            this.Text = "Thay đổi tài khoản";
            this.ResumeLayout(false);

        }

        #endregion

        private UserForm userFormChangeUser;
        private System.Windows.Forms.Button btnUpdatePass;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnChangePass;
    }
}