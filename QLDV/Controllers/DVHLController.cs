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
    public class DVHLController : ControllerBase
    {
        private readonly DVHLInterface _DVHLRepository;

        public DVHLController(DVHLInterface DVHLRepository)
        {
            _DVHLRepository = DVHLRepository;

        }
        [HttpPost]
        public IActionResult Add(DVHLView loai)
        {
            try
            {
                _DVHLRepository.Add(loai);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{khhl}")]
        public IActionResult GetAll(int khhl)
        {
            try
            {
                return Ok(_DVHLRepository.GetAll(khhl));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{khhl}/{dv}")]
        public IActionResult Delete(int khhl,string dv)
        {
            try
            {
                _DVHLRepository.Delete(khhl,dv);
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
                return Ok(_DVHLRepository.Search(search, idDV.Value));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("Filter/{idDV}")]
        public IActionResult Filter(string idDV)
        {
            try
            {
                return Ok(_DVHLRepository.Filter(idDV));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
