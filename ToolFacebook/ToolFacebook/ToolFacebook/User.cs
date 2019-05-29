using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
  public  class User
    {
        private User user;

        public User(string userName,string passWord)
        {
            this.UserName = userName;
            this.PassWord = passWord;
        }
        public override string ToString()
        {
            return UserName;
        }
        public User(string userName, string passWord, string v) : this(userName, passWord)
        {
           
            this.CheckUserIsTrue = v;
        }

        public User(User user)
        {
            this.user = user;
        }

        public string PassWord { get;  set; }
        public string UserName { get;  set; }

        public string CheckUserIsTrue { get; set; }
    }
}
