using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Interfaces
{
    public interface HocVienInterface
    {
        List<HocVienView> GetAll();
        List<HocVienView> Filter(int idDV);
        void Add(HocVienView loai);
        void Update(HocVienView loai);
        void Delete(int id);
        List<HocVienView> Search(string search,int idDV);
    }
}
