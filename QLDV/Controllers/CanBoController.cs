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
    public class CanBoController : ControllerBase
    {
        private readonly CanBoInterface _CanBoRepository;

        public CanBoController(CanBoInterface CanBoRepository)
        {
            _CanBoRepository = CanBoRepository;

        }
        #region them
        [HttpPost]
        public IActionResult Add(CanBoView canBo)
        {
            try
            {
                return Ok(_CanBoRepository.Add(canBo));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion
        #region getall
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _CanBoRepository.GetAll(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion
        #region delete 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _CanBoRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion
        #region update 
        [HttpPut("{id}")]
        public IActionResult Update(int id, CanBoView loai)
        {
            if (id != loai.Id)
            {
                return BadRequest();
            }
            try
            {
                _CanBoRepository.Update(loai);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion
        #region search 
        [HttpGet("search/{search}")]
        public IActionResult Search(string search)
        {
            try
            {
                return Ok(_CanBoRepository.Search(search));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion
    }
}
