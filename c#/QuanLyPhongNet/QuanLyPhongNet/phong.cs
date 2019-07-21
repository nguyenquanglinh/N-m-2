using System.Collections.Generic;

namespace QuanLyPhongNet
{
   
    public class Phong
    {
        public Phong(int Int,List<Computer>computerNumber)
        {
            this.Int = Int;
            this.SoMay = computerNumber;
        }

        public int Int { get; private set; }
        public List<Computer> SoMay { get; private set; }
    }
}