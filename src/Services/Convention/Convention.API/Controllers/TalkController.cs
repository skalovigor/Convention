using System;
using System.Threading.Tasks;
using Convention.BLL.Features.Convention.Services;
using Convention.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Convention.API.Controllers
{
    [ApiController]
    [Route("talk")]
    [Authorize]
    public class TalkController : ControllerBase
    {

        public TalkController(IConventionService conventionService)
        {
            
        }
        
        [HttpPut("create")]
        [ProducesResponseType(typeof(Guid),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]ConventionCreateRequest request)
        {
            
            return Ok();
        }
        
    }
}