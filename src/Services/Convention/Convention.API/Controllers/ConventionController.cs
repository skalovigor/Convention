using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Convention.API.Attributes;
using Convention.BLL.Features.Convention.Services;
using Convention.BLL.Features.Services;
using Convention.Contracts.Models;
using Convention.Contracts.Models.Participant;
using Convention.Domain.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Convention.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("convention")]
    public class ConventionController : ControllerBase
    {
        private readonly IConventionService _conventionService;
        private readonly IParticipantService _participantService;

        public ConventionController(IConventionService conventionService,
            IParticipantService participantService)
        {
            _conventionService = conventionService;
            _participantService = participantService;
        }
        
        /// <summary>
        /// Create new convention. Could be performed only by administrator
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AuthorizeRole(RoleType.Admin)]
        [HttpPut]
        [ProducesResponseType(typeof(Guid),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]ConventionCreateRequest request)
        {
            var id = await _conventionService.Create(request);
            return Ok(id);
        }
        
        /// <summary>
        /// Retrieve a list of all active/future conventions
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("active")]
        [ProducesResponseType(typeof(List<ConventionResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> List(/*TODO: paging*/)
        {
            var list = await _conventionService.GetActualList();
            return Ok(list);
        }

        /// <summary>
        /// Subscribe participant for a specific convention
        /// </summary>
        /// <returns></returns>
        [HttpPut("{conventionId}/participate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Participate([FromRoute] Guid conventionId, 
            [FromBody] ParticipantCreateRequest request)
        {
            await _participantService.ParticipateConvention(conventionId, request);
            return Ok();
        }
    }
}