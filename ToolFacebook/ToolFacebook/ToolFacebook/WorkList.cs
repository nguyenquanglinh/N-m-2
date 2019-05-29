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
            this.ListPost = post;
            this.Groups = groups;
        }

        public WorkList()
        {

        }

        public WorkList(User user, List<Post> listPost, List<Groups> groups)
        {
            User = user;
            this.ListPost = listPost;
            Groups = groups;
        }

        public List<Groups> Groups { get; private set; }
        public List<Post> ListPost { get; private set; }
        public int Stt { get; private set; }
        public User User { get; private set; }
        public override string ToString()
        {
            return "WorkList"+ Stt.ToString()+".txt";
        }
    }
}
