using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolFacebook
{
    public partial class SelectUser : Form
    {

        public SelectUser()
        {
            InitializeComponent();
            ListUserIsSelected = new List<User>();
            selectObjUser.GetName(" tài khoản đăng nhập");
            if (new FileManagerUser().GetListUser().Count == 0)
            {
                if (MessageBox.Show("Chưa thêm tài khoản đăng bài.Cần thêm tài khoản ngay", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    new AddUser().ShowDialog();
                }
                else this.Close();
            }
            else selectObjUser.GetItemUser(new FileManagerUser().GetListUser());
        }
        public List<User> ListUserIsSelected { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (selectObjUser.CheckAll() == false)
                ListUserIsSelected = selectObjUser.SetItemCheckedUser();
            else ListUserIsSelected = new FileManagerUser().GetListUser();
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cần bấm vào Chọn xong để hoàn thành quá trình chọn tài khoản đăng nhập", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}
