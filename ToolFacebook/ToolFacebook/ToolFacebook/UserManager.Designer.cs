namespace ToolFacebook
{
    partial class UserManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManager));
            this.btnMo = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.GrbListUser = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GrbListUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMo
            // 
            this.btnMo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMo.Location = new System.Drawing.Point(1, 225);
            this.btnMo.Name = "btnMo";
            this.btnMo.Size = new System.Drawing.Size(75, 23);
            this.btnMo.TabIndex = 1;
            this.btnMo.Text = "Chọn";
            this.btnMo.UseVisualStyleBackColor = true;
            this.btnMo.Click += new System.EventHandler(this.btnMo_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Location = new System.Drawing.Point(213, 225);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // GrbListUser
            // 
            this.GrbListUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrbListUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbListUser.Location = new System.Drawing.Point(0, 0);
            this.GrbListUser.Name = "GrbListUser";
            this.GrbListUser.Size = new System.Drawing.Size(287, 251);
            this.GrbListUser.TabIndex = 3;
            this.GrbListUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrbListUser_CellContentClick);
            // 
            // UserManager
            // 
            this.AcceptButton = this.btnMo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(287, 251);
            this.Controls.Add(this.GrbListUser);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnMo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserManager";
            this.Text = "UserManager";
            ((System.ComponentModel.ISupportInitialize)(this.GrbListUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMo;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView GrbListUser;
    }
}