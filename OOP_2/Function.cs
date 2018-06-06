using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    static class Function
    {
        public static String SinhMa(String TienTo)
        {
            int Y = DateTime.Now.Year;
            int M = DateTime.Now.Month;
            int D = DateTime.Now.Day;
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;
            return TienTo + Y + (M < 10 ? "0" + M : M + "") + (D < 10 ? "0" + D : D + "")+ (h < 10 ? "0" + h : h + "") + (m < 10 ? "0" + h : h + "") + (s < 10 ? "0" + s : s + "");
        }
    }
}
