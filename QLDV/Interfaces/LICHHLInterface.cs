using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Interfaces
{
    public interface LICHHLInterface
    {
        List<LICHHLView> GetAll();
        List<LICHHLView> Filter(int idDV);
        void Add(LICHHLView loai);
        void Update(LICHHLView loai);
        void Delete(int id);
        List<LICHHLView> Search(string search, int idDV);
    }
}
