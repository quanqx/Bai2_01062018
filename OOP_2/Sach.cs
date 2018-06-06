using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    class Sach
    {
        private String MaSach;
        private String TenSach;
        private String TacGia;
        private String NhaXB;
        private int NamXB;

        public Sach()
        {
        }

        public Sach(string maSach, string tenSach, string tacGia, string nhaXB, int namXB)
        {
            MaSach = maSach;
            TenSach = tenSach;
            TacGia = tacGia;
            NhaXB = nhaXB;
            NamXB = namXB;
        }

        public String MASACH
        {
            get { return MaSach; }
            set { MaSach = value; }
        }

        public String TENSACH
        {
            get { return TenSach; }
            set { TenSach = value; }
        }

        public String TACGIA
        {
            get { return TacGia; }
            set { TacGia = value; }
        }

        public String NHAXB
        {
            get { return NhaXB; }
            set { NhaXB = value; }
        }

        public int NAMXB
        {
            get { return NamXB; }
            set { NamXB = value; }
        }
    }
}
