using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class FileManagerUser:FileManager
    {
        public FileManagerUser() : base()
        {

        }
      
        /// <summary>
        /// đường dẫn của file ListUser
        /// </summary>
        private string pathUser = "ListUser.txt";


        /// <summary>
        /// kiểm tra file lỗi có bị lưu lỗi không
        /// </summary>
        public bool FileUserIsError = false;

        /// <summary>
        /// mở file user
        /// </summary>
        /// <returns>listUser</returns>
        private List<User> OpenFileListUser()
        {
            var listUser = new List<User>();
            if (File.Exists(pathUser) == false)
            {
                return listUser;
            }
            var lines = File.ReadAllLines(pathUser);
            foreach (string line in lines)
            {
                var checkError = line.Split('\t');
                if (checkError.Count() != 2)
                {
                    if (File.Exists(pathUser) == true)
                    {
                        // Create a file to write to.
                        File.Delete(pathUser);
                        FileUserIsError = true;
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

        /// <summary>
        /// lưu listUser vào file
        /// </summary>
        /// <param name="listUser">ds các user</param>
        private void SaveListUser(List<User> listUser)
        {
            File.Delete(pathUser);
            foreach (var item in listUser)
            {
                SaveOnceUser(item);
            }
        }

        /// <summary>
        /// hàm lấy danh sách user đã thêm
        /// </summary>
        /// <returns>listUser</returns>
        public List<User> GetListUser()
        {
            return OpenFileListUser();
        }

        /// <summary>
        /// lưu 1 user
        /// </summary>
        /// <param name="user">gồm tk+mk</param>
        public void SaveOnceUser(User user)
        {
          SaveAppendLine(user.UserName + "\t" + user.PassWord, pathUser);
        }


      

        /// <summary>
        /// kiểm tra user có tồn tại trong ds đã lưu không
        /// </summary>
        /// <param name="user">tk+mk</param>
        /// <returns>true nếu user đã tồn tại</returns>
        public bool CheckUserExitsInList(User user)
        {
          var listUser=  GetListUser();
            foreach (var item in listUser)
            {
                if (item.UserName == user.UserName)

                    return true;
            }
            return false;
        }

        /// <summary>
        /// Xóa user trong ds và lưu lại ds user mới
        /// </summary>
        /// <param name="user"></param>
        public void RomoveUserInListAffterSaveNewListUser(User user)
        {
            var listUser = GetListUser();
            for (int i = 0; i < listUser.Count; i++)
            {
                if (CheckUserExitsInList(user))
                {
                    listUser.RemoveAt(i);
                    break;
                }
            }
            SaveListUser(listUser);
        }



    }
}
