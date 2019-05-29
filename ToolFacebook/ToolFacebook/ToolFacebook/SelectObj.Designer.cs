namespace ToolFacebook
{
    partial class SelectObj
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
            this.checkedListObj = new System.Windows.Forms.CheckedListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkedListObj
            // 
            this.checkedListObj.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedListObj.FormattingEnabled = true;
            this.checkedListObj.Items.AddRange(new object[] {
            "1",
            "2"});
            this.checkedListObj.Location = new System.Drawing.Point(0, 0);
            this.checkedListObj.Name = "checkedListObj";
            this.checkedListObj.Size = new System.Drawing.Size(262, 139);
            this.checkedListObj.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(0, 3);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(262, 29);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Chọn danh sách";
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Location = new System.Drawing.Point(179, 121);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(81, 17);
            this.checkAll.TabIndex = 2;
            this.checkAll.Text = "Chọn tất cả";
            this.checkAll.UseVisualStyleBackColor = true;
            // 
            // SelectObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.checkedListObj);
            this.Name = "SelectObj";
            this.Size = new System.Drawing.Size(262, 141);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListObj;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox checkAll;
    }
}
