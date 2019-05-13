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
        private string path = "ListUser.txt";

        public bool FileIsError = false;

        public List<User> ListUser { get; private set; }

        public FileManager()
        {
            this.ListUser = Open();
        }
        public void Save(User user)
        {
            if (File.Exists(path) == false)
            {
                // Create a file to write to.
                var xx = File.Create(path);
                xx.Close();
            }
            string appendText = user.UserName + "\t" + user.PassWord + Environment.NewLine;
            File.AppendAllText(path, appendText, Encoding.UTF8);
        }

        public bool checkUserInList(User user)
        {
            foreach (var item in ListUser)
            {
                if (item.UserName == user.UserName)

                    return true;
            }
            return false;
        }

        private List<User> Open()
        {
            var listUser = new List<User>();
            if (File.Exists(path) == false)
            {
                return listUser;
            }
            var lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                var checkError = line.Split('\t');
                if (checkError.Count() != 2)
                {
                    if (File.Exists(path) == true)
                    {
                        // Create a file to write to.
                        File.Delete(path);
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
                if (checkUserInList(user))
                {
                    ListUser.RemoveAt(i);
                    break;
                }
            }
            SaveListUser(this.ListUser);
        }

        public void SaveListUser(List<User> listUser)
        {
            File.Delete(path);
            foreach (var item in listUser)
            {
                Save(item);
            }
        }
    }
}
