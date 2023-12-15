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
    public class ThietBiController : ControllerBase
    {
        private readonly ThietBiInterface _ThietBiRepository;

        public ThietBiController(ThietBiInterface ThietBiRepository)
        {
            _ThietBiRepository = ThietBiRepository;

        }
        [HttpPost]
        public IActionResult Add(ThietBiView loai)
        {
            try
            {
                _ThietBiRepository.Add(loai);
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
                return Ok(_ThietBiRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, ThietBiView loai)
        {
            if (id != loai.Id)
            {
                return BadRequest();
            }
            try
            {
                _ThietBiRepository.Update(loai);
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
                _ThietBiRepository.Delete(id);
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
                return Ok(_ThietBiRepository.Search(search));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("Filter/{idLoaiTB}/{idDV}")]
        public IActionResult Filter(int idLoaiTB, int idDV)
        {
            try
            {
                return Ok(_ThietBiRepository.Filter(idLoaiTB,idDV));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
