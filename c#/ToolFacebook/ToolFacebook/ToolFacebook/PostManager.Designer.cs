﻿namespace ToolFacebook
{
    partial class PostManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostManager));
            this.dataGrbPost = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrbPost)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrbPost
            // 
            this.dataGrbPost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrbPost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrbPost.Location = new System.Drawing.Point(0, 0);
            this.dataGrbPost.Name = "dataGrbPost";
            this.dataGrbPost.Size = new System.Drawing.Size(375, 275);
            this.dataGrbPost.TabIndex = 0;
            this.dataGrbPost.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrbPost_CellClick);
            // 
            // PostManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 275);
            this.Controls.Add(this.dataGrbPost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PostManager";
            this.Text = "PostManager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrbPost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrbPost;
    }
}