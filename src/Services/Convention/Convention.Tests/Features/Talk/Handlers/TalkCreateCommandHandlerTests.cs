using System;
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
    public class TalkCreateCommandHandlerTests
    {
        [Theory]
        [AutoMoqData]
        internal async Task PropertiesFilledInvoked(TalkCreateCommand command,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            TalkCreateCommandHandler handler)
        {
            //run
            await handler.Handle(command, CancellationToken.None);

            //check
            mockUnitOfWork.Verify(m => m.TalkRepo.Add(It.Is<Domain.Models.Talk>(
                mo=> mo.Id != Guid.Empty
                && mo.Name == command.Name
                && mo.Description  == command.Description 
                && mo.Date == command.Date
                && mo.StartTime == command.StartTime
                && mo.EndTime == command.EndTime
                && mo.AmountOfSeats == command.AmountOfSeats
                && mo.SpeakerId == command.SpeakerId
                && mo.ConventionId == command.ConventionId)), Times.Once);
        }
        
        [Theory]
        [AutoMoqData]
        internal async Task SubmitChangesInvoked(TalkCreateCommand command,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            TalkCreateCommandHandler handler)
        {
            //run
            await handler.Handle(command, CancellationToken.None);

            //check
            mockUnitOfWork.Verify(m => m.SubmitChanges(), Times.Once);
        }
    }
}