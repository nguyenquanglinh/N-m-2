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
    public partial class UpdatePass : Form
    {
        private User User;

        public UpdatePass()
        {
            InitializeComponent();
            userForm1.Enabled = false;
        }

        public UpdatePass(User user):this()
        {
            this.User = user;
            userForm1.PushUser(user);
            this.NewPass = user.PassWord;
        }

        public string NewPass { get; private set; }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtNewPass.Text) == false)
            {
                if (new GoogleChrome(true).CheckUserIsTrue(new User(User.UserName, txtNewPass.Text)) == true)
                    this.NewPass = txtNewPass.Text;
                else
                {
                    if (MessageBox.Show("Mật khẩu mới không chính xác.Bạn có muốn nhập lại mật khẩu mới không ?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    {
                        this.NewPass = User.PassWord;
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập mật khẩu mới","Thông báo");
            }
            this.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
