using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Interfaces
{
    public interface KHHLInterface
    {
        List<KHHLView> GetAll();
        List<KHHLView> GetID(int id);
        List<KHHLView> GetCon(int id);

        List<KHHLView> Filter(int idDV);
        void Add(KHHLView loai);
        void Update(KHHLView loai);
        void Delete(int id);
        List<KHHLView> Search(string search, int idDV);
    }
}
