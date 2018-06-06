using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{

    interface ISachHandling: IRender
    {
        Sach getSachByTen(String TenSach, List<Sach> lstSach);
        void AddSach(Sach sach, List<Sach> lstSach);
        Dictionary<String, int> getSLMoiSach(List<Sach> lstSach);
    }

    class SachHandling: ISachHandling, IRender
    {
        public Sach getSachByTen(String TenSach, List<Sach> lstSach)
        {
            if(lstSach.Count == 0)
                return null;
            for (int i = 0; i < lstSach.Count; i++)
            {
                if(lstSach[i].TENSACH == TenSach)
                    return lstSach[i];
            }
            return null;
        }

        public void AddSach(Sach sach, List<Sach> lstSach)
        {
            //if (!lstSach.Contains(sach))
                lstSach.Add(sach);
        }

        public Dictionary<String, int> getSLMoiSach(List<Sach> lstSach)
        {
            Dictionary<String, int> dic = new Dictionary<String, int>();
            if(lstSach != null)
            {
                dic.Add(lstSach[0].MASACH, 1);
                for (int i = 1; i < lstSach.Count; i++)
                {
                    if (lstSach.Count == 1) continue;
                    if (dic.ContainsKey(lstSach[i].MASACH))
                    {
                        dic[lstSach[i].MASACH] += 1;
                    }
                    else
                    {
                        dic.Add(lstSach[i].MASACH, 1);
                    }
                }
            }
            return dic;
        }

        public void Show()
        {
            Console.WriteLine("\n\n***************************** " + DateTime.Now + "  ---  Quan ly thu vien ****************************");
        }
    }
}
