using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Convention.API.Security;
using Convention.BLL.Features.Convention.Commands;
using Convention.BLL.Features.Convention.Query;
using Convention.BLL.Features.Identity.Services;
using Convention.BLL.Features.Participant.Commands;
using Convention.BLL.Features.Speaker.Queries;
using Convention.BLL.Features.Talk.Commands;
using Convention.BLL.Features.Talk.Queries;
using Convention.Contracts.Models.Convention;
using Convention.Contracts.Models.Participant;
using Convention.Contracts.Models.Talk;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Convention.API.Controllers
{
    /// <summary>
    /// Convention Controller
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("convention")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ConventionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IIdentityContext _identityContext;

        /// <summary>
        /// Convention features
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        /// <param name="identityContext"></param>
        public ConventionController(IMediator mediator,
            IMapper mapper,
            IIdentityContext identityContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _identityContext = identityContext;
        }
        
        /// <summary>
        /// Create new convention. Could be performed only by administrator
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Policies.ConventionManager)]
        [HttpPut]
        [ProducesResponseType(typeof(Guid),StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody]ConventionCreateRequest request)
        {
            var id= await _mediator.Send(_mapper.Map<ConventionCreateCommand>(request));
            return Ok(id);
        }
        
        /// <summary>
        /// Retrieve a list of all active/future conventions
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("list")]
        [ProducesResponseType(typeof(List<ConventionResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> List(/*TODO: paging, sorting, filters etc.*/)
        {
            var list= await _mediator.Send(ConventionGetActualQuery.Of());
            var result = _mapper.Map<List<ConventionResponse>>(list);
            return Ok(result);
        }
        
        /// <summary>
        /// Retrieve convention by id
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{conventionId}")]
        [ProducesResponseType(typeof(List<ConventionResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> ById([FromRoute] Guid conventionId)
        {
            var convention= await _mediator.Send(ConventionGetByIdQuery.Of(conventionId));
            var result = _mapper.Map<ConventionResponse>(convention);
            return Ok(result);
        }

        /// <summary>
        /// Subscribe user for a specific convention
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{conventionId}/participate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Participate([FromRoute] Guid conventionId, 
            [FromBody] ParticipantCreateRequest request)
        {
            var command = _mapper.Map<ParticipantCreateCommand>(request);
            await _mediator.Send(command with
            {
                ConventionId = conventionId,
                UserId = _identityContext.User.Id
            });
            return Ok();
        }
        
        /// <summary>
        /// Retrieve all approved talks for convention 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{conventionId}/talks")]
        [ProducesResponseType(typeof(List<TalkResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> Talks([FromRoute] Guid conventionId)
        {
            var talks = await _mediator.Send(TalksGetApprovedByConventionIdQuery.Of(conventionId));
            return Ok(_mapper.Map<List<TalkResponse>>(talks));
        }
        
        /// <summary>
        /// create new talks for specific convention
        /// </summary>
        /// <param name="conventionId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Policies.TalkCreator)]
        [HttpPut("{conventionId}/talk")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> TalkCreate([FromRoute] Guid conventionId, [FromBody] TalkCreateRequest request)
        {
            var speaker = await _mediator.Send(SpeakerGetByUserIdQuery.Of(_identityContext.User.Id));
            await _mediator.Send(_mapper.Map<TalkCreateCommand>(request)
                with
                {
                    ConventionId = conventionId, SpeakerId = speaker.Id
                });
            
            return Ok();
        }
        
        /// <summary>
        /// Subscribe user for a specific talkT
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{conventionId}/talk/{talkId}/participate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Participate([FromRoute] Guid conventionId, [FromRoute] Guid talkId)
        {
            return Ok();
        }
        
        /// <summary>
        /// Retrieve all speakers for convention 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{conventionId}/speakers")]
        [ProducesResponseType(typeof(List<SpeakerResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> Speakers([FromRoute] Guid conventionId)
        {
            var talks = await _mediator.Send(SpeakersGetByConventionIdQuery.Of(conventionId));
            return Ok(_mapper.Map<List<SpeakerResponse>>(talks));
        }
    }
}