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
    public class DiemController : ControllerBase
    {
        private readonly DiemInterface _DiemRepository;

        public DiemController(DiemInterface DiemRepository)
        {
            _DiemRepository = DiemRepository;

        }
        [HttpGet("{khhl}/{dv}")]
        public IActionResult GetById(int khhl,string dv )
        {
            try
            {
                return Ok(_DiemRepository.GetAll(khhl,dv));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        public IActionResult Update( DiemView loai)
        {
          
            try
            {
                _DiemRepository.Update(loai);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
