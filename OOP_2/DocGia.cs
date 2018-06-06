using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    class DocGia
    {
        private String MaDG;
        private String HoTen;
        private DateTime NgaySinh;
        private String DiaChi;
        private String NgheNghiep;

        public DocGia()
        {
        }

        public DocGia(string maDG, string hoTen, DateTime ngaySinh, string diaChi, string ngheNghiep)
        {
            MaDG = maDG;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            NgheNghiep = ngheNghiep;
        }

        public String MADG
        {
            get { return MaDG; }
            set { MaDG = value; }
        }

        public String HOTEN
        {
            get { return HoTen; }
            set { HoTen = value; }
        }

        public DateTime NGAYSINH
        {
            get { return NgaySinh; }
            set { NgaySinh = value; }
        }

        public String DIACHI
        {
            get { return DiaChi; }
            set { DiaChi = value; }
        }

        public String NGHENGHIEP
        {
            get { return NgheNghiep; }
            set { NgheNghiep = value; }
        }
    }
}
