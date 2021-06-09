using System;
using System.Linq;
using System.Threading;
using AutoFixture;
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
    public class TalkApproveCommandValidatorTests
    {
        [Theory]
        [AutoMoqData]
        public void CommandHasValidateInterface(TalkApproveCommand command)
        {
            Assert.IsAssignableFrom<IValidateRequest>(command);
        }
        
        [Theory]
        [AutoMoqData]
        public void EmptyTalkId_NotValid(TalkApproveCommandValidator validator)
        {
            //prepare
            var command = TalkApproveCommand.Of(Guid.Empty);
            
            //run
            var actualResult = validator.Validate(command);
            
            //check
            Assert.False(actualResult.IsValid);
            Assert.Equal(actualResult.Errors.Count, 1);
            Assert.Equal(actualResult.Errors.First().ErrorMessage, "'Talk Id' must not be empty.");
        }
        
        [Theory]
        [AutoMoqData]
        public void TalkDoesNotExist_NotValid(TalkApproveCommand command,
            [Frozen]Mock<IMediator> mockMediator,
            TalkApproveCommandValidator validator)
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
        public void TalkAlreadyApproved_NotValid(TalkApproveCommand command,
            [Frozen]Mock<IMediator> mockMediator,
            TalkApproveCommandValidator validator)
        {
            //prepare
            var talkGetByIdQuery = TalkGetByIdQuery.Of(command.TalkId);
            mockMediator.Setup(m => m.Send(talkGetByIdQuery, CancellationToken.None))
                .ReturnsAsync(() => new Domain.Models.Talk{ Id = command.TalkId, Status = TalkStatus.Approved});
            
            //run
            var actualResult = validator.Validate(command);
            
            //check
            Assert.False(actualResult.IsValid);
            Assert.Contains(actualResult.Errors, 
                m => m.ErrorCode == "Talk already approved");
            //check
            Assert.False(actualResult.IsValid);
            Assert.DoesNotContain(actualResult.Errors, 
                m => m.ErrorCode == "Talk does not exist");
        }
        
        [Theory]
        [AutoMoqData]
        public void Talk_Valid(TalkApproveCommand command,
            [Frozen]Mock<IMediator> mockMediator,
            TalkApproveCommandValidator validator)
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