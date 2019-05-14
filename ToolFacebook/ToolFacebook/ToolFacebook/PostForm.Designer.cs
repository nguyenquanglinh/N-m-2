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
            this.grbImg = new System.Windows.Forms.GroupBox();
            this.GrbText.SuspendLayout();
            this.grbImg.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrbText
            // 
            this.GrbText.Controls.Add(this.grbImg);
            this.GrbText.Controls.Add(this.txtTextPost);
            this.GrbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbText.Location = new System.Drawing.Point(0, 0);
            this.GrbText.Name = "GrbText";
            this.GrbText.Size = new System.Drawing.Size(322, 322);
            this.GrbText.TabIndex = 2;
            this.GrbText.TabStop = false;
            this.GrbText.Text = "Bài viết  :";
            // 
            // txtTextPost
            // 
            this.txtTextPost.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTextPost.Location = new System.Drawing.Point(3, 16);
            this.txtTextPost.Multiline = true;
            this.txtTextPost.Name = "txtTextPost";
            this.txtTextPost.Size = new System.Drawing.Size(316, 142);
            this.txtTextPost.TabIndex = 0;
            // 
            // btnOpenImg
            // 
            this.btnOpenImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenImg.Location = new System.Drawing.Point(-3, 138);
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
            this.btnSave.Location = new System.Drawing.Point(217, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu bài viết";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grbImg
            // 
            this.grbImg.Controls.Add(this.btnSave);
            this.grbImg.Controls.Add(this.btnOpenImg);
            this.grbImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbImg.Location = new System.Drawing.Point(3, 158);
            this.grbImg.Name = "grbImg";
            this.grbImg.Size = new System.Drawing.Size(316, 161);
            this.grbImg.TabIndex = 1;
            this.grbImg.TabStop = false;
            this.grbImg.Text = "Ảnh/video :";
            // 
            // PostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrbText);
            this.Name = "PostForm";
            this.Size = new System.Drawing.Size(322, 322);
            this.GrbText.ResumeLayout(false);
            this.GrbText.PerformLayout();
            this.grbImg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GrbText;
        private System.Windows.Forms.TextBox txtTextPost;
        private System.Windows.Forms.Button btnOpenImg;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grbImg;
    }
}
