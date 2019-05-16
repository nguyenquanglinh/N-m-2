using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class FileManager
    {
        private string pathList = "ListUser.txt";

        private string pathPost = "Post.txt";

        public bool FileIsError = false;

        private List<User> ListUser { get; set; }

        private List<Post> ListPost { get; set; }

        public FileManager()
        {
        }

        public void Save(string line, string pathX)
        {
            if (File.Exists(pathX) == false)
            {
                // Create a file to write to.
                var xx = File.Create(pathX);
                xx.Close();
            }
            string appendText = line + Environment.NewLine;
            File.AppendAllText(pathX, appendText, Encoding.UTF8);
        }
        public List<User> GetListUser()
        {
            return this.ListUser = OpenFileListUser();
        }
        public void SaveUser(User user)
        {
            Save(user.UserName + "\t" + user.PassWord, pathList);
        }

        public bool CheckUserInList(User user)
        {
            GetListUser();
            foreach (var item in ListUser)
            {
                if (item.UserName == user.UserName)

                    return true;
            }
            return false;
        }

        private List<User> OpenFileListUser()
        {
            var listUser = new List<User>();
            if (File.Exists(pathList) == false)
            {
                return listUser;
            }
            var lines = File.ReadAllLines(pathList);
            foreach (string line in lines)
            {
                var checkError = line.Split('\t');
                if (checkError.Count() != 2)
                {
                    if (File.Exists(pathList) == true)
                    {
                        // Create a file to write to.
                        File.Delete(pathList);
                        FileIsError = true;
                        return listUser;
                    }
                }
                else
                {
                    listUser.Add(new User(checkError[0], checkError[1]));
                }
            }
            return listUser;
        }

     

        public void ChangeListUser(User user)
        {
            for (int i = 0; i < this.ListUser.Count; i++)
            {
                if (CheckUserInList(user))
                {
                    ListUser.RemoveAt(i);
                    break;
                }
            }
            SaveListUser(this.ListUser);
        }

        public void SaveListUser(List<User> listUser)
        {
            File.Delete(pathList);
            foreach (var item in listUser)
            {
                SaveUser(item);
            }
        }

        internal void SaveListPost(List<Post> listPost)
        {
            File.Delete(pathPost);
            foreach (var item in listPost)
            {
                SavePost(item);
            }
        }

        public void SavePost(Post post)
        {
            Save("@postStart", pathPost);
            Save(post.TextPost, pathPost);
            foreach (var item in post.ImgPost)
            {
                Save(item, pathPost);
            }
            Save("@postClose", pathPost);
        }

        private List<Post> OpenListPosts()
        {
            var listPost = new List<Post>();
            if (File.Exists(pathList) == false)
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
                        post.ImgPost.Add(lines[j]);
                    }
                    listPost.Add(post);
                }

            }
            return listPost;
        }


        public bool CheckPostInList(Post post)
        {
            GetListPost();
            foreach (var item in ListPost)
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
            return this.ListPost = OpenListPosts();
        }
    }
}
