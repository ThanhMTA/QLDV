using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Interfaces
{
    public interface DVHLInterface
    {
        List<DVHLView> GetAll(int khhl);
        List<HocVienView> Filter(string dv);
        void Add(DVHLView loai);
        void Delete(int khhl, string dv);
        List<DVHLView> Search(string search, int khhl);
    }
}
