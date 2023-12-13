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
    public class NhomTBController : ControllerBase
    {
        private readonly NhomTBInterface _NhomTBRepository;

        public NhomTBController(NhomTBInterface NhomTBRepository)
        {
            _NhomTBRepository = NhomTBRepository;

        }
        [HttpPost]
        public IActionResult Add(NhomTBView loai)
        {
            try
            {
                _NhomTBRepository.Add(loai);
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
                return Ok(_NhomTBRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, NhomTBView loai)
        {
            if (id != loai.Id)
            {
                return BadRequest();
            }
            try
            {
                _NhomTBRepository.Update(loai);
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
                _NhomTBRepository.Delete(id);
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
                return Ok(_NhomTBRepository.Search(search));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
