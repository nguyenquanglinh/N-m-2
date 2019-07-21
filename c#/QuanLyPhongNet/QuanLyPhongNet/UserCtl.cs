using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongNet
{
    public partial class UserCtl : UserControl
    {
        public UserCtl()
        {
            InitializeComponent();
        }

        public User GetUser()
        {
            var user = new User();
            if(string.IsNullOrWhiteSpace(txtUserName.Text) && string.IsNullOrWhiteSpace(txtPass.Text))
            {
                user.Name = txtUserName.Text;
                user.Pass = txtPass.Text;
            }
            return user;
        }
    }
}
