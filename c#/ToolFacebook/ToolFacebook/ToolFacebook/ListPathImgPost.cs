using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class ListPathImgPost
    {
        public List<string> PathImgPost;

        public ListPathImgPost(List<string> pathImgPost):this()
        {
            this.PathImgPost = pathImgPost;
        }

        public ListPathImgPost()
        {
            PathImgPost = new List<string>();
        }

        public override int GetHashCode()
        {
            var code = 0;
            foreach (var post in PathImgPost)
            {
                code = code ^ post.GetHashCode();
            }
            return code;
        }
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

    }
}
