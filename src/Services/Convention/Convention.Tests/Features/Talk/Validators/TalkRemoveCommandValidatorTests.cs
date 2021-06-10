using System;
using System.Linq;
using System.Threading;
using AutoFixture.Xunit2;
using Convention.BLL.Features.Talk.Commands;
using Convention.BLL.Features.Talk.Queries;
using Convention.BLL.Features.Talk.Validators;
using Convention.BLL.Infrastructure.Behaviours;
using Convention.BLL.Tests.Attributes;
using Convention.Domain.Enums;
using MediatR;
using Moq;
using Xunit;

namespace Convention.BLL.Tests.Features.Talk.Validators
{
    public class TalkRemoveCommandValidatorTests
    {
        [Theory]
        [AutoMoqData]
        public void CommandHasValidateInterface(TalkRemoveCommand command)
        {
            Assert.IsAssignableFrom<IValidateRequest>(command);
        }
        
        [Theory]
        [AutoMoqData]
        public void EmptyTalkId_NotValid(TalkRemoveCommandValidator validator)
        {
            //prepare
            var command = TalkRemoveCommand.Of(Guid.Empty);
            
            //run
            var actualResult = validator.Validate(command);
            
            //check
            Assert.False(actualResult.IsValid);
            Assert.Equal(1, actualResult.Errors.Count);
            Assert.Equal("'Talk Id' must not be empty.", actualResult.Errors.First().ErrorMessage);
        }
        
        [Theory]
        [AutoMoqData]
        public void TalkDoesNotExist_NotValid(TalkRemoveCommand command,
            [Frozen]Mock<IMediator> mockMediator,
            TalkRemoveCommandValidator validator)
        {
            //prepare
            var talkGetByIdQuery = TalkGetByIdQuery.Of(command.TalkId);
            mockMediator.Setup(m => m.Send(talkGetByIdQuery, CancellationToken.None))
                .ReturnsAsync(() => null);
            
            //run
            var actualResult = validator.Validate(command);
            
            //check
            Assert.False(actualResult.IsValid);
            Assert.Contains(actualResult.Errors, 
                m => m.ErrorCode == "Talk does not exist");
        }
        
        [Theory]
        [AutoMoqData]
        public void Talk_Valid(TalkRemoveCommand command,
            [Frozen]Mock<IMediator> mockMediator,
            TalkRemoveCommandValidator validator)
        {
            //prepare
            var talkGetByIdQuery = TalkGetByIdQuery.Of(command.TalkId);
            mockMediator.Setup(m => m.Send(talkGetByIdQuery, CancellationToken.None))
                .ReturnsAsync(() => new Domain.Models.Talk{ Id = command.TalkId, Status = TalkStatus.Pending});
            
            //run
            var actualResult = validator.Validate(command);
            
            //check
            Assert.True(actualResult.IsValid);
        }
    }
}