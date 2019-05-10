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
        public void SetUser(User user)
        {
            txtUserName.Text = user.UserName;
            txtPassWord.Text = user.PassWord;
        }

        public bool UserNameOrPassWordIsNull = false;
        public User GetUser()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassWord.Text))
            {
                MessageBox.Show("Không được để trống trường user name hoặc pass word");
                UserNameOrPassWordIsNull = true;
                return new User("", "");
            }
            UserNameOrPassWordIsNull = false;
            return new User(txtUserName.Text, txtPassWord.Text);
        }

       
    }
}
