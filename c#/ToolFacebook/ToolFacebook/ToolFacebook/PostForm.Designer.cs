﻿namespace ToolFacebook
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
            this.grbImg = new System.Windows.Forms.GroupBox();
            this.btnOpenImg = new System.Windows.Forms.Button();
            this.txtTextPost = new System.Windows.Forms.TextBox();
            this.GrbText.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrbText
            // 
            this.GrbText.Controls.Add(this.grbImg);
            this.GrbText.Controls.Add(this.btnOpenImg);
            this.GrbText.Controls.Add(this.txtTextPost);
            this.GrbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbText.Location = new System.Drawing.Point(0, 0);
            this.GrbText.Name = "GrbText";
            this.GrbText.Size = new System.Drawing.Size(322, 322);
            this.GrbText.TabIndex = 2;
            this.GrbText.TabStop = false;
            this.GrbText.Text = "Bài viết  :";
            // 
            // grbImg
            // 
            this.grbImg.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbImg.Location = new System.Drawing.Point(3, 158);
            this.grbImg.Name = "grbImg";
            this.grbImg.Size = new System.Drawing.Size(316, 132);
            this.grbImg.TabIndex = 1;
            this.grbImg.TabStop = false;
            this.grbImg.Text = "Ảnh/video :";
            // 
            // btnOpenImg
            // 
            this.btnOpenImg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnOpenImg.Location = new System.Drawing.Point(3, 296);
            this.btnOpenImg.Name = "btnOpenImg";
            this.btnOpenImg.Size = new System.Drawing.Size(316, 23);
            this.btnOpenImg.TabIndex = 3;
            this.btnOpenImg.Text = "Chọn ảnh";
            this.btnOpenImg.UseVisualStyleBackColor = true;
            this.btnOpenImg.Click += new System.EventHandler(this.btnOpenImg_Click);
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
            // PostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrbText);
            this.Name = "PostForm";
            this.Size = new System.Drawing.Size(322, 322);
            this.GrbText.ResumeLayout(false);
            this.GrbText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GrbText;
        private System.Windows.Forms.TextBox txtTextPost;
        private System.Windows.Forms.Button btnOpenImg;
        private System.Windows.Forms.GroupBox grbImg;
    }
}
