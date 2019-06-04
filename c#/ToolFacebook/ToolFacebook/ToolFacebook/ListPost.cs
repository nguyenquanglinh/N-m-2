using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class ListPost
    {
        public ListPost()
        {
            this.ListP = new List<Post>();
        }

        public ListPost(List<Post> listPost)
        {
            ListP = listPost;
        }

        public List<Post> ListP { get; set; }

        public Post GetPostInList(int index)
        {
            return this.ListP.FirstOrDefault(x => x.Stt == index);
        }

        public override string ToString()
        {
            return "số lượng bài viết là "+ListP.Count().ToString();
        }
    }
}
