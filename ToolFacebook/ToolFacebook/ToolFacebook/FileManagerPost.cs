using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class FileManagerPost:FileManager
    {
        public FileManagerPost() : base()
        {
           
        }

        /// <summary>
        /// đường dẫn file ListPost
        /// </summary>
        private string pathPost = "Post.txt";

        /// <summary>
        /// hàm khởi tạo của file manager-quản lý quá trình ghi-đọc file
        /// </summary>
       

        /// <summary>
        /// hàm thực hiện việc lưu các dòng trong file-nếu file tồn tại rồi thì lưu tiếp-chưa thì tạo ra file và ghi 
        /// </summary>
        /// <param name="line">dòng cần ghi</param>
        /// <param name="pathX">đường dẫn của file</param>
       

        /// <summary>
        /// lưu ds các bài viết 
        /// </summary>
        /// <param name="listPost">danh sách các bài viết đã được tạo</param>
        public void RomovePostInListAffterSaveNewListPost(List<Post> listPost)
        {
            File.Delete(pathPost);
            foreach (var item in listPost)
            {
                SaveOncePost(item);
            }
        }

        /// <summary>
        /// lưu 1 bài viết-post
        /// </summary>
        /// <param name="post"></param>
        public void SaveOncePost(Post post)
        {
            SaveAppendLine("@postStart", pathPost);
            SaveAppendLine(post.TextPost, pathPost);
            foreach (var item in post.ImgPost)
            {
                SaveAppendLine(item, pathPost);
            }
            SaveAppendLine("@postClose", pathPost);
        }

        
        /// <summary>
        /// lấy danh sách các bài viết
        /// </summary>
        /// <returns>listPost</returns>
        private List<Post> OpenListPosts()
        {
            var listPost = new List<Post>();
            if (File.Exists(pathPost) == false)
            {
                return listPost;
            }
            var lines = File.ReadAllLines(pathPost);

            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i] == "@postStart")
                {
                    var post = new Post();
                    post.TextPost = lines[i + 1];
                    for (int j = i + 2; j < lines.Count(); j++)
                    {
                        if (lines[j] == "@postClose")
                        {
                            i = j;
                            break;
                        }
                        post.ImgPost.Add(@lines[j]);
                    }
                    listPost.Add(post);
                }

            }
            return listPost;
        }


        /// <summary>
        /// kiểm tra xem post đã tồn tại trong list post chưa
        /// </summary>
        /// <param name="post">bài viết+ảnh</param>
        /// <returns>true nếu bài viết đã tồn tại</returns>
        public bool CheckPostInList(Post post)
        {
            var listPost = GetListPost();
            foreach (var item in listPost)
            {
                if (item.TextPost == post.TextPost)
                {
                    int lenght = item.ImgPost.Count;
                    if (item.ImgPost.Count == post.ImgPost.Count)
                    {
                        int dem = 0;
                        for (int i = 0; i < lenght; i++)
                        {
                            if (item.ImgPost[i] == post.ImgPost[i])
                            {
                                dem++;
                                if (dem == lenght)
                                    return true;
                            }
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        public List<Post> GetListPost()
        {
            return OpenListPosts();
        }
    }
}
