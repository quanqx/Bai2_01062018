using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    class Program
    {

        private List<Sach> lstSach = new List<Sach>();
        private List<OChua> lstOChua = new List<OChua>();
        private List<PhieuMuon> lstPhieuMuon = new List<PhieuMuon>();
        private ISachHandling sachHandling;
        private IOChuaHandling oChuaHandling;
        private IPhieuMuonHandling phieuMuonHandling;
        private int n;

        Program(IOChuaHandling oChua, ISachHandling sach, IPhieuMuonHandling phieuMuon)
        {
            sachHandling = sach;
            oChuaHandling = oChua;
            phieuMuonHandling = phieuMuon;
        }

        private void NhapSach()
        {
            sachHandling.Show();
            Console.WriteLine("Nhap ten sach: ");
            String TenSach = Console.ReadLine();
            Sach sach = sachHandling.getSachByTen(TenSach, lstSach);
            if (sach != null)
            {
                Console.WriteLine("Sach da co trong thu vien! Ma sach: " + sach.MASACH);
                XepSach(sach);
                sachHandling.AddSach(sach, lstSach);
                return;
            }
            String MaSach = Function.SinhMa("Sach");
            Console.WriteLine("Tac gia: ");
            String TacGia = Console.ReadLine();
            Console.WriteLine("Nha xuat ban: ");
            String NhaXB = Console.ReadLine();
            Console.WriteLine("Nam xuat ban: ");
            int NamXB = Convert.ToInt32(Console.ReadLine());
            Sach newSach = new Sach(MaSach, TenSach, TacGia, NhaXB, NamXB);
            XepSach(newSach);
            sachHandling.AddSach(newSach, lstSach);
        }

        private void XepSach(Sach sach)
        {
            if (oChuaHandling.XepSach(sach, lstOChua, n))
                Console.WriteLine("Nhap sach thanh cong!");
            else
                Console.WriteLine("Het o chua! Nhap sach khong thanh cong!");
        }

        private void ShowOChua()
        {
            oChuaHandling.Show();
            if(lstOChua.Count == 0)
            {
                Console.WriteLine("Khong co o chua!");
                return;
            }
            for (int i = 0; i < lstOChua.Count; i++)
            {
                Console.WriteLine("\nMa o chua: " + lstOChua[i].MaOCHUA + " Ma sach: " + lstOChua[i].MASACH + " So luong: " + lstOChua[i].SOLUONG);
            }
        }

        private void ShowThongTinSach()
        {
            oChuaHandling.Show();
            if(lstSach.Count == 0)
            {
                Console.WriteLine("Khong co sach nao!");
                return;
            }

            Dictionary<String, int> slMoiSach = sachHandling.getSLMoiSach(lstSach);
            Dictionary<String, int> slMoiSachTrongOChua = oChuaHandling.getSLSachTrongOChua(lstOChua);
            Dictionary<String, int> slMoiSachChoMuon = oChuaHandling.getSLSachChoMuon(slMoiSach, slMoiSachTrongOChua);

            Console.WriteLine("************Thong tin sach**************");

            foreach (var item in slMoiSach)
            {
                Console.WriteLine("***********************");
                for (int i = 0; i < lstSach.Count; i++)
                {
                    if(item.Key == lstSach[i].MASACH)
                    {
                        Console.WriteLine("\nMa sach: " + item.Key + " \nTen sach: " + lstSach[i].TENSACH + "\nSo luong: " + item.Value + " \nSo sach co the cho muon: " + (item.Value - slMoiSachChoMuon[item.Key] ) + " \nSo sach da cho muon: " + slMoiSachChoMuon[item.Key]);
                        break;
                    }
                }
            }
        }

        private void TimSach()
        {
            oChuaHandling.Show();

            Console.WriteLine("Nhap ma sach can tim: ");
            String MaSach = Console.ReadLine();
            Dictionary<String, int> slMoiSach = sachHandling.getSLMoiSach(lstSach);
            Dictionary<String, int> slMoiSachTrongOChua = oChuaHandling.getSLSachTrongOChua(lstOChua);
            Dictionary<String, int> slMoiSachChoMuon = oChuaHandling.getSLSachChoMuon(slMoiSach, slMoiSachTrongOChua);
            for (int i = 0; i < lstSach.Count; i++)
            {
                if(lstSach[i].MASACH == MaSach)
                {
                    Console.WriteLine("\nMa sach: " + MaSach + " \nTen sach: " + lstSach[i].TENSACH + " \nSo sach co the cho muon: " + (slMoiSach[MaSach] - slMoiSachChoMuon[MaSach]) + " \nSo sach da cho muon: " + slMoiSachChoMuon[MaSach]);
                    return;
                }
            }
            Console.WriteLine("Khong tim thay!");
        }

        private void TaoPhieuMuon()
        {
            oChuaHandling.Show();
            Dictionary<String, int> slMoiSach = sachHandling.getSLMoiSach(lstSach);
            Dictionary<String, int> slMoiSachTrongOChua = oChuaHandling.getSLSachTrongOChua(lstOChua);
            Dictionary<String, int> slMoiSachChoMuon = oChuaHandling.getSLSachChoMuon(slMoiSach, slMoiSachTrongOChua);

            String MaPhieuMuon = Function.SinhMa("PhieuMuon");
            Console.WriteLine("Nhap ma doc gia: ");
            String MaDG = Console.ReadLine();
            Console.WriteLine("\n******************* Sach co the cho muon *******************");
            showSachCoTheMuon();
            Console.WriteLine("Nhap ma sach can muon: ");
            String MaSach = Console.ReadLine();
            List<OChua> lstOChuaBySach = oChuaHandling.lstOChuaByMaSach(MaSach, lstOChua);
            Console.WriteLine("Sach trong o chua: ");
            for (int i = 0; i < lstOChuaBySach.Count; i++)
            {
                Console.WriteLine(i + ".Ma o chua: " + lstOChuaBySach[i].MaOCHUA + ", so luong: " + lstOChuaBySach[i].SOLUONG);
            }
            Console.WriteLine("Chon o chua (Ma o chua): ");
            String MaOChua = Console.ReadLine();
            oChuaHandling.DeleteFromOChua(MaOChua, lstOChua);
            DateTime NgayMuon = DateTime.Now;
            Boolean TrangThai = false;
            phieuMuonHandling.AddPhieuMuon(lstPhieuMuon, new PhieuMuon(MaPhieuMuon, MaDG, MaSach, NgayMuon, TrangThai));
        }

        private void showSachCoTheMuon()
        {
            Dictionary<String, int> slMoiSach = sachHandling.getSLMoiSach(lstSach);
            Dictionary<String, int> slMoiSachTrongOChua = oChuaHandling.getSLSachTrongOChua(lstOChua);
            Dictionary<String, int> slMoiSachChoMuon = oChuaHandling.getSLSachChoMuon(slMoiSach, slMoiSachTrongOChua);
            foreach (var item in slMoiSach)
            {
                for (int i = 0; i < lstSach.Count; i++)
                {
                    if (item.Key == lstSach[i].MASACH && item.Value - slMoiSachChoMuon[item.Key] > 0)
                    {
                        Console.WriteLine("\nMa sach: " + item.Key + " Ten sach: " + lstSach[i].TENSACH + " So sach co the cho muon: " + (item.Value - slMoiSachChoMuon[item.Key]));
                        break;
                    }
                }
            }
        }

        public void Show()
        {
            Console.WriteLine("\n\n***************************** " + DateTime.Now + "  ---  Quan ly thu vien ****************************");
        }

        static void Main(string[] args)
        {
            Program program = new Program(new OChuaHandling(), new SachHandling(), new PhieuMuonHandling());
            program.Show();
            Console.WriteLine("Nhap vao so o chua: ");
            program.n = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                program.Show();
                Console.WriteLine("1.Nhap sach vao thu vien.");
                Console.WriteLine("2.Thong tin o chua.");
                Console.WriteLine("3.Thong tin sach.");
                Console.WriteLine("4.Tim kiem sach.");
                Console.WriteLine("5.Tao phieu muon.");
                Console.WriteLine("0.Thoat.");
                Console.WriteLine("Chon chuc nang: ");
                try
                {
                    int x = Convert.ToInt32(Console.ReadLine());
                    switch (x)
                    {
                        case 0:
                            break;
                        case 1:
                            program.NhapSach();
                            break;
                        case 2:
                            program.ShowOChua();
                            break;
                        case 3:
                            program.ShowThongTinSach();
                            break;
                        case 4:
                            program.TimSach();
                            break;
                        case 5:
                            program.TaoPhieuMuon();
                            break;
                        default:
                            Console.WriteLine("Sai cu phap!");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Sai cu phap!");
                    continue;
                }
                finally
                {
                    Console.WriteLine("Nhan enter....");
                    Console.ReadLine();
                    Console.Clear();
                }
                
            }
        }
    }
}
