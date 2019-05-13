namespace ToolFacebook
{
    partial class ToolFb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolFb));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkPostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip
            // 
            this.menuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManagerToolStripMenuItem,
            this.postManagerToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(68, 20);
            this.menuStrip.Text = "Lựa chọn";
            // 
            // userManagerToolStripMenuItem
            // 
            this.userManagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.checkUserToolStripMenuItem});
            this.userManagerToolStripMenuItem.Name = "userManagerToolStripMenuItem";
            this.userManagerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.userManagerToolStripMenuItem.Text = "Quản lý tài khoản";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.addUserToolStripMenuItem.Text = "Thêm tài khoản";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // checkUserToolStripMenuItem
            // 
            this.checkUserToolStripMenuItem.Name = "checkUserToolStripMenuItem";
            this.checkUserToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.checkUserToolStripMenuItem.Text = "Kiểm tra tài khoản";
            this.checkUserToolStripMenuItem.Click += new System.EventHandler(this.checkUserToolStripMenuItem_Click);
            // 
            // postManagerToolStripMenuItem
            // 
            this.postManagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createPostToolStripMenuItem,
            this.checkPostToolStripMenuItem});
            this.postManagerToolStripMenuItem.Name = "postManagerToolStripMenuItem";
            this.postManagerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.postManagerToolStripMenuItem.Text = "Quản lý bài viết";
            this.postManagerToolStripMenuItem.Click += new System.EventHandler(this.postManagerToolStripMenuItem_Click);
            // 
            // createPostToolStripMenuItem
            // 
            this.createPostToolStripMenuItem.Name = "createPostToolStripMenuItem";
            this.createPostToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.createPostToolStripMenuItem.Text = "Thêm  bài viết";
            this.createPostToolStripMenuItem.Click += new System.EventHandler(this.createPostToolStripMenuItem_Click);
            // 
            // checkPostToolStripMenuItem
            // 
            this.checkPostToolStripMenuItem.Name = "checkPostToolStripMenuItem";
            this.checkPostToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.checkPostToolStripMenuItem.Text = "Kiểm tra bài viết";
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = true;
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStart.BackgroundImage = global::ToolFacebook.Properties.Resources.start;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Location = new System.Drawing.Point(36, 158);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 59);
            this.btnStart.TabIndex = 1;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.AutoSize = true;
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.BackgroundImage = global::ToolFacebook.Properties.Resources.stop__2_;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop.Location = new System.Drawing.Point(157, 158);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 59);
            this.btnStop.TabIndex = 2;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // ToolFb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ToolFb";
            this.Text = "Facebook tool";
            this.Load += new System.EventHandler(this.ToolFb_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ToolStripMenuItem menuStrip;
        private System.Windows.Forms.ToolStripMenuItem userManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkPostToolStripMenuItem;
    }
}

