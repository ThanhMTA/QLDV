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
    public class LoaiDonViController : ControllerBase
    {
        private readonly LoaiDonViInterface _LoaiDonViRepository;
       
        public LoaiDonViController(LoaiDonViInterface loaiDonViRepository)
        {
            _LoaiDonViRepository = loaiDonViRepository;
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            string proc = "exec GetAllLoaiDonVis";
            try
            {
                return Ok(_LoaiDonViRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _LoaiDonViRepository.GetByID(id);
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

        [HttpPut("{id}")]
        public IActionResult Update(int id, LoaiDonViView loai)
        {
            if (id != loai.Id)
            {
                return BadRequest();
            }
            try
            {
                _LoaiDonViRepository.Update(loai);
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
                _LoaiDonViRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Add(LoaiDonViView loai)
        {
            try
            {
                return Ok(_LoaiDonViRepository.Add(loai));
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
                return Ok(_LoaiDonViRepository.Search(search));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
