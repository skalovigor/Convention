using System;
using System.Threading.Tasks;
using AutoMapper;
using Convention.API.Security;
using Convention.BLL.Features.Identity.Services;
using Convention.BLL.Features.Talk.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Convention.API.Controllers
{
    /// <summary>
    /// Talk Controller
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("talk")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class TalkController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Talk features
        /// </summary>
        /// <param name="mediator"></param>
        public TalkController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Approve pending talk
        /// </summary>
        /// <param name="talkId"></param>
        /// <returns></returns>
        [Authorize(Policies.TalkManager)]
        [HttpPatch("{talkId}/approve")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Approve([FromRoute] Guid talkId)
        {
            await _mediator.Send(TalkApproveCommand.Of(talkId));
            return Ok();
        }
        
        /// <summary>
        /// Remove talk
        /// </summary>
        /// <param name="talkId"></param>
        /// <returns></returns>
        [Authorize(Policies.TalkManager)]
        [HttpDelete("{talkId}/remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Remove([FromRoute] Guid talkId)
        {
            await _mediator.Send(TalkRemoveCommand.Of(talkId));
            return Ok();
        }
    }
}