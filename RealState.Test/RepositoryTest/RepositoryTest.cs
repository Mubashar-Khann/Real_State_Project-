using Microsoft.EntityFrameworkCore;
using RealState.Core.DTOs;
using RealState.Repository;
using RealState.Repository.Entity;


namespace RealState.Test.RepositoryTest
{
    public class RepositoryTest
    {
        private InMemoryDb _context;
        private ParkingRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _context = GetInMemoryDbContext();
            _repository = new ParkingRepository(_context);
        }

        private InMemoryDb GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<InMemoryDb>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            return new InMemoryDb(options);
        }

        [Test]
        public async Task GetParkingAsync__Should_ReturnsAllValues()
        {
            // Arrange
            _context.ParkingTable.Add(new ParkingDTO { Id = 1, Parking_Name = "Value1", Capacity = 2 });
            _context.ParkingTable.Add(new ParkingDTO { Id = 2, Parking_Name = "Value2", Capacity = 3 });
            await _context.SaveChangesAsync();
            // Act
            var result = await _repository.GetAllParkingAsync();
            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(5));
        }

        [Test]
        public async Task AddParkingAsync__Should_StoreValuesInDb()
        {
            //Arrange
            var ParkingDto = new ParkingDTO { RoomId = 1007, Capacity = 4, Parking_Name = "abc" };

            //Act
            await _repository.AddParkingAsync(ParkingDto);

            //Assert
            await _context.SaveChangesAsync();
            var result = _context.ParkingTable.ToList();
            Assert.IsNotNull(result);

        }

        [Test]
        public async Task GetRoomAsync__WhenCalled_ReturnsAllValues()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new RoomRepository(context);

            // Act
            var result = await repository.GetAllRoomAsync();

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(),Is.EqualTo(9));
        }
        [Test]
        public async Task AddRoomAsync__Should_StoreValuesInDb()
        {
            var context = GetInMemoryDbContext();
            var repository = new RoomRepository(context);
            //Arrange
            var RooomDto = new RoomDTO { BuildingId = 4, No_Of_Floor = "5", Room_Name = "Fake_Testing" };
            await context.SaveChangesAsync();
            //Act
            await repository.AddRoomAsync(RooomDto);    

            //Assert
            await _context.SaveChangesAsync();
            var result = _context.ParkingTable.ToList();
            Assert.IsNotNull(result);

        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
    }
}
