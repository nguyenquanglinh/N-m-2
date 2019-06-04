using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class FileManagerUser : FileManager
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

        /// <summary>
        /// mở file user
        /// </summary>
        /// <returns>listUser</returns>
        private ListUser OpenFileListUser()
        {
            var listUser = new ListUser();
            if (File.Exists(pathUser) == false)
            {
                return listUser;
            }
            var lines = File.ReadAllLines(pathUser);
            foreach (string line in lines)
            {
                var checkError = line.Split('\t');
                if (checkError.Count() == 2)
                    listUser.ListU.Add(new User(checkError[0], checkError[1]));
            }
            return listUser;
        }

        /// <summary>
        /// lưu listUser vào file
        /// </summary>
        /// <param name="listUser">ds các user</param>
        public void SaveListUser(ListUser listUser)
        {
            File.Delete(pathUser);
            foreach (var item in listUser.ListU)
            {
                SaveOnceUser(item);
            }
        }

        /// <summary>
        /// hàm lấy danh sách user đã thêm
        /// </summary>
        /// <returns>listUser</returns>
        public ListUser GetListUser()
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
        public bool CheckUserInList(User user)
        {
            var listUser = GetListUser();
            return listUser.ListU.Contains(user);
        }

        public void ChangeItemInListUser(User user)
        {
        }


        /// <summary>
        /// Xóa user trong ds và lưu lại ds user mới
        /// </summary>
        /// <param name="user"></param>
   

    }
}
