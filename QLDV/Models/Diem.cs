using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class Diem
    {
        public int HocVienId { get; set; }
        public int MonHocId { get; set; }
        public double? ChuyenCan { get; set; }
        public double? ThuongXuyen { get; set; }
        public double? Thi { get; set; }
        public double? TrungBinh { get; set; }

        public virtual HocVien HocVien { get; set; }
        public virtual MonHoc MonHoc { get; set; }
    }
}
