using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDuLich.Models
{
    public class Tour
    {
        public int MaTour { get; set; }
        public string TenTour { get; set; }
        public string ChuongTrinh { get; set; }
        public int SoNgay { get; set; }
        public int Dongia { get; set; }
        public int MDD { get; set; }
        public string Hinh { get; set; }               
    }
}