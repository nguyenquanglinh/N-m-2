using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongNet
{
    public class Tang
    {
        public Tang(int tang, List<Phong> soPhong)
        {
            this.Int = tang;
            this.Phong = soPhong;
        }

        public List<Phong> Phong { get; private set; }
        public int Int { get; private set; }


        public override string ToString()
        {
            return "Tang= " + Int + ", so phong= " + Phong.Count();
        }
    }



    public class Ram
    {
        public Ram()
        {

        }
        /// <summary>
        /// Ram
        /// </summary>
        /// <param name="dungLuong">MHZ</param>
        /// <param name="theHe">R3||R4</param>
        /// <param name="bus">chu kỳ đọc ghi</param>
        /// <param name="uSing">Laptop||PC</param>
        public Ram(string thuongHieu, string dungLuong, string name, string bus, string uSing) : this()
        {
            this.DungLuong = dungLuong;
            this.Name = name;
            this.Bus = bus;
            this.Using = uSing;
            this.ThuongHieu = thuongHieu;
        }

        public string Bus { get; private set; }
        public string DungLuong { get; private set; }
        public string Name { get; private set; }
        public string ThuongHieu { get; private set; }
        public string Using { get; private set; }



        public override string ToString()
        {
            return "Thông tin Ram: \n" + "Thương hiệu: " + ThuongHieu + ", khe ram: " + Name + ", dung luong: " + DungLuong.ToString() + " , " + "Bus= " + Bus.ToString() + ".\n";
        }
    }

    public class CPU
    {
        public CPU() { }
        public CPU(string thuongHieu, string name, string socket, string todo, string nhan) : this()
        {
            this.ThuongHieu = thuongHieu;
            this.Name = name;
            this.Socket = socket;
            this.TocDo = todo;
            this.Nhan = nhan;
        }

        public string Name { get; private set; }
        public string Nhan { get; private set; }
        public string Socket { get; private set; }
        public string ThuongHieu { get; private set; }
        public string TocDo { get; private set; }


        public override string ToString()
        {
            return "Thông tin Cpu: \n" + "Thương hiệu: " + ThuongHieu + ", Dòng: " + Name + ", Socket: " + Socket + " , " + "xung: " + TocDo + ", " + Nhan + " nhân.\n";
        }
    }

    public class MainBoard
    {
        public MainBoard() { }
        public MainBoard(string thuongHieu,string name,string socket,string chipset,string soKheRam,string boNhoRamToiDa,string busRam,string tenRam) : this()
        {
            this.ThuongHieu = thuongHieu;
            this.Name = name;
            this.Socket = socket;
            this.Chipset = chipset;
            this.SoKheRam = soKheRam;
            this.BoNhoRamToiDa = boNhoRamToiDa;
            this.BusRam = busRam;
            this.TenRam = tenRam;
        }

        public string BoNhoRamToiDa { get; private set; }
        public string BusRam { get; private set; }
        public string Chipset { get; private set; }
        public string Name { get; private set; }
        public string Socket { get; private set; }
        public string SoKheRam { get; private set; }
        public string TenRam { get; private set; }
        public string ThuongHieu { get; private set; }

        public override string ToString()
        {
            return "Thông tin MainBoard: \n" + "Thương hiệu: " + ThuongHieu + ", tên:" + Name + ", Socket: " + Socket + " , " + "Chipset: " + Chipset + ", Khe ram tối đa:" + SoKheRam + ", Hỗ trợ ram tối đa: "+BoNhoRamToiDa+", Bus: "+BusRam+", ram hỗ trợ "+TenRam+".\n";

        }
    }


    public class CauHinh
    {
        public CauHinh(string ram, string cpu, string cardManHinh, string oCung, int manHinh)
        {
            this.Ram = ram;
            this.Cpu = cpu;
            this.CardManHinh = cardManHinh;
            this.OCung = oCung;
            this.ManHinh = manHinh;
        }

        public string CardManHinh { get; private set; }
        public string Cpu { get; private set; }
        public int ManHinh { get; private set; }
        public string OCung { get; private set; }
        public string Ram { get; private set; }
    }


    public class Computer : CauHinh
    {


        public Computer(string ram, string cpu, string cardManHinh, string oCung, int manHinh) : base(ram, cpu, cardManHinh, oCung, manHinh)
        {
        }

        public int Int { get; private set; }
    }
}
