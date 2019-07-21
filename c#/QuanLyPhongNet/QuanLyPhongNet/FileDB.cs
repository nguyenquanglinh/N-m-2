using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongNet
{
    public class FileDB
    {
        public bool CreateFile = false;

        public FileDB()
        {

        }
        /// <summary>
        /// trả về true nếu như file đã tồn tại
        /// </summary>
        /// <returns>false khi chưa có</returns>
        public bool CheckFileDB()
        {
            if (File.Exists(@"G:\Code\c#\QuanLyPhongNet\Data\Computer.sqlite"))
                return true;
            else return false;
        }

        public void CreateFileDB()
        {
            SQLiteConnection.CreateFile(@"G:\Code\c#\QuanLyPhongNet\Data\Computer.sqlite");
            //Password = 1234;
            SQLiteConnection m_dbConnection = new SQLiteConnection(@"Data Source=G:\Code\c#\QuanLyPhongNet\Data\Computer.sqlite;Version=3;");
            m_dbConnection.Open();
            var ls = new List<string>();

            string ram = "create table Ram (ThuongHieu varchar(20), DungLuong varchar(20),NameRam varchar(20),Bus varchar(20),DungCho varchar(20))";
            ls.Add(ram);
            string cpu = "create table CPU (ThuongHieu varchar(20), Name varchar(20),Socket varchar(20),TocDo varchar(20),Nhan varchar(20))";
            ls.Add(cpu);
            string mainbroad = "create table MainBroad (ThuongHieu varchar(20), Name varchar(20),Socket varchar(20),ChipSet varchar(20),SoKhe varchar(20),RamToiDa varchar(20),BusRam varchar(20),RamHoTro varchar(20))";
            ls.Add(mainbroad);
            var cardManHinh = "create table CardManHinh (ThuongHieu varchar(20), Name varchar(20),GPU varchar(20),TanSo varchar(20),BoNho varchar(20),GiaoTiep varchar(20),CongKetNoi varchar(20),TanNhiet varchar(20),NguonMin varchar(20))";
            ls.Add(cardManHinh);
            var manHinh = "create table ManHinh (ThuongHieu varchar(20), Name varchar(20),KichThuoc varchar(20),DoPhanGiai varchar(20),KieuMan varchar(20))";
            ls.Add(manHinh);
            var ocung = "create table OCung (ThuongHieu varchar(20), Name varchar(20),DungLuong varchar(20),KichThuoc varchar(20),KetNoi varchar(20),TocDoDoc varchar(20),TocDoGhi varchar(20))";
            ls.Add(ocung);
            var nguon = "create table Nguon (ThuongHieu varchar(20), Name varchar(20),CongSuat varchar(20),SoChan varchar(100),HieuSuat varchar(20),Quat varchar(20))";
            ls.Add(nguon);
            foreach (var sql in ls)
            {
                CreateTable(sql, m_dbConnection);

            }
            //b1:tạo câu lệnh
            //B2; mở command
            //b3:mở Quẻy


            //sql = "insert into highscores (Thương Hiệu, score) values ('Me', 9001)";

            //command = new SQLiteCommand(sql, m_dbConnection);
            //command.ExecuteNonQuery();

            m_dbConnection.Close();
        }

        private void CreateTable(string sql, SQLiteConnection m_dbConnection)
        {
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

    }
}
