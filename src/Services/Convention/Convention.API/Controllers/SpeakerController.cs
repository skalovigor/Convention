using System;
using System.Threading.Tasks;
using AutoMapper;
using Convention.API.Security;
using Convention.BLL.Features.Identity.Services;
using Convention.BLL.Features.Speaker.Commands;
using Convention.Contracts.Models.Speaker;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Convention.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("talk")]
    public class SpeakerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IIdentityContext _identityContext;

        /// <summary>
        /// Speaker features
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        /// <param name="identityContext"></param>
        public SpeakerController(IMediator mediator,
            IMapper mapper,
            IIdentityContext identityContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _identityContext = identityContext;
        }

        /// <summary>
        /// Approve pending speaker
        /// </summary>
        /// <param name="speakerId"></param>
        /// <returns></returns>
        [Authorize(Policies.SpeakerManager)]
        [HttpPatch("{speakerId}/approve")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Approve([FromRoute] Guid speakerId)
        {
            await _mediator.Send(SpeakerApproveCommand.Of(speakerId));
            return Ok();
        }

        /// <summary>
        /// Remove speaker
        /// </summary>
        /// <param name="speakerId"></param>
        /// <returns></returns>
        [Authorize(Policies.SpeakerManager)]
        [HttpDelete("{speakerId}/create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove([FromRoute] Guid speakerId)
        {
            await _mediator.Send(SpeakerRemoveCommand.Of(speakerId));
            return Ok();
        }

        /// <summary>
        /// Speaker sign up
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove([FromBody] SpeakerCreateRequest request)
        {
            var command = _mapper.Map<SpeakerCreateCommand>(request);
            await _mediator.Send(command with
            {
                UserId = _identityContext.User.Id
            });
            return Ok();
        }
    }
}