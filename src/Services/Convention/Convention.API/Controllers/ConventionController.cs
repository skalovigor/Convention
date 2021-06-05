using System;
using System.Threading.Tasks;
using Convention.API.Attributes;
using Convention.BLL.Features.Convention.Services;
using Convention.Contracts.Models;
using Convention.Domain.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Convention.API.Controllers
{
    [ApiController]
    [Route("convention")]
    [Authorize]
    public class ConventionController : ControllerBase
    {
        private readonly IConventionService _conventionService;

        public ConventionController(IConventionService conventionService)
        {
            _conventionService = conventionService;
        }
        
        [AuthorizeRole(RoleType.Admin)]
        [HttpPut("create")]
        [ProducesResponseType(typeof(Guid),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]ConventionCreateRequest request)
        {
            var id = await _conventionService.Create(request);
            return Ok(id);
        }
    }
}