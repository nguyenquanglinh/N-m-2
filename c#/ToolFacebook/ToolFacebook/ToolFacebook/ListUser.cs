using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class ListUser
    {
        public ListUser()
        {
            ListU = new List<User>();
        }

        public override int GetHashCode()
        {
            var code = 0;
            foreach (var user in ListU)
            {
                code = code ^ user.GetHashCode();
            }
            return code;
        }
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public ListUser(User user) : this()
        {
            ListU.Add(user);
        }

        public ListUser(List<User> listUser) : this()
        {
            this.ListU = listUser;
        }

        public List<User> ListU { get; set; }
    }
}
