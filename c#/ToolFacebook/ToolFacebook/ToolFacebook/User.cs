using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class User:Obj
    {
        /// <summary>
        /// khởi tạo user với tk+mk
        /// </summary>
        /// <param name="userName">tk</param>
        /// <param name="passWord">mk</param>
        public User(string userName, string passWord):this()
        {
            this.UserName = userName;
            this.PassWord = passWord;
        }

        /// <summary>
        /// khởi tạo user rỗng
        /// </summary>
        public User() : base("user")
        {
        }

        /// <summary>
        /// overide tostring
        /// </summary>
        /// <returns>username</returns>
        public override string ToString()
        {
            return UserName;
        }

        public override bool Equals(object obj)
        {
            //var xx= this.GetHashCode() == obj.GetHashCode();
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            //var code = UserName.GetHashCode() ^ PassWord.GetHashCode();
            return UserName.GetHashCode() ^ PassWord.GetHashCode();
        }


        /// <summary>
        /// khởi tạo user với tk+mk+ds
        /// </summary>
        /// <param name="userName">tk</param>
        /// <param name="passWord">mk</param>
        /// <param name="v">check user</param>
        public User(string userName, string passWord, string v) : this(userName, passWord)
        {

            this.CheckUserIsTrue = v;
        }

        /// <summary>
        /// khởi tạo user sử dụng user đã có
        /// </summary>
        /// <param name="user"></param>
        

     
       

        public string PassWord { get; set; }
        public string UserName { get; set; }
        public string CheckUserIsTrue { get; set; }
    }
}
