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
            this.checkboxStart1 = new System.Windows.Forms.CheckBox();
            this.checkBoxStart2 = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.checkRunAlway = new System.Windows.Forms.CheckBox();
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
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.addUserToolStripMenuItem.Text = "Thêm tài khoản";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // checkUserToolStripMenuItem
            // 
            this.checkUserToolStripMenuItem.Name = "checkUserToolStripMenuItem";
            this.checkUserToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.checkUserToolStripMenuItem.Text = "Kiểm tra tất cả tài khoản";
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
            this.checkPostToolStripMenuItem.Click += new System.EventHandler(this.checkPostToolStripMenuItem_Click);
            // 
            // checkboxStart1
            // 
            this.checkboxStart1.AutoSize = true;
            this.checkboxStart1.Checked = true;
            this.checkboxStart1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxStart1.Location = new System.Drawing.Point(55, 50);
            this.checkboxStart1.Name = "checkboxStart1";
            this.checkboxStart1.Size = new System.Drawing.Size(108, 17);
            this.checkboxStart1.TabIndex = 3;
            this.checkboxStart1.Text = "Chế độ mặc định";
            this.checkboxStart1.UseVisualStyleBackColor = true;
            // 
            // checkBoxStart2
            // 
            this.checkBoxStart2.AutoSize = true;
            this.checkBoxStart2.Location = new System.Drawing.Point(55, 74);
            this.checkBoxStart2.Name = "checkBoxStart2";
            this.checkBoxStart2.Size = new System.Drawing.Size(87, 17);
            this.checkBoxStart2.TabIndex = 4;
            this.checkBoxStart2.Text = "Chế độ riêng";
            this.checkBoxStart2.UseVisualStyleBackColor = true;
            this.checkBoxStart2.Click += new System.EventHandler(this.checkBoxStart2_Click);
            // 
            // btnStop
            // 
            this.btnStop.AutoSize = true;
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop.Location = new System.Drawing.Point(187, 146);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 59);
            this.btnStop.TabIndex = 2;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = true;
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Location = new System.Drawing.Point(25, 146);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(74, 59);
            this.btnStart.TabIndex = 1;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // checkRunAlway
            // 
            this.checkRunAlway.AutoSize = true;
            this.checkRunAlway.Location = new System.Drawing.Point(187, 50);
            this.checkRunAlway.Name = "checkRunAlway";
            this.checkRunAlway.Size = new System.Drawing.Size(87, 17);
            this.checkRunAlway.TabIndex = 5;
            this.checkRunAlway.Text = "Chạy liên tục";
            this.checkRunAlway.UseVisualStyleBackColor = true;
            this.checkRunAlway.CheckedChanged += new System.EventHandler(this.checkRunAlway_CheckedChanged);
            // 
            // ToolFb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.checkRunAlway);
            this.Controls.Add(this.checkBoxStart2);
            this.Controls.Add(this.checkboxStart1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ToolFb";
            this.Text = "Facebook tool";
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
        private System.Windows.Forms.CheckBox checkboxStart1;
        private System.Windows.Forms.CheckBox checkBoxStart2;
        private System.Windows.Forms.CheckBox checkRunAlway;
    }
}

