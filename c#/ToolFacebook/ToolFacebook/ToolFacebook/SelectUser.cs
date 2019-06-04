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
            selectObjUser.GetName(" tài khoản đăng nhập");
            ListUserIsSelected = new ListUser();
        }

        public User User { get; set; }

        public SelectUser(int mode) : this()
        {
            Mode1();
        }

        public SelectUser(ListUser listUser) : this()
        {
            this.ListUser = listUser;
            if (ListUser.ListU.Count == 1)
                selectObjUser.SetListUseInForm(listUser);
            else
                throw new Exception("chưa làm tiếp");
        }

        private void Mode1()
        {
            selectObjUser.GetName(" tài khoản đăng nhập");
            this.ListUser = new FileManagerUser().GetListUser();
            if (ListUser.ListU.Count != 0)
                selectObjUser.SetListUseInForm(new FileManagerUser().GetListUser());
            else
                MessageBox.Show("Không có tài khoản để đăng nhập");
        }

        public ListUser ListUserIsSelected { get; set; }
        private ListUser ListUser { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (selectObjUser.CheckAll() == false)
                ListUserIsSelected = selectObjUser.SetListUserChecked();
            else
            {
                if (ListUser == null)
                {

                }
             else   ListUserIsSelected = ListUser;
            }
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
