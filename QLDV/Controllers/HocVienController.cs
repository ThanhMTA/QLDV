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
    public class HocVienController : ControllerBase
    {
        private readonly HocVienInterface _HocVienRepository;

        public HocVienController(HocVienInterface HocVienRepository)
        {
            _HocVienRepository = HocVienRepository;

        }
        [HttpPost]
        public IActionResult Add(HocVienView loai)
        {
            try
            {
                _HocVienRepository.Add(loai);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_HocVienRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, HocVienView loai)
        {
            if (id != loai.Id)
            {
                return BadRequest();
            }
            try
            {
                _HocVienRepository.Update(loai);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _HocVienRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("search/{search}/{idDV}")]
        public IActionResult Search(string search, int? idDV)
        {
            try
            {
                return Ok(_HocVienRepository.Search(search, idDV.Value));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("Filter/{idDV}")]
        public IActionResult Filter( int idDV)
        {
            try
            {
                return Ok(_HocVienRepository.Filter( idDV));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
