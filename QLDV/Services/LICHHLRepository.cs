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
    public class LICHHLRepository : LICHHLInterface
    {
        private readonly HeThongContext _context;

        public LICHHLRepository(HeThongContext context)
        {
            _context = context;
        }
        #region add
        public void Add(LICHHLView TB)
        {
            var ngay = TB.Ngay;
            var batdau = TB.Tietbatdau;
            var ketthuc = TB.Tietketthuc;
            var idKHHL = TB.KHHL;

            _context.Database.ExecuteSqlInterpolated($"exec  AddLICHHL {ngay},{batdau},{ketthuc},{idKHHL}");
        }
        #endregion
        #region delete 

        public void Delete(int id)
        {
            _context.Database.ExecuteSqlInterpolated($"exec DeleteLICHHL {id}");
        }
        #endregion
        #region getall
        public List<LICHHLView> GetAll()
        {
            var subordinates = new List<LICHHLView>();

            string proc = "exec GetALLHV";
            var loais = _context.LichHls.FromSqlRaw(proc).ToList();

            //foreach (var subUnit in loais)
            //{


            //    subordinates.Add(new LICHHLView
            //    {
            //        Id = subUnit.Id,
            //        Ten = subUnit.Ten,
            //        Ngaysinh = subUnit.Ngaysinh,
            //        Quequan = subUnit.Quequan,
            //        CapBac = subUnit.CapBac,
            //        Sdt = subUnit.Sdt,
            //        Cccd = subUnit.Cccd,
            //        DonVi = _context.DonVis
            //        .Where(lo => lo.Id == subUnit.IdDonVi)
            //        .Select(lo => lo.Ten)
            //        .SingleOrDefault()
            //    });



            //}
            return subordinates;
        }
        #endregion
        #region Filter 
        public List<LICHHLView> Filter(int idDV)
        {
            var subordinates = new List<LICHHLView>();


            var loais = _context.LichHls.FromSqlRaw(" FilterLICHHL {0}", idDV).ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new LICHHLView
                {
                    Id=subUnit.Id,
                    Ngay=subUnit.Ngay,
                    Tietbatdau=subUnit.Tietbatdau,
                    Tietketthuc=subUnit.Tietketthuc,
                    Tongtiethoc=subUnit.Tongtiethoc,
                    KHHL = subUnit.IdKhhl
                   
                });



            }
            return subordinates;
        }
        #endregion
        #region search 
        public List<LICHHLView> Search(string search, int idDV)
        {
            var subordinates = new List<LICHHLView>();

            // Lấy đơn vị dựa trên ID



            var subordinateUnits = _context.LichHls.FromSqlRaw("SearchHV {0},{1}", search, idDV).ToList();

            foreach (var subUnit in subordinateUnits)
            {


                subordinates.Add(new LICHHLView
                {
                    Id = subUnit.Id,
                    Ngay = subUnit.Ngay,
                    Tietbatdau = subUnit.Tietbatdau,
                    Tietketthuc = subUnit.Tietketthuc,
                    Tongtiethoc = subUnit.Tongtiethoc,
                    KHHL = subUnit.IdKhhl
                });



            }


            return subordinates;
        }
        #endregion
        #region Update 
        public void Update(LICHHLView TB)
        {
            var id = TB.Id;
            var ngay = TB.Ngay;
            var batdau = TB.Tietbatdau;
            var ketthuc = TB.Tietketthuc;
            var idKHHL = TB.KHHL;

            _context.Database.ExecuteSqlInterpolated($"UpdateLICHHL {id},  {ngay},{batdau},{ketthuc},{idKHHL}");
        }
        #endregion

    }
}
