using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
   public class Post
    {
        public Post()
        {
            TextPost = "";
            ImgPost = new List<string>();
        }
        public Post(string text)
        {
            TextPost = text;
        }
        public int Stt { get; set; }
        public Post(string textPost, List<string> imgPost) : this()
        {
            this.TextPost = textPost;
            this.ImgPost = imgPost;
        }
        public string TextPost { get; set; }
        public List<string> ImgPost { get; set; }


        public override string ToString()
        {
            return TextPost;
        }
    }
}
