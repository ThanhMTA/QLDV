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
    public class LoaiTBController : ControllerBase
    {
        private readonly LoaiTBInterface _LoaiTBRepository;

        public LoaiTBController(LoaiTBInterface LoaiTBRepository)
        {
            _LoaiTBRepository = LoaiTBRepository;

        }
        [HttpPost]
        public IActionResult Add(LoaiTBView loai)
        {
            try
            {
                _LoaiTBRepository.Add(loai);
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
                return Ok(_LoaiTBRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, LoaiTBView loai)
        {
            if (id != loai.Id)
            {
                return BadRequest();
            }
            try
            {
                _LoaiTBRepository.Update(loai);
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
                _LoaiTBRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("search/{search}")]
        public IActionResult Search(string search)
        {
            try
            {
                return Ok(_LoaiTBRepository.Search(search));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
