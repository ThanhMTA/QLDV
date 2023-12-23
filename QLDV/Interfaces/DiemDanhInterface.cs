using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLDV.Views;

namespace QLDV.Interfaces
{
    public interface DiemDanhInterface
    {
        List<HocVienView> GetAll(int khhl, string dv);
        List<DVHLView> GetDV(int khhl);
        void Update(DiemDanhView loai);
    }
}
