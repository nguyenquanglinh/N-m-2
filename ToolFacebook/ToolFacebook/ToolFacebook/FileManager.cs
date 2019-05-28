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
        /// <summary>
        /// file cơ sở 
        /// </summary>
       public FileManager()
        {

        }


        /// <summary>
        /// hàm lưu file-lưu tiếp 1 dòng 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="pathX"></param>
        public void SaveAppendLine(string line, string pathX)
        {
            if (File.Exists(pathX) == false)
            {
                //nếu file không tồn tại sẽ tạo ra file mới
                File.Create(pathX).Close();
            }
            string appendText = line + Environment.NewLine;
            File.AppendAllText(pathX, appendText, Encoding.UTF8);
        }
    }
  
}
