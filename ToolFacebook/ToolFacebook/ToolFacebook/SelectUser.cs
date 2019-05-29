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
        private List<User> listUser;

        public SelectUser()
        {
            InitializeComponent();
            selectObjUser.GetName(" tài khoản đăng nhập");
            ListUserIsSelected = new List<User>();

        }
        public User User { get; set; }
        public SelectUser(int mode) : this()
        {
            if (mode == 1)
                Mode1();
        }
        public SelectUser(List<User> ListUser) : this()
        {
            this.listUser = ListUser;
            if (ListUser.Count == 1)
                selectObjUser.GetItemUser(ListUser);
            else
                throw new Exception("chưa làm tiếp");
        }
        private void Mode1()
        {
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
            else if (selectObjUser.CheckAll()) { ListUserIsSelected = listUser; }
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
