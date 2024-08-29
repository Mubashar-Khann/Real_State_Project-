
using Microsoft.EntityFrameworkCore;
using Moq;
using RealState.Core.DTOs;
using RealState.Repository;
using System;

namespace RealState.Test
{
    //[TestFixture]
    //public class RoomRepositoryTest
    //{
    //    private InMemoryDb GetInMemoryDbContext()
    //    {
    //        var options = new DbContextOptionsBuilder<InMemoryDb>()
    //            .UseInMemoryDatabase(databaseName: "TestDatabase")
    //            .Options;

    //        return new InMemoryDb(options);
    //    }

    //    [Test]
    //    public async Task GetValuesAsync__WhenCalled_ReturnsAllValues()
    //    {
    //        // Arrange
    //        var context = GetInMemoryDbContext();
    //        var repository = new RoomRepository(context);

    //        // Seed the in-memory database with test data
    //        context.RoomTable.Add(new RoomDTO { Id = 1, Room_Name = "Value1", No_Of_Floor = "Test" });
    //        context.RoomTable.Add(new RoomDTO { Id = 2, Room_Name = "Value2", No_Of_Floor = "Test" });
    //        await context.SaveChangesAsync();


    //        // Act
    //        var result = await repository.GetAllRoomAsync();

    //        // Assert
    //        Assert.NotNull(result);
    //        Assert.That(result.Count(), Is.EqualTo(1));


    //    }
    //}
}

