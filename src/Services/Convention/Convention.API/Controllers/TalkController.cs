using System;
using System.Threading.Tasks;
using AutoMapper;
using Convention.API.Attributes;
using Convention.API.Security;
using Convention.BLL.Features.Identity.Services;
using Convention.BLL.Features.Talk.Commands;
using Convention.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Convention.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("talk")]
    public class TalkController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IIdentityContext _identityContext;

        /// <summary>
        /// Talk features
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        /// <param name="identityContext"></param>
        public TalkController(IMediator mediator,
            IMapper mapper,
            IIdentityContext identityContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _identityContext = identityContext;
        }
        
        /// <summary>
        /// Approve pending talk
        /// </summary>
        /// <param name="talkId"></param>
        /// <returns></returns>
        [Authorize(Policies.TalkManager)]
        [HttpPatch("{talkId}/approve")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove([FromRoute] Guid talkId)
        {
            await _mediator.Send(TalkRemoveCommand.Of(talkId));
            return Ok();
        }
    }
}