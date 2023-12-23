using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDV.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TKController : ControllerBase
    {
        private readonly TKInterface _TKRepository;

        public TKController(TKInterface TKRepository)
        {
            _TKRepository = TKRepository;
        }

        [HttpGet("{idkh}/{iddv}")]
        public IActionResult GetAll(int idkh, int iddv)
        {
            try
            {
                return Ok(_TKRepository.ThongKeDiem(idkh,iddv));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
