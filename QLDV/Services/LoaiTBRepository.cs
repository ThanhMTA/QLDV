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
    public class LoaiTBRepository : LoaiTBInterface
    {
        private readonly HeThongContext _context;

        public LoaiTBRepository(HeThongContext context)
        {
            _context = context;
        }
        public void Add(LoaiTBView loai)
        {
            var tenLoai = loai.TenLoai;
            var donvi = loai.DonviTinh;
            var idNhomTB = _context.NhomTbs
                     .Where(lo => lo.TenNhom == loai.TenNhomTB)
                     .Select(lo => lo.Id)
                     .SingleOrDefault();

            _context.Database.ExecuteSqlInterpolated($"exec AddLoaiTB {tenLoai},{idNhomTB},{donvi}");
        }


        public void Delete(int id)
        {
            _context.Database.ExecuteSqlInterpolated($"exec DeleteLoaiTB {id}");
        }
        public List<LoaiTBView> GetAll()
        {
            var subordinates = new List<LoaiTBView>();

            string proc = "exec GetAllLoaiTB";
            var loais = _context.LoaiTbs.FromSqlRaw(proc).ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new LoaiTBView
                {
                    Id = subUnit.Id,
                    TenLoai = subUnit.TenLoai,
                    DonviTinh=subUnit.Donvi,
                    SoLuong = subUnit.SoLuong,
                    TenNhomTB = _context.NhomTbs
                    .Where(lo => lo.Id == subUnit.IdNhomTb)
                    .Select(lo => lo.TenNhom)
                    .SingleOrDefault()
                });



            }
            return subordinates;
        }
        #region filter
        public List<LoaiTBView> Filter(int id)
        {
            var subordinates = new List<LoaiTBView>();

       
            var loais = _context.LoaiTbs.FromSqlRaw("FilterLoaiTB {0}",id).ToList();

            foreach (var subUnit in loais)
            {
               subordinates.Add(new LoaiTBView
                {
                    Id = subUnit.Id,
                    TenLoai = subUnit.TenLoai,
                    DonviTinh = subUnit.Donvi,
                    SoLuong = subUnit.SoLuong,
                    TenNhomTB = _context.NhomTbs
                    .Where(lo => lo.Id == subUnit.IdNhomTb)
                    .Select(lo => lo.TenNhom)
                    .SingleOrDefault()
                });



            }
            return subordinates;
        }
        #endregion

        public List<LoaiTBView> Search(string search)
        {
            var subordinates = new List<LoaiTBView>();

            // Lấy đơn vị dựa trên ID



            var subordinateUnits = _context.LoaiTbs.FromSqlRaw("SearchLoaiTB {0}", search).ToList();

            foreach (var subUnit in subordinateUnits)
            {


                subordinates.Add(new LoaiTBView
                {
                    Id = subUnit.Id,
                    TenLoai = subUnit.TenLoai,
                    //donvi = subUnit.donvi,
                    //soLuong = subUnit.soLuong,
                    TenNhomTB = _context.NhomTbs
                    .Where(lo => lo.Id == subUnit.IdNhomTb)
                    .Select(lo => lo.TenNhom)
                    .SingleOrDefault()
            });



            }


            return subordinates;
        }

        public void Update(LoaiTBView loai)
        {
            var tenLoai = loai.TenLoai;
            var donvi = loai.DonviTinh;
            var idNhomTB = _context.NhomTbs
                                .Where(lo => lo.TenNhom == loai.TenNhomTB)
                                .Select(lo => lo.Id)
                                .SingleOrDefault();
            var id = loai.Id;

            // Sử dụng tham số hóa để tránh lỗ hổng SQL Injection
            _context.Database.ExecuteSqlInterpolated(
                $"exec UpdateLoaiTB {id}, {tenLoai}, {idNhomTB}, {donvi}");
        }

    }
}
