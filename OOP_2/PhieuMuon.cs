using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    class PhieuMuon
    {
        private String MaPhieuMuon;
        private String MaDG;
        private String MaSach;
        private DateTime NgayMuon;
        private Boolean TrangThai;

        public PhieuMuon()
        {
        }

        public PhieuMuon(string maPhieuMuon, string maDocGia, string maSach, DateTime ngayMuon, bool trangThai)
        {
            MaPhieuMuon = maPhieuMuon;
            MaDG = maDocGia;
            MaSach = maSach;
            NgayMuon = ngayMuon;
            TrangThai = trangThai;
        }

        public String MaPhieuMUON
        {
            get { return MaPhieuMuon; }
            set { MaPhieuMuon = value; }
        }

        public String MADG
        {
            get { return MaDG; }
            set { MaDG = value; }
        }

        public String MASACH
        {
            get { return MaSach; }
            set { MaSach = value; }
        }

        public DateTime NGAYMUON
        {
            get { return NgayMuon; }
            set { NgayMuon = value; }
        }

        public Boolean TRANGTHAI
        {
            get { return TrangThai; }
            set { TrangThai = value; }
        }
    }
}
