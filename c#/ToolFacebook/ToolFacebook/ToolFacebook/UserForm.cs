using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolFacebook
{
    public partial class UserForm : UserControl
    {
        public UserForm()
        {
            InitializeComponent();
        }


        public void PushUser(User user)
        {
            //TODO: databinding winform
            txtUserName.Text = user.UserName;
            txtPassWord.Text = user.PassWord;
        }

        public User PopUser()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassWord.Text))
            {
                MessageBox.Show("Không được để trống trường user name hoặc pass word");
                return null;
            }
            return new User(txtUserName.Text, txtPassWord.Text);
        }

        public void Clear()
        {
            txtUserName.Text = "";
            txtPassWord.Text = "";
        }
    }
}
