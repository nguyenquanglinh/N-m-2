using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongNet
{
    public class Tang
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tang"></param>
        /// <param name="soPhong"></param>
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

    public  class LinhKien
    {
        public LinhKien() { }
        public LinhKien(string thuongHieu,string name) : this()
        {
            this.ThuongHieu = thuongHieu;
            this.Name = name;
        }

        public string Name { get; private set; }
        public string ThuongHieu { get; private set; }

        public override string ToString()
        {
            return ThuongHieu +", "+ Name;
        }
    }

    public class Ram:LinhKien
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
        public Ram(string thuongHieu, string dungLuong, string name, string bus, string uSing) : base(thuongHieu, name)
        {
            this.DungLuong = dungLuong;
            this.Bus = bus;
            this.Using = uSing;
        }

        public string Bus { get; private set; }
        public string DungLuong { get; private set; }
      
        public string Using { get; private set; }



        public override string ToString()
        {
            return "Thông tin Ram: \n" + "Thương hiệu: " + ThuongHieu + ", khe ram: " + Name + ", dung luong: " + DungLuong.ToString() + " , " + "Bus: " + Bus.ToString() + ".\n";
        }
    }

    public class CPU:LinhKien
    {
        public CPU()
        {
        }


        /// <summary>
        /// Cpu
        /// </summary>
        /// <param name="thuongHieu">intel,...</param>
        /// <param name="name">dòng cpu i3,i5,i7,..</param>
        /// <param name="socket"></param>
        /// <param name="todo"></param>
        /// <param name="nhan">số nhân</param>
        public CPU(string thuongHieu, string name, string socket, string todo, string nhan) : base(thuongHieu, name)
        {
            this.Socket = socket;
            this.TocDo = todo;
            this.Nhan = nhan;
        }

        public string Nhan { get; private set; }
        public string Socket { get; private set; }
        public string TocDo { get; private set; }


        public override string ToString()
        {
            return "Thông tin Cpu: \n" + "Thương hiệu: " + ThuongHieu + ", Dòng: " + Name + ", Socket: " + Socket + " , " + "xung: " + TocDo + ", " + Nhan + " nhân.\n";
        }
    }

    public class MainBoard:LinhKien
    {
        public MainBoard() { }


        /// <summary>
        /// mainboard
        /// </summary>
        /// <param name="thuongHieu"></param>
        /// <param name="name"></param>
        /// <param name="socket"></param>
        /// <param name="chipset"></param>
        /// <param name="soKheRam">khả năng mở rộng khay ram</param>
        /// <param name="boNhoRamToiDa">khả năng quản lý ram tối đa</param>
        /// <param name="busRam">tốc độ xử lý</param>
        /// <param name="tenRam">DDR3/4</param>
        public MainBoard(string thuongHieu, string name, string socket, string chipset, string soKheRam, string boNhoRamToiDa, string busRam, string tenRam) : base(thuongHieu, name)
        {
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
        public string Socket { get; private set; }
        public string SoKheRam { get; private set; }
        public string TenRam { get; private set; }

        public override string ToString()
        {
            return "Thông tin MainBoard: \n" + "Thương hiệu: " + ThuongHieu + ", tên:" + Name + ", Socket: " + Socket + " , " + "Chipset: " + Chipset + ", Khe ram tối đa:" + SoKheRam + ", Hỗ trợ ram tối đa: " + BoNhoRamToiDa + ", Bus: " + BusRam + ", ram hỗ trợ " + TenRam + ".\n";
        }
    }


    public class CardManhinh:LinhKien
    {
        public CardManhinh() { }
        /// <summary>
        /// card man hinh
        /// </summary>
        /// <param name="thuongHieu"></param>
        /// <param name="name"></param>
        /// <param name="gpu"></param>
        /// <param name="tanSo"></param>
        /// <param name="boNho"></param>
        /// <param name="giaoTiep"></param>
        /// <param name="congKetNoi"></param>
        /// <param name="tanNhiet"></param>
        /// <param name="nguonMin"></param>
        public CardManhinh(string thuongHieu, string name,string gpu,string tanSo,string boNho,string giaoTiep,string congKetNoi,string tanNhiet,string nguonMin) : base(thuongHieu, name)
        {
            this.GPU = gpu;
            this.TanSo = tanSo;
            this.BoNho = boNho;
            this.GiaoTiep = giaoTiep;
            this.CongketNoi = congKetNoi;
            this.TanNhiet = tanNhiet;
            this.Nguon = nguonMin;
        }

        public override string ToString()
        {
            return "Thông tin Card Màn hình: \n" + "Thương hiệu: " + ThuongHieu + ", Dòng: " + Name + ", GPU: " + GPU + " , " + "tần số: " + TanSo + ", Bộ nhớ: " + BoNho + ", Cổng hỗ trợ: "+CongketNoi+", PP giao tiếp: "+GiaoTiep+ ", tản nhiêt: "+TanNhiet+", Nguồn đề xuất: "+Nguon+".\n";

        }

        public string BoNho { get; private set; }
        public string CongketNoi { get; private set; }
        public string GiaoTiep { get; private set; }
        public string GPU { get; private set; }
        public string Nguon { get; private set; }
        public string TanNhiet { get; private set; }
        public string TanSo { get; private set; }
    }

    public class OCung:LinhKien
    {
        public OCung() { }


        public OCung(string thuongHieu,string name,string dungLuong,string kichThuoc,string ketNoi,string tocDoDoc,string tocDoGhi) : base(thuongHieu, name)
        {
            this.DungLuong = dungLuong;
            this.KichThuoc = kichThuoc;
            this.TocDoDoc = tocDoDoc;
            this.TocDoGhi = tocDoGhi;
            this.KetNoi = ketNoi;
        }

        public string DungLuong { get; private set; }
        public string KetNoi { get; private set; }
        public string KichThuoc { get; private set; }
        public string TocDoDoc { get; private set; }
        public string TocDoGhi { get; private set; }

        public override string ToString()
        {
            return "Thông tin ổ cứng:\n" + "Thương Hiệu: " + ThuongHieu + ", tên: " + Name + ", dung lượng: " + DungLuong + ", kích thước: " + KichThuoc + ", kết nối: " + KetNoi + ", tốc độ đọc: " + TocDoDoc + ", tốc độ ghi: " + TocDoGhi + ".\n";
        }
    }

    public class ManHinh:LinhKien
    {
        public ManHinh() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thuongHieu"></param>
        /// <param name="name"></param>
        /// <param name="kichThuocMan"></param>
        /// <param name="doPhanGiai"></param>
        /// <param name="kieuMan"></param>
        public ManHinh(string thuongHieu,string name,string kichThuocMan,string doPhanGiai,string kieuMan) : base(thuongHieu, name)
        {
            this.KichThuoc = kichThuocMan;
            this.DoPhanGiai = doPhanGiai;
            this.KieuManHinh = kieuMan;
        }

        public string DoPhanGiai { get; private set; }
        public string KichThuoc { get; private set; }
        public string KieuManHinh { get; private set; }
        public override string ToString()
        {
            return "Thông tin màn hình:\n" + "Thương hiệu: " + ThuongHieu +", tên: "+Name+ ", kích thước: " + KichThuoc + ", Kiểu màn: " + KieuManHinh + ", Độ phân giải: " + DoPhanGiai + ".\n";
        }
    }

    public class CauHinh
    {
        public CauHinh(Ram ram, CPU cpu, CardManhinh cardManHinh, OCung oCung, ManHinh manHinh)
        {
            this.Ram = ram;
            this.Cpu = cpu;
            this.CardManHinh = cardManHinh;
            this.OCung = oCung;
            this.ManHinh = manHinh;
        }

        public CardManhinh CardManHinh { get; private set; }
        public CPU Cpu { get; private set; }
        public ManHinh ManHinh { get; private set; }
        public OCung OCung { get; private set; }
        public Ram Ram { get; private set; }

        public CauHinh() { }
    }


    public class Computer : CauHinh
    {
        public Computer(Ram ram, CPU cpu, CardManhinh cardManHinh, OCung oCung, ManHinh manHinh) : base(ram, cpu, cardManHinh, oCung, manHinh)
        {
        }
        public Computer():base()
        {
        }
        public Computer(int so) : this() { }
        public override string ToString()
        {
            return "thong tin may";
        }
    }

}
