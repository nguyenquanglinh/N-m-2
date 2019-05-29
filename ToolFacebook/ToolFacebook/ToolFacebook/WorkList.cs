using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class WorkList
    {
        public WorkList(User user, List<Post> post, List<Groups> groups, int stt)
        {
            this.Stt = stt;
            this.User = user;
            this.Post = post;
            this.Groups = groups;
        }

        public List<Groups> Groups { get; private set; }
        public List<Post> Post { get; private set; }
        public int Stt { get; private set; }
        public User User { get; private set; }
        //public override string ToString()
        //{
        //    var xx = "@WorkList \n" + Stt.ToString() + "\n" + User.UserName + "\n" + Post.TextPost + Groups.ToString();
        //    return xx.ToString();
        //}
    }
}
