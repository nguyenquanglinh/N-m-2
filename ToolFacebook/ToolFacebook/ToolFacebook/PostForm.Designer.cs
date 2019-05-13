namespace ToolFacebook
{
    partial class PostForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GrbText = new System.Windows.Forms.GroupBox();
            this.txtTextPost = new System.Windows.Forms.TextBox();
            this.btnOpenImg = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAnh = new System.Windows.Forms.TextBox();
            this.GrbText.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrbText
            // 
            this.GrbText.Controls.Add(this.txtTextPost);
            this.GrbText.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrbText.Location = new System.Drawing.Point(0, 0);
            this.GrbText.Name = "GrbText";
            this.GrbText.Size = new System.Drawing.Size(322, 136);
            this.GrbText.TabIndex = 2;
            this.GrbText.TabStop = false;
            this.GrbText.Text = "Bài viết  :";
            // 
            // txtTextPost
            // 
            this.txtTextPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextPost.Location = new System.Drawing.Point(0, 19);
            this.txtTextPost.Multiline = true;
            this.txtTextPost.Name = "txtTextPost";
            this.txtTextPost.Size = new System.Drawing.Size(313, 117);
            this.txtTextPost.TabIndex = 0;
            // 
            // btnOpenImg
            // 
            this.btnOpenImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenImg.Location = new System.Drawing.Point(3, 275);
            this.btnOpenImg.Name = "btnOpenImg";
            this.btnOpenImg.Size = new System.Drawing.Size(102, 23);
            this.btnOpenImg.TabIndex = 3;
            this.btnOpenImg.Text = "Chọn ảnh/video";
            this.btnOpenImg.UseVisualStyleBackColor = true;
            this.btnOpenImg.Click += new System.EventHandler(this.btnOpenImg_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(211, 275);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu bài viết";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtAnh
            // 
            this.txtAnh.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtAnh.Location = new System.Drawing.Point(0, 136);
            this.txtAnh.Name = "txtAnh";
            this.txtAnh.ReadOnly = true;
            this.txtAnh.Size = new System.Drawing.Size(100, 20);
            this.txtAnh.TabIndex = 6;
            this.txtAnh.Text = "Ảnh\\Video";
            this.txtAnh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtAnh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpenImg);
            this.Controls.Add(this.GrbText);
            this.Name = "PostForm";
            this.Size = new System.Drawing.Size(322, 322);
            this.GrbText.ResumeLayout(false);
            this.GrbText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox GrbText;
        private System.Windows.Forms.TextBox txtTextPost;
        private System.Windows.Forms.Button btnOpenImg;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAnh;
    }
}
