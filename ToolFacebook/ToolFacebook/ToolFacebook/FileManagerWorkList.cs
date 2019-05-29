using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class FileManagerWorkList : FileManager
    {
        public WorkList Work;

        public FileManagerWorkList(WorkList work) : base()
        {
            string root = "\\WorkList\\";
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
                this.Work = work;
        }
        public void SaveWorkList()
        {
            var xx = "@WorkList \n" + Work.User.UserName + "\n" + Work.Post.ToString() + Work.Groups.ToString();
            SaveAppendLine(xx,@"\WorkList\"+ "WorkList" + Work.Stt.ToString()+".txt");
        }
        public void OpenWorkList()
        {
            DirectoryInfo d = new DirectoryInfo("");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files
            string str = "";
            foreach (FileInfo file in Files)
            {
                str = str + ", " + file.Name;
            }
        }

    }
}
