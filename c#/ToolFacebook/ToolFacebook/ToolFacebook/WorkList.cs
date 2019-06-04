using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class WorkList
    {
        private int dem;

        public WorkList()
        {
            User = new User();
            ListPost = new ListPost();
        }

        public WorkList(User user, ListPost listPost, List<Group> groups)
        {
            User = user;
            ListPost = listPost;
            Groups = groups;
        }

        public WorkList(User user, ListPost listPost, List<Group> groups, int dem) : this(user, listPost, groups)
        {
            this.dem = dem;
        }

        public override string ToString()
        {
            return User.ToString()+ListPost.ToString()+Groups.Count.ToString();
        }


        public List<Group> Groups { get; internal set; }
        public ListPost ListPost { get; internal set; }
        public int Stt { get; internal set; }
        public User User { get; internal set; }
    }
}
