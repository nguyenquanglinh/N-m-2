using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class FileManagerPost : FileManager
    {
        /// <summary>
        /// hàm khởi tạo của file manager-quản lý quá trình ghi-đọc file
        /// </summary>
        public FileManagerPost() : base()
        {

        }

        /// <summary>
        /// đường dẫn file ListPost
        /// </summary>
        private string pathPost = "Post.txt";


        /// <summary>
        /// lưu ds các bài viết 
        /// </summary>
        /// <param name="listPost">danh sách các bài viết đã được tạo</param>
        public void SaveListPost(ListPost listPost)
        {
            File.Delete(pathPost);
            foreach (var item in listPost.ListP)
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
            foreach (var item in post.ImgPost.PathImgPost)
            {
                SaveAppendLine(item, pathPost);
            }
            SaveAppendLine("@postClose", pathPost);
        }

        /// <summary>
        /// lấy danh sách các bài viết
        /// </summary>
        /// <returns>listPost</returns>
        private ListPost OpenListPosts()
        {
            var listPost = new ListPost();
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
                    //post.TextPost = lines[i + 1];
                    for (int j = i + 1; j < lines.Count(); j++)
                    {
                        if (lines[j] == "@postClose")
                        {
                            i = j;
                            break;
                        }

                        //post.ImgPost.PathImgPost.Add(@lines[j]);
                        checkTextOrPathImg(post, lines[j]);
                    }
                    listPost.ListP.Add(post);
                }

            }
            return listPost;
        }

        void checkTextOrPathImg(Post post, string line)
        {
            int dem = 0;
            var listStringCheck = new List<string>() { ".jpg", ".jpeg", ".jpe", ".jfif", " .png", ".mp4", ".3gp" };
            foreach (var item in listStringCheck)
            {
                if (line.Contains(item))
                {
                    post.ImgPost.PathImgPost.Add(@line);
                    return;
                }
                else dem++;
            }
            if (dem == listStringCheck.Count)
                post.TextPost += line.Replace("  ", String.Empty) + " ";
        }
        /// <summary>
        /// kiểm tra xem post đã tồn tại trong list post chưa
        /// </summary>
        /// <param name="post">bài viết+ảnh</param>
        /// <returns>true nếu bài viết đã tồn tại</returns>
        public bool CheckPostInList(Post post)
        {
            var listPost = GetListPost();
            //foreach (var posts in listPost)
            //{
            //    if (post.Equals(posts))
            //        return true;
            //}
            //return false;
            return listPost.ListP.Contains(post);
            #region tường minh ss post
            //foreach (var item in listPost)
            //{
            //    if (item.TextPost == post.TextPost)
            //    {
            //        if (item.ImgPost.Count == post.ImgPost.Count)
            //        {
            //            int lenght = item.ImgPost.Count;
            //            int dem = 0;
            //            for (int i = 0; i < lenght; i++)
            //            {
            //                if (item.ImgPost[i] == post.ImgPost[i])
            //                {
            //                    dem++;
            //                    if (dem == lenght)
            //                        return true;
            //                }
            //            }
            //            return false;
            //        }
            //    }
            //}
            //return false;
            #endregion
        }

        public ListPost GetListPost()
        {
            return OpenListPosts();
        }
    }
}
