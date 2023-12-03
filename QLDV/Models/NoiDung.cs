using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class NoiDung
    {
        public int Id { get; set; }
        public string NoiDungBaiHoc { get; set; }
        public int? GiaoVienId { get; set; }
        public DateTime? ThoiGianLap { get; set; }
        public int? BaiHocId { get; set; }

        public virtual BaiHoc BaiHoc { get; set; }
        public virtual CanBo GiaoVien { get; set; }
    }
}
