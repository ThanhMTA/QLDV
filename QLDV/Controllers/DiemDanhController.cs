using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDV.Interfaces;
using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemDanhController : ControllerBase
    {
        private readonly DiemDanhInterface _DiemDanhRepository;

        public DiemDanhController(DiemDanhInterface DiemDanhRepository)
        {
            _DiemDanhRepository = DiemDanhRepository;

        }
        [HttpGet("{khhl}/{dv}")]
        public IActionResult GetById(int khhl, string dv)
        {
            try
            {
                return Ok(_DiemDanhRepository.GetAll(khhl, dv));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{khhl}")]
        public IActionResult GetDV(int khhl)
        {
            try
            {
                return Ok(_DiemDanhRepository.GetDV(khhl));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        public IActionResult Update(DiemDanhView loai)
        {

            try
            {
                _DiemDanhRepository.Update(loai);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
