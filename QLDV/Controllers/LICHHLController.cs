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
    public class LICHHLController : ControllerBase
    {
        private readonly LICHHLInterface _LICHHLRepository;

        public LICHHLController(LICHHLInterface LICHHLRepository)
        {
            _LICHHLRepository = LICHHLRepository;

        }
        [HttpPost]
        public IActionResult Add(LICHHLView loai)
        {
            try
            {
                _LICHHLRepository.Add(loai);
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
                return Ok(_LICHHLRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, LICHHLView loai)
        {
            if (id != loai.Id)
            {
                return BadRequest();
            }
            try
            {
                _LICHHLRepository.Update(loai);
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
                _LICHHLRepository.Delete(id);
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
                return Ok(_LICHHLRepository.Search(search, idDV.Value));
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
                return Ok(_LICHHLRepository.Filter(idDV));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
