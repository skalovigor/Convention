using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Convention.BLL.Features.Talk.Commands;
using Convention.BLL.Features.Talk.Handlers;
using Convention.BLL.Tests.Attributes;
using Convention.DAL;
using Convention.Domain.Enums;
using Moq;
using Xunit;

namespace Convention.BLL.Tests.Features.Talk.Commands
{
    public class TalkApproveCommandHandlerTests
    {
        
        [Theory]
        [AutoMoqData]
        internal async Task StatusUpdated(TalkApproveCommand command,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            TalkApproveCommandHandler handler)
        {
            //prepare
            var talk = new Domain.Models.Talk {Id = command.TalkId, Status = TalkStatus.Pending};
            mockUnitOfWork.Setup(m => m.TalkRepo.GetAsync(command.TalkId))
                .ReturnsAsync(() => talk);
            //run
            await handler.Handle(command, CancellationToken.None);

            //check
            Assert.Equal(TalkStatus.Approved, talk.Status);
        }
        
        [Theory]
        [AutoMoqData]
        internal async Task UpdateRepoInvoked(TalkApproveCommand command,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            TalkApproveCommandHandler handler)
        {
            //prepare
            var talk = new Domain.Models.Talk {Id = command.TalkId, Status = TalkStatus.Pending};
            mockUnitOfWork.Setup(m => m.TalkRepo.GetAsync(command.TalkId))
                .ReturnsAsync(() => talk);
            //run
            await handler.Handle(command, CancellationToken.None);

            //check
            mockUnitOfWork.Verify(m => m.TalkRepo.Update(talk), Times.Once);
        }
        
        [Theory]
        [AutoMoqData]
        internal async Task SubmitChangesInvoked(TalkApproveCommand command,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            TalkApproveCommandHandler handler)
        {
            //prepare
            var talk = new Domain.Models.Talk {Id = command.TalkId, Status = TalkStatus.Pending};
            mockUnitOfWork.Setup(m => m.TalkRepo.GetAsync(command.TalkId))
                .ReturnsAsync(() => talk);
            //run
            await handler.Handle(command, CancellationToken.None);

            //check
            mockUnitOfWork.Verify(m => m.SubmitChanges(), Times.Once);
        }
    }
}