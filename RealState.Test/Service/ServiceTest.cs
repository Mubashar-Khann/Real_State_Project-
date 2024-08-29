using Moq;
using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Service;

namespace RealState.Test.Service
{
    [TestFixture]
    public class Society_Uni_Test
    {
        private Mock<ISocietyRepository> mockRepo;
        private SocietyService service;

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<ISocietyRepository>();
            service = new SocietyService(mockRepo.Object);
        }

        [Test]
        public async Task AddSocietyAsync__shouldAdd_SendSocietyToRepo()
        {
            // Arrange
            var soc = new SocietyDTO
            {
                Id = 1,
                Society_Name = "Test",
                Society_Description = "Test",
                Society_Location = "Test",
            };

            // Act
            await service.AddSocietyAsync(soc);

            // Assert
            mockRepo.Verify(s => s.AddSocietyAsync(It.Is<SocietyDTO>(s =>
                s.Id == 1 &&
                s.Society_Name == "Test" &&
                s.Society_Description == "Test" &&
                s.Society_Location == "Test")), Times.Once());
        }
        [Test]
        public async Task RemoveSociety__WhenProvideValues_ValuesUpdated()
        {
            var societymoq = new SocietyDTO { Id = 3, Society_Name = "Test3", Society_Description = "Test3", Society_Location = "Test4" };
            await service.UpdateSocietyAsync(societymoq);

            mockRepo.Verify(s => s.UpdateSocietyAsync(It.Is<SocietyDTO>(s => s.Id == 3)), Times.Once());
        }

        [Test]
        public async Task RemoveSociety__WhenCalled_SpecificObjectRemove()
        {

            var removeid = 1;
            await service.RemoveSocietyAsync(removeid);
            mockRepo.Verify(s => s.RemoveSocietyAsync(It.Is<int>(id => id == removeid)), Times.Once());

        }



    }
}
