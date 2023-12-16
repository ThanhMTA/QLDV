using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Models
{
    public class DiemHV
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Quequan { get; set; }
        public string CapBac { get; set; }
        public string Sdt { get; set; }
        public string Cccd { get; set; }
        public string DonVi { get; set; }
        public double? Diem { get; set; }
        public int Comat { get; set; }
    }
}
