using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class Khhl
    {
        public Khhl()
        {
            ChuyenCans = new HashSet<ChuyenCan>();
            MonHocs = new HashSet<MonHoc>();
        }

        public int Id { get; set; }
        public string TenMonHoc { get; set; }
        public int? TietHocBatDau { get; set; }
        public int? TietHocKetThuc { get; set; }
        public double? ThoiLuong { get; set; }
        public int? DonViId { get; set; }
        public DateTime? NgayLap { get; set; }

        public virtual ICollection<ChuyenCan> ChuyenCans { get; set; }
        public virtual ICollection<MonHoc> MonHocs { get; set; }
    }
}
