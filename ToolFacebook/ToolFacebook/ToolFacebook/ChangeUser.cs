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
    public partial class ChangeUser : Form
    {
        public ChangeUser()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        private User User { get; set; }
        public ChangeUser(User user) : this()
        {
            userForm1.SetUser(user);
            User = user;
            if (user.CheckUserIsTrue == "False")
            {
                this.BackColor = Color.Red;
                if(MessageBox.Show("Thông tin tài khoản không chính xác!Bạn có cần đổi mật khẩu không ?","Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {

                }
            }
           
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            new ChangePassWord(User).ShowDialog();
        }
    }
}
