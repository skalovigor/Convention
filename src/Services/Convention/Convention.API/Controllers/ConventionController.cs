﻿using System.Threading.Tasks;
using Convention.BLL.Features.Convention.Services;
using Convention.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Convention.API.Controllers
{
    [ApiController]
    [Route("convention")]
   // [Authorize]
    public class ConventionController : ControllerBase
    {
        private readonly IConventionService _conventionService;

        public ConventionController(IConventionService conventionService)
        {
            _conventionService = conventionService;
        }
        
        [HttpPut("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]ConventionCreateRequest request)
        {
            await _conventionService.Create(request);
            return Ok();
        }
        
    }
}