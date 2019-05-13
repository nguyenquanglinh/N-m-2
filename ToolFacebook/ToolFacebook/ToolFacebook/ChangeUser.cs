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
        public bool RemoveUser = false;
        private User User { get; set; }
        public ChangeUser(User user) : this()
        {
            userFormChangeUser.SetUser(user);
            User = user;
            if (user.CheckUserIsTrue == "False")
            {
                this.BackColor = Color.Red;
                if(MessageBox.Show("Thông tin tài khoản không chính xác!Bạn có cần đổi mật khẩu không ?","Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    UpdatePass(User);
                }
            }
           
        }
        private void UpdatePass(User user)
        {
            var xx = new UpdatePass(User);
            xx.ShowDialog();
            this.User.PassWord = xx.NewPass;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnChangePass_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("chưa làm được");
        }

        private void btnUpdatePass_Click(object sender, EventArgs e)
        {
            UpdatePass(User);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản không ?","Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                RemoveUser = true;
                this.Close();
            }
        }
    }
}
