using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongNet
{
    public class Data
    {
        public Data(string name)
        {
            this.Path = name;
        }

        public string Path { get; private set; }
        public SQLiteConnection SQLConnect { get; private set; }

        private SQLiteConnection ConnectFileDB(string name)
        {
            string path = @"H:\Code\c#\QuanLyPhongNet\Data\" + name;
            if(!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                //Password = 1234;
            }
            return new SQLiteConnection(@"Data Source=" + path + ";Version=3;");
        }
        private void OpenConnect(string name)
        {
            this.SQLConnect = ConnectFileDB(name);
            this.SQLConnect.Open();
        }
        private void CloseConnect(string name)
        {
            ConnectFileDB(name).Close();
        }
    }
}
