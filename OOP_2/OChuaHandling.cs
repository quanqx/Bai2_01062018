using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{

    interface IOChuaHandling: IRender
    {
        Boolean XepSach(Sach sach, List<OChua> lstOChua, int n);
        List<OChua> lstOChuaByMaSach(String MaSach, List<OChua> lstOChua);
        Dictionary<String, int> getSLSachTrongOChua(List<OChua> lstOChua);
        Dictionary<String, int> getSLSachChoMuon(Dictionary<String, int> SLMoiSach, Dictionary<String, int> SLSachTrongOChua);
        void DeleteFromOChua(String MaOChua, List<OChua> lstOChua);
        OChua getOChuaByMa(String MaOChua, List<OChua> lstOChua);
        OChua getSLMinOChua(List<OChua> lstOChua);
    }

    class OChuaHandling: IOChuaHandling
    {

        public Boolean XepSach(Sach sach, List<OChua> lstOChua, int n)
        {
            List<OChua> OChuas = lstOChuaByMaSach(sach.MASACH, lstOChua);
            if(OChuas.Count != 0)
            {
                for (int i = 0; i < OChuas.Count; i++)
                {
                    if (!OChuaDay(OChuas[i]))
                    {
                        OChuas[i].SOLUONG++;
                        return true;
                    }
                }
                if (HetOChua(lstOChua, n))
                    return false;
                AddSachOnNewOChua(lstOChua, sach.MASACH);
                return true;
            }
            else
            {
                if (HetOChua(lstOChua, n))
                    return false;
                AddSachOnNewOChua(lstOChua, sach.MASACH);
                return true;
            }
        }

        private void AddSachOnNewOChua(List<OChua> lstOChua, String MaSach)
        {
            OChua oChua = new OChua(Function.SinhMa("OChua"), MaSach, 1);
            lstOChua.Add(oChua);
        }

        private Boolean OChuaDay(OChua oChua)
        {
            if (oChua.SOLUONG >= 5)
                return true;
            return false;
        }

        private Boolean HetOChua(List<OChua> lstOChua, int n)
        {
            if (lstOChua.Count >= n)
                return true;
            return false;
        }

        public List<OChua> lstOChuaByMaSach(String MaSach, List<OChua> lstOChua)
        {
            List<OChua> result = new List<OChua>();
            if (lstOChua.Count != 0)
                for (int i = 0; i < lstOChua.Count; i++)
                {
                    if (lstOChua[i].MASACH == MaSach)
                    {
                        result.Add(lstOChua[i]);
                    }
                }
            return result;
        }

        public Dictionary<String, int> getSLSachTrongOChua(List<OChua> lstOChua)
        {
            Dictionary<String, int> res = new Dictionary<String, int>();
            if(lstOChua.Count!= 0)
            {
                for (int i = 0; i < lstOChua.Count; i++)
                {
                    if (!res.ContainsKey(lstOChua[i].MASACH))
                    {
                        res.Add(lstOChua[i].MASACH, lstOChua[i].SOLUONG);
                    }
                    else
                    {
                        res[lstOChua[i].MASACH] += lstOChua[i].SOLUONG;
                    }
                }
            }
            return res;
        }

        public Dictionary<String, int> getSLSachChoMuon(Dictionary<String, int> SLMoiSach, Dictionary<String, int> SLSachTrongOChua)
        {
            Dictionary<String, int> res = new Dictionary<string, int>();
            foreach (var i in SLMoiSach)
            {
                res.Add(i.Key, i.Value);
                foreach (var j in SLSachTrongOChua)
                {
                    if(i.Key == j.Key)
                    {
                        res[i.Key] -= j.Value;
                    }
                }
            }
            return res;
        }

        public void DeleteFromOChua(String MaOChua, List<OChua> lstOChua)
        {
            OChua ochua = new OChua();
            if (MaOChua == "")
            {
                ochua = getSLMinOChua(lstOChua);
            }
            else
            {
                ochua = getOChuaByMa(MaOChua, lstOChua);
            }
            if(ochua.SOLUONG == 1)
            {
                lstOChua.Remove(ochua);
            }
            else
            {
                ochua.SOLUONG--;
            }
        }

        public OChua getOChuaByMa(String MaOChua, List<OChua> lstOChua)
        {
            if(lstOChua.Count == 0)
            {
                return null;
            }
            OChua ochua = new OChua();
            for (int i = 0; i < lstOChua.Count; i++)
            {
                if(lstOChua[i].MaOCHUA == MaOChua)
                {
                    ochua = lstOChua[i];
                }
            }
            return ochua;
        }

        public OChua getSLMinOChua(List<OChua> lstOChua)
        {
            if(lstOChua.Count == 0)
            {
                return null;
            }
            OChua oChua = lstOChua[0];
            for (int i = 1; i < lstOChua.Count; i++)
            {
                if (lstOChua[i].SOLUONG < oChua.SOLUONG)
                {
                    oChua = lstOChua[i];
                }
            }
            return oChua;
        }

        public void Show()
        {
            Console.WriteLine("\n\n***************************** " + DateTime.Now + "  ---  Nhap sach ****************************");
        }
    }
}
