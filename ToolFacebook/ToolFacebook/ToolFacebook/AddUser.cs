using OpenQA.Selenium.Chrome;
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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void userForm1_Load(object sender, EventArgs e)
        {

        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var user = this.AdduserForm.GetUser();
            if (this.AdduserForm.UserNameOrPassWordIsNull == false)
            {
                if (new GoogleChrome(true).CheckUser(user) == true)
                {
                    ///cần ghi file -sd sql severs

                    if (MessageBox.Show("Thêm tài khoản thành công,bạn có muốn thêm  nữa không.", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        this.Close();
                }
                else
                {
                    if (MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không chính xác.Bạn có muốn thử lại không.", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        this.Close();
                }
                this.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }
    }
}
