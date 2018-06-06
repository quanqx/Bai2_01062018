using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{

    interface IPhieuMuonHandling: IRender
    {
        void AddPhieuMuon(List<PhieuMuon> phieuMuons, PhieuMuon phieuMuon);
    }

    class PhieuMuonHandling:IPhieuMuonHandling
    {

        public void AddPhieuMuon(List<PhieuMuon> lstPhieuMuon, PhieuMuon phieuMuon)
        {
            lstPhieuMuon.Add(phieuMuon);
        }

        public void Show()
        {
            Console.WriteLine("\n\n***************************** " + DateTime.Now + "  ---  Nhap sach ****************************");
        }
    }
}
