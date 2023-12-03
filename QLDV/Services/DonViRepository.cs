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
    public class DonViRepository :DonViInterface
    {
        private readonly HeThongContext _context;

        public DonViRepository(HeThongContext context)
        {
            _context = context;
        }
        public DonViView Add(DonViView DonVi)
        {


            var _DonVi = new DonVi
            {
                Ten = DonVi.Ten,
                Sdt = DonVi.Sdt,
                DiaChi = DonVi.DiaChi,
                IdCapTrenNavigation = _context.DonVis.SingleOrDefault(lo => lo.Ten == DonVi.CapTren),
                IdLoaiDvNavigation = _context.LoaiDonVis.SingleOrDefault(lo => lo.TenNhom == DonVi.LoaiDv)


            };
            _context.Add(_DonVi);
            _context.SaveChanges();

            return new DonViView
            {
                Id = _DonVi.Id,
                Ten = _DonVi.Ten,
                Sdt = _DonVi.Sdt,
                DiaChi = _DonVi.DiaChi,
                CapTren = _DonVi.IdCapTrenNavigation.Ten,
                 LoaiDv= _DonVi.IdLoaiDvNavigation.TenNhom
            };
        }

        public void Delete(int id)
        {
            var DonVi = _context.DonVis.SingleOrDefault(lo => lo.Id == id);
            if (DonVi != null)
            {
                _context.Remove(DonVi);
                _context.SaveChanges();
            }
        }

        public List<DonViView> GetAll()
        {
            var DonVis = _context.DonVis.Select(l => new DonViView
            {

                Id = l.Id,
                Ten = l.Ten,
                Sdt = l.Sdt,
                DiaChi = l.DiaChi,


                CapTren = l.IdCapTrenNavigation.Ten,

                LoaiDv = l.IdLoaiDvNavigation.TenNhom,

            });
            return DonVis.ToList();
        }



        public DonViView GetByID(int id)
        {
            var l = _context.DonVis.SingleOrDefault(d => d.Id == id);

            if (l != null)
            {
                string captren = string.Empty;
                string loaidonvi = string.Empty;

                if (l.IdCapTrenNavigation != null && l.IdCapTrenNavigation.Ten != null)
                {
                    captren = l.IdCapTrenNavigation.Ten;
                }

                if (l.IdLoaiDvNavigation != null && l.IdLoaiDvNavigation.TenNhom != null)
                {
                    loaidonvi = l.IdLoaiDvNavigation.TenNhom;
                }

                return new DonViView
                {
                    Id = l.Id,
                    Ten = l.Ten,
                    Sdt = l.Sdt,
                    DiaChi = l.DiaChi,

                    CapTren = captren,
                    LoaiDv = loaidonvi
                };
            }

            return null;
        }


        public void Update(DonViView DonVi)
        {
            var _DonVi = _context.DonVis.SingleOrDefault(lo => lo.Id == DonVi.Id);
            _DonVi.Ten = DonVi.Ten;
            _DonVi.Sdt = DonVi.Sdt;
            _DonVi.DiaChi = DonVi.DiaChi;
            _DonVi.IdCapTrenNavigation = _context.DonVis.SingleOrDefault(lo => lo.Ten == DonVi.CapTren);
            _DonVi.IdLoaiDvNavigation = _context.LoaiDonVis.SingleOrDefault(lo => lo.TenNhom == DonVi.LoaiDv);

            _context.SaveChanges();
        }

        public List<DonViView> GetAllSubordinates(int id)
        {
            var subordinates = new List<DonViView>();

            // Lấy đơn vị dựa trên ID
            var unit = _context.DonVis.SingleOrDefault(d => d.Id == id);
            //var unit = _context.DonVis.FromSqlRaw("EXEC ListChildDonVi {0}", id).ToList();


            if (unit != null)
            {
                var subordinateunits = GetSubordinateUnits(unit);

                foreach (var subUnit in subordinateunits)
                {


                    subordinates.Add(new DonViView
                    {
                        Id = subUnit.Id,
                        Ten = subUnit.Ten,
                        Sdt = subUnit.Sdt,
                        DiaChi = subUnit.DiaChi,
                        CapTren = subUnit.IdCapTrenNavigation.Ten,
                        LoaiDv = subUnit.IdLoaiDvNavigation.TenNhom
                    });

                    //Gọi đệ quy để lấy các cấp dưới của subUnit
                    var subordinatesOfSubUnit = GetAllSubordinates(subUnit.Id);
                    if (subordinatesOfSubUnit.Any())
                    {
                        subordinates.AddRange(subordinatesOfSubUnit);
                    }
                }
            }

            return subordinates;
        }

        private IEnumerable<DonVi> GetSubordinateUnits(DonVi unit)
        {
            // Lấy tất cả các đơn vị cấp dưới của unit hiện tại
            return _context.DonVis
                .Include(d => d.IdLoaiDvNavigation)
                .Where(d => d.IdCapTren == unit.Id).ToList();
        }
        #region Search 
        public List<DonViView> Search(string search)
        {
            var subordinates = new List<DonViView>();

            // Lấy đơn vị dựa trên ID



            var subordinateUnits = SearchAll(search);

            foreach (var subUnit in subordinateUnits)
            {


                subordinates.Add(new DonViView
                {
                    Id = subUnit.Id,
                    Ten = subUnit.Ten,
                    Sdt = subUnit.Sdt,
                    DiaChi = subUnit.DiaChi,
                    CapTren = subUnit.IdCapTrenNavigation.Ten,
                    LoaiDv = subUnit.IdLoaiDvNavigation.TenNhom
                });



            }


            return subordinates;
        }
        private IEnumerable<DonVi> SearchAll(string searchKeyword)
        {
            // Chuyển đổi kí tự nhập vào sang chữ thường để thực hiện tìm kiếm không phân biệt hoa thường
            string lowercaseKeyword = searchKeyword.ToLower();

            var subordinateUnits = _context.DonVis
                .Include(d => d.IdLoaiDvNavigation)
                 .Include(d => d.IdCapTrenNavigation)
                .Where(d => (d.Ten.ToLower().Contains(lowercaseKeyword)
                                                        || d.Sdt.ToLower().Contains(lowercaseKeyword)
                                                        || d.DiaChi.ToLower().Contains(lowercaseKeyword)
                                                        || d.IdCapTrenNavigation.Ten.ToLower().Contains(lowercaseKeyword)
                                                        || d.IdLoaiDvNavigation.TenNhom.ToLower().Contains(lowercaseKeyword)
                                                       // Thêm các trường cần tìm kiếm ở đây tương ứng với mô hình của bạn
                                                       ))
                .ToList();


            return subordinateUnits;
        }
        #endregion
        #region Loai don vi 

        public List<DonViView> GetAllLoai(int id)
        {
            var subordinates = new List<DonViView>();

            // Lấy đơn vị dựa trên ID
            var subordinateUnits = _context.DonVis
               .Include(d => d.IdLoaiDvNavigation)
                 .Include(d => d.IdCapTrenNavigation)

                .Where(d => d.IdLoaiDv == id).ToList();
            List<DonVi> donvis = _context.DonVis.FromSqlRaw("EXEC SearchDonVi {0}", id).ToList();



            foreach (var subUnit in subordinateUnits)
            {


                subordinates.Add(new DonViView
                {
                    Id = subUnit.Id,
                    Ten = subUnit.Ten,
                    Sdt = subUnit.Sdt,
                    DiaChi = subUnit.DiaChi,
                    CapTren = subUnit.IdCapTrenNavigation.Ten,
                    LoaiDv = subUnit.IdLoaiDvNavigation.TenNhom
                });

                // Gọi đệ quy để lấy các cấp dưới của subUnit

            }


            return subordinates;
        }


        #endregion
    }
}
