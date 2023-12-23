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
    public class KHHLController : ControllerBase
    {
        private readonly KHHLInterface _KHHLRepository;

        public KHHLController(KHHLInterface KHHLRepository)
        {
            _KHHLRepository = KHHLRepository;

        }
        [HttpPost]
        public IActionResult Add(KHHLView loai)
        {
            try
            {
                _KHHLRepository.Add(loai);
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
                return Ok(_KHHLRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetID(int id)
        {
            try
            {
                return Ok(_KHHLRepository.GetID(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("Con/{id}")]
        public IActionResult GetCon(int id)
        {
            try
            {
                return Ok(_KHHLRepository.GetCon(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, KHHLView loai)
        {
            if (id != loai.Id)
            {
                return BadRequest();
            }
            try
            {
                _KHHLRepository.Update(loai);
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
                _KHHLRepository.Delete(id);
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
                return Ok(_KHHLRepository.Search(search, idDV.Value));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("Filter/{idDV}")]
        public IActionResult Filter(int idDV)
        {
            try
            {
                return Ok(_KHHLRepository.Filter(idDV));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
