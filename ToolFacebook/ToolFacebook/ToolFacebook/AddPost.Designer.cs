namespace ToolFacebook
{
    partial class AddPost
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
            this.postForm1 = new ToolFacebook.PostForm();
            this.SuspendLayout();
            // 
            // postForm1
            // 
            this.postForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postForm1.Location = new System.Drawing.Point(0, 0);
            this.postForm1.Name = "postForm1";
            this.postForm1.Size = new System.Drawing.Size(354, 323);
            this.postForm1.TabIndex = 0;
            // 
            // CreatePost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 323);
            this.Controls.Add(this.postForm1);
            this.Name = "CreatePost";
            this.Text = "Thêm bài viết";
            this.ResumeLayout(false);

        }

        #endregion

        private PostForm postForm1;
    }
}