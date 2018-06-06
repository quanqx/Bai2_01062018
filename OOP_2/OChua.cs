using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    class OChua
    {
        private String MaOChua;
        private String MaSach;
        private int SoLuong;

        public OChua()
        {
        }

        public OChua(string maOChua, string maSach, int soLuong)
        {
            MaOChua = maOChua;
            MaSach = maSach;
            SoLuong = soLuong;
        }

        public String MaOCHUA
        {
            get { return MaOChua; }
            set { MaOChua = value; }
        }

        public String MASACH
        {
            get { return MaSach; }
            set { MaSach = value; }
        }

        public int SOLUONG
        {
            get { return SoLuong; }
            set { SoLuong = value; }
        }
    }
}

