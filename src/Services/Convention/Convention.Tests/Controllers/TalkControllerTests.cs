using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Convention.API.Controllers;
using Convention.API.Security;
using Convention.BLL.Features.Talk.Commands;
using Convention.BLL.Tests.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Convention.BLL.Tests.Controllers
{
    public class TalkControllerTests 
    {
        [Theory]
        [AutoMoqData]
        internal async Task Approve_TalkApproveCommandExecuted([Frozen] Mock<IMediator> mockMediator,
            TalkController controller,
            Guid talkId)
        {
            //run
            await controller.Approve(talkId);

            //check
            mockMediator.Verify(m=> m.Send(It.Is<TalkApproveCommand>(c=> c.TalkId == talkId), 
                    CancellationToken.None), Times.Once);
        }
        
        [Theory]
        [AutoMoqData]
        internal async Task Approve_Ok(TalkController controller,
            Guid talkId)
        {
            //run
            var result = await controller.Approve(talkId);

            //check
            Assert.IsType<OkResult>(result);
        }
        
        [Theory]
        [AutoMoqData]
        internal async Task Approve_AuthorizeAttribute(TalkController controller)
        {
            //prepare
            var actualAttribute = controller.GetType().GetMethod("Approve")
                .GetCustomAttributes(typeof(AuthorizeAttribute),true);
            //run

            //check
            Assert.Equal(typeof(AuthorizeAttribute), actualAttribute[0].GetType());
            Assert.Equal(((AuthorizeAttribute)actualAttribute[0]).Policy, Policies.TalkManager);
        }
        
        [Theory]
        [AutoMoqData]
        internal async Task Remove_TalkRemoveCommandExecuted([Frozen] Mock<IMediator> mockMediator,
            TalkController controller,
            Guid talkId)
        {
            //run
            await controller.Remove(talkId);

            //check
            mockMediator.Verify(m=> m.Send(It.Is<TalkRemoveCommand>(c=> c.TalkId == talkId), 
                CancellationToken.None), Times.Once);
        }
        
        [Theory]
        [AutoMoqData]
        internal async Task Remove_Ok(TalkController controller,
            Guid talkId)
        {
            //run
            var result = await controller.Remove(talkId);

            //check
            Assert.IsType<OkResult>(result);
        }
        
        [Theory]
        [AutoMoqData]
        internal async Task Remove_AuthorizeAttribute(TalkController controller)
        {
            //prepare
            var actualAttribute = controller.GetType().GetMethod("Remove")
                .GetCustomAttributes(typeof(AuthorizeAttribute),true);
            //run

            //check
            Assert.Equal(typeof(AuthorizeAttribute), actualAttribute[0].GetType());
            Assert.Equal(((AuthorizeAttribute)actualAttribute[0]).Policy, Policies.TalkManager);
        }
    }
}