﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
  public  class User
    {
        public User(string userName,string passWord)
        {
            this.UserName = userName;
            this.PassWord = passWord;
        }
        public string PassWord { get; private set; }
        public string UserName { get; private set; }
    }
}