using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WLMT.Bungalows.Application.UseCases.Campaigns.Commands;
using WLMT.Bungalows.Domain.Entities;
using WLMT.Bungalows.Domain.Interfaces;

namespace WLMT.Bungalows.Tests.Handlers
{

    public class CreateCampaignCommandHandlerTests
    {

        [Fact]
        public async Task Handle_ValidCommand_ShouldReturnGuid()
        {
            // Arrange
            var mockRepo = new Mock<ICampaignRepository>();
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Campaign>(), default)).Returns(Task.CompletedTask);
            mockRepo.Setup(x => x.SaveChangesAsync(default)).Returns(Task.CompletedTask);

            var handler = new CreateCampaignCommandHandler(mockRepo.Object);
            var command = new CreateCampaignCommand("Campagne 1", "Paris", 1000);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            Assert.IsType<Guid>(result);
        }
    }
}
