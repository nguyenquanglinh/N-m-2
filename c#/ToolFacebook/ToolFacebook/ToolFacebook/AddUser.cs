﻿using System;
using System.Windows.Forms;

namespace ToolFacebook
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var user = this.AdduserForm.PopUser();
            if (user!=null)
            {
                if (new FileManagerUser().CheckUserInList(user) == false)
                {
                    MessageBox.Show("Sẽ mất 1 chút thời gian để kiểm tra thông tin tài khoản vui lòng chờ");
                    if (new GoogleChrome(true).CheckUserIsTrue(user) == true)
                    {
                        new FileManagerUser().SaveOnceUser(user);
                        if (MessageBox.Show("Thêm tài khoản thành công,bạn có muốn thêm  nữa không?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                            this.Close();
                    }
                    else
                    {
                        if (MessageBox.Show("Đã có lỗi xảy ra trong quá trình đăng nhập vui lòng kiểm tra lại thông tin tài khoản b.", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        {
                            this.AdduserForm.Clear();
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Tài khoản đã được thêm vào trước đó.Bạn có muốn thêm tài khoản khác không ?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        this.Close();
                }
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void AddUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {

            }
        }
    }
}
