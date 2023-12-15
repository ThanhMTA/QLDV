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
    public class ThietBiRepository : ThietBiInterface
    {
        private readonly HeThongContext _context;

        public ThietBiRepository(HeThongContext context)
        {
            _context = context;
        }
        #region add
        public void Add(ThietBiView TB)
        {
            var tenTB = TB.TenTb;
            var soLuong = TB.soLuong;
            var idLoaiTB = _context.LoaiTbs
                     .Where(lo => lo.TenLoai == TB.LoaiTb)
                     .Select(lo => lo.Id)
                     .SingleOrDefault();
            var idDonVi = _context.DonVis
                     .Where(lo => lo.Ten == TB.DonVi)
                     .Select(lo => lo.Id)
                     .SingleOrDefault();

            _context.Database.ExecuteSqlInterpolated($"exec AddTB {tenTB},{ idLoaiTB},{idDonVi},{soLuong}");
        }
        #endregion
        #region delete 

        public void Delete(int id)
        {
            _context.Database.ExecuteSqlInterpolated($"exec DeleteTB {id}");
        }
        #endregion
        #region getall
        public List<ThietBiView> GetAll()
        {
            var subordinates = new List<ThietBiView>();

            string proc = "exec GetALLTB";
            var loais = _context.ThietBis.FromSqlRaw(proc).ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new ThietBiView
                {
                    Id = subUnit.Id,
                    TenTb= subUnit.TenTb,
                    donviTinh=subUnit.Donvi,
                    soLuong=subUnit.SoLuong,
                    LoaiTb = _context.LoaiTbs
                    .Where(lo => lo.Id == subUnit.IdLoaiTb)
                    .Select(lo => lo.TenLoai)
                    .SingleOrDefault(),
                     DonVi = _context.DonVis
                    .Where(lo => lo.Id == subUnit.IdDonVi)
                    .Select(lo => lo.Ten)
                    .SingleOrDefault()
                });



            }
            return subordinates;
        }
        #endregion
        #region Filter 
        public List<ThietBiView> Filter(int idLoaiTB, int idDV)
        {
            var subordinates = new List<ThietBiView>();

            
            var loais = _context.ThietBis.FromSqlRaw(" FilterTB {0}, {1}", idLoaiTB,idDV).ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new ThietBiView
                {
                    Id = subUnit.Id,
                    TenTb = subUnit.TenTb,
                    donviTinh = subUnit.Donvi,
                    soLuong = subUnit.SoLuong,
                    LoaiTb = _context.LoaiTbs
                    .Where(lo => lo.Id == subUnit.IdLoaiTb)
                    .Select(lo => lo.TenLoai)
                    .SingleOrDefault(),
                    DonVi = _context.DonVis
                    .Where(lo => lo.Id == subUnit.IdDonVi)
                    .Select(lo => lo.Ten)
                    .SingleOrDefault()
                });



            }
            return subordinates;
        }
        #endregion
        #region search 
        public List<ThietBiView> Search(string search)
        {
            var subordinates = new List<ThietBiView>();

            // Lấy đơn vị dựa trên ID



            var subordinateUnits = _context.ThietBis.FromSqlRaw("SearchTB {0}", search).ToList();

            foreach (var subUnit in subordinateUnits)
            {


                subordinates.Add(new ThietBiView
                {
                    Id = subUnit.Id,
                    TenTb = subUnit.TenTb,
                    donviTinh = subUnit.Donvi,
                    soLuong = subUnit.SoLuong,
                    LoaiTb = _context.LoaiTbs
                    .Where(lo => lo.Id == subUnit.IdLoaiTb)
                    .Select(lo => lo.TenLoai)
                    .SingleOrDefault(),
                    DonVi = _context.DonVis
                    .Where(lo => lo.Id == subUnit.IdDonVi)
                    .Select(lo => lo.Ten)
                    .SingleOrDefault()
                });



            }


            return subordinates;
        }
        #endregion
        #region Update 
        public void Update(ThietBiView TB)
        {
            var tenTB = TB.TenTb;
            var soLuong = TB.soLuong;
            var idLoaiTB = _context.LoaiTbs
                     .Where(lo => lo.TenLoai == TB.LoaiTb)
                     .Select(lo => lo.Id)
                     .SingleOrDefault();
            var idDonVi = _context.DonVis
                     .Where(lo => lo.Ten == TB.DonVi)
                     .Select(lo => lo.Id)
                     .SingleOrDefault();
            var id = TB.Id;

            // Sử dụng tham số hóa để tránh lỗ hổng SQL Injection
            _context.Database.ExecuteSqlInterpolated(
                $"exec UpdateTB {id}, {tenTB}, {idLoaiTB}, {idDonVi}, {soLuong}");
        }
        #endregion

    }
}
