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

        public bool FileIsError=false;
        public FileManager()
        {
        }
        public void Save(User user)
        {
            if (File.Exists(path) == false)
            {
                // Create a file to write to.
                File.Create(path);
            }
            string appendText = user.UserName + "\t" + user.PassWord + Environment.NewLine;
            File.AppendAllText(path, appendText, Encoding.UTF8);
        }

        public List<User> Open()
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
    }
}
