using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    /// <summary>
    /// có hàm so sánh gethasdcode
    /// </summary>
   public class Post:Obj
    {

        public int Stt { get; set; }

        public string TextPost { get; set; }

        public ListPathImgPost ImgPost { get; set; }

        public Post():base("post")
        {
            TextPost = "";
            ImgPost = new ListPathImgPost();
        }

        public Post(string text):this()
        {
            TextPost = text;
        }

        public Post(string textPost, ListPathImgPost imgPost) : this()
        {
            this.TextPost = textPost;
            this.ImgPost = imgPost;
        }

        public override string ToString()
        {
            return TextPost;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            int x = TextPost.GetHashCode();
            foreach (var post in ImgPost.PathImgPost)
            {
                x = x ^ post.GetHashCode();
            }
            return x;
        }



    }
}
