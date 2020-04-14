using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using Models;
using PerfumeryNgBackend.Filters;
using Services;

namespace PerfumeryNgBackend.Controllers
{
    //[ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class PerfumeController : ControllerBase
    {
        //private readonly ILogger<PerfumeController> _logger;
         private  IPerfumeService _perfumeService;
        private readonly string GetIPAddress;
        // private readonly string currentUser;
        public PerfumeController(IPerfumeService perfumeService)
        {
            _perfumeService = perfumeService;
           // logger = _logger;
           // currentUser = _userIdentity.GetLoggedInUser();
        }


        [HttpGet]
        [Route("GetAllPerfumes")]
        public async Task<IActionResult> GetPerfumes()
        {
            try
            {
                var res = await _perfumeService.GetAllPerfumes();
                return Ok(res);
            }
            catch(Exception ex)
            {
               string exception=ex.Message;
            }
            return Ok();
            
        }

        [HttpGet]
        [Route("GetPerfumesByCategories")]
        public async Task<IActionResult> GetPerfumeByCategory([FromBody]string CategoryName)
        {
            return Ok(await _perfumeService.SearchPerfumeByCategory(CategoryName));
        }

        [HttpGet]
        [Route("SearchPerfumes")]
        public async Task<IActionResult> SearchPerfumes([FromBody]string SearchParameter)
        {
            return Ok(await _perfumeService.SearchPerfumeByName(SearchParameter));
        }

        [HttpGet]
        [Route("GetPerfumesByGender")]
        public async Task<IActionResult>  GetPerumesByGender([FromBody]string gender)
        {
            return Ok(await _perfumeService.GetPerfumeByGender(gender));
        }
    }
}
