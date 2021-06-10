using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Convention.BLL.Features.Talk.Commands;
using Convention.BLL.Features.Talk.Handlers;
using Convention.BLL.Tests.Attributes;
using Convention.DAL;
using Moq;
using Xunit;

namespace Convention.BLL.Tests.Features.Talk.Commands
{
    public class TalkRemoveCommandHandlerTests
    {
        [Theory]
        [AutoMoqData]
        internal async Task RemoveInvoked(TalkRemoveCommand command,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            TalkRemoveCommandHandler handler)
        {
            //prepare
            var talk = new Domain.Models.Talk {Id = command.TalkId};
            mockUnitOfWork.Setup(m => m.TalkRepo.GetAsync(command.TalkId))
                .ReturnsAsync(() => talk);
            //run
            await handler.Handle(command, CancellationToken.None);

            //check
            mockUnitOfWork.Verify(m => m.TalkRepo.Remove(It.Is<Domain.Models.Talk>(
                mo=> mo.Id == talk.Id)), Times.Once);
        }
        
        [Theory]
        [AutoMoqData]
        internal async Task SubmitChangesInvoked(TalkRemoveCommand command,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            TalkRemoveCommandHandler handler)
        {
            //prepare
            var talk = new Domain.Models.Talk {Id = command.TalkId};
            mockUnitOfWork.Setup(m => m.TalkRepo.GetAsync(command.TalkId))
                .ReturnsAsync(() => talk);
            //run
            await handler.Handle(command, CancellationToken.None);

            //check
            mockUnitOfWork.Verify(m => m.SubmitChanges(), Times.Once);
        }
    }
}