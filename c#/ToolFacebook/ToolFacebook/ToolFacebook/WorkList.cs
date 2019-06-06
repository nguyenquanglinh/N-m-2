using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class WorkList
    {

        public WorkList()
        {
            User = new User();
            ListPost = new ListPost();
            TimeWaiting = 0;
        }

        public WorkList(User user, ListPost listPost, ListGroup groups) : this()
        {
            User = user;
            ListPost = listPost;
            Groups = groups;
        }

        public WorkList(User user, ListPost listPost, ListGroup groups, int timeWaiting) : this(user, listPost, groups)
        {
            this.TimeWaiting = timeWaiting;
        }

        public override string ToString()
        {
            return "WorkList of " + User + ListPost.ToString() + Groups;
        }


        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return User.GetHashCode() ^ ListPost.GetHashCode() ^ Groups.GetHashCode() ^ TimeWaiting.GetHashCode();
        }

        public ListGroup Groups { get; internal set; }
        public ListPost ListPost { get; internal set; }
        public int Stt { get; internal set; }
        public User User { get; internal set; }
        public int TimeWaiting { get; internal set; }
    }
}
