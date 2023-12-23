using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Views
{
    public class KHHLView
    {
        public int Id { get; set; }
        public string Noidung { get; set; }
        public DateTime? Tgbatdau { get; set; }
        public DateTime? Tgketthuc { get; set; }
        public double? Tongtiethoc { get; set; }
        public int? Tongnbuoihoc { get; set; }
        public DateTime? Ngaylap { get; set; }
        public string MaKhhl { get; set; }
        public string DonVi{ get; set; }
        public string  Khcha { get; set; }

    }
}
