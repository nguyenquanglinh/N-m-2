﻿namespace ToolFacebook
{
    partial class SelectPost
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
            this.selectObjPost = new ToolFacebook.SelectObj();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAccep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectObjPost
            // 
            this.selectObjPost.AutoScroll = true;
            this.selectObjPost.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectObjPost.Location = new System.Drawing.Point(0, 0);
            this.selectObjPost.Name = "selectObjPost";
            this.selectObjPost.Size = new System.Drawing.Size(263, 141);
            this.selectObjPost.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(162, 164);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAccep
            // 
            this.btnAccep.Location = new System.Drawing.Point(46, 164);
            this.btnAccep.Name = "btnAccep";
            this.btnAccep.Size = new System.Drawing.Size(75, 23);
            this.btnAccep.TabIndex = 4;
            this.btnAccep.Text = "Chọn xong";
            this.btnAccep.UseVisualStyleBackColor = true;
            this.btnAccep.Click += new System.EventHandler(this.btnAccep_Click);
            // 
            // SelectPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 202);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAccep);
            this.Controls.Add(this.selectObjPost);
            this.Name = "SelectPost";
            this.Text = "Chọn bài viết để đăng";
            this.ResumeLayout(false);

        }

        #endregion

        private SelectObj selectObjPost;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAccep;
    }
}