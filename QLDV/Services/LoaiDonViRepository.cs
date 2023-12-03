using Microsoft.EntityFrameworkCore;
using QLDV.Interfaces;
using QLDV.Models;
using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Services
{
    public class LoaiDonViRepository : LoaiDonViInterface
    {
        private readonly HeThongContext _context;

        public LoaiDonViRepository(HeThongContext context)
        {
            _context = context;
        }
        public LoaiDonViView Add(LoaiDonViView loai)
        {
            var _loai = new LoaiDonVi
            {
                TenNhom = loai.TenNhom
            };
            _context.Add(_loai);
            _context.SaveChanges();

            return new LoaiDonViView 
            {
                Id = _loai.Id,
                TenNhom = _loai.TenNhom
            };
        }

        public void Delete(int id)
        {
            var loai = _context.LoaiDonVis.SingleOrDefault(lo => lo.Id == id);
            if (loai != null)
            {
                _context.LoaiDonVis.Remove(loai); // Đánh dấu bản ghi cần xóa
                _context.SaveChanges();
            }
        }

        public List<LoaiDonViView> GetAll()
        {
            var subordinates = new List<LoaiDonViView>();

            string proc = "exec GetAllLoaiDonVis";
            var loais = _context.LoaiDonVis.FromSqlRaw(proc).ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new LoaiDonViView
                {
                    Id = subUnit.Id,
                    TenNhom = subUnit.TenNhom,

                });



            }
            return subordinates;
        }

        public LoaiDonViView GetByID(int id)
        {
            var loai = _context.LoaiDonVis.SingleOrDefault(l => l.Id == id);
            if (loai != null)
            {
                return new LoaiDonViView
                {
                    Id = loai.Id,
                    TenNhom = loai.TenNhom
                };
            }
            return null;
        }

        public void Update(LoaiDonViView loai)
        {
            var _loai = _context.LoaiDonVis.SingleOrDefault(lo => lo.Id == loai.Id);
            _loai.TenNhom = loai.TenNhom;
            _context.SaveChanges();
        }
        #region Search 
        public List<LoaiDonViView> Search(string search)
        {
            var subordinates = new List<LoaiDonViView>();

            // Lấy đơn vị dựa trên ID


            
            var subordinateUnits = _context.LoaiDonVis.FromSqlRaw("SearchLoaiDonVi {0}",search).ToList();

            foreach (var subUnit in subordinateUnits)
            {


                subordinates.Add(new LoaiDonViView
                {
                    Id = subUnit.Id,
                    TenNhom = subUnit.TenNhom,

                });



            }


            return subordinates;
        }
        private IEnumerable<LoaiDonVi> SearchAll(string searchKeyword)
        {
            // Chuyển đổi kí tự nhập vào sang chữ thường để thực hiện tìm kiếm không phân biệt hoa thường
            //string lowercaseKeyword = searchKeyword.ToLower();

            //var subordinateUnits = _context.LoaiDonVis
            //    .Where(d => (d.TenNhom.ToLower().Contains(lowercaseKeyword)

            //                                           ))
            //    .ToList();
            var loais = _context.LoaiDonVis.FromSqlRaw("SearchLoaiDonVi {0}", searchKeyword).ToList();



            return loais;
        }
        #endregion
    }
}
