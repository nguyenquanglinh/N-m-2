using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using System;

namespace QuanLyPhongNet
{
    public partial class Main : Form
    {
        public Main()
        {

            InitializeComponent();
            DangNhapOTher();
            new GoogleChrome().GetAllRam();
        }

        private void DangNhapOTher()
        {
            userCtl1.Enabled = false;
            btnDangNhap.Enabled = false;
        }

        void DangNhapAdmin()
        {
            userCtl1.Enabled = true;
            btnDangNhap.Enabled = true;
        }
        private void btnAdmin_Click(object sender, System.EventArgs e)
        {
            DangNhapAdmin();
            //if (!new FileDB().CheckFileDB())
            //    MessageBox.Show("Tạo file luôn");
            //else MessageBox.Show("");
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var admin = new Admin(userCtl1.GetUser());
            if (admin.CheckUser())
                MessageBox.Show("Đăng nhập user thành công");
            else
            {
                MessageBox.Show("đăng nhập admin không thành công");
                DangNhapOTher();
            }

        }
    }
}
