using Location.Business;
using Location.Business.Contracts.Exceptions;
using Location.Business.Contracts.Services;
using Location.Repository.Contracts;
using Location.Tests.Common.Builders;
using Moq;

namespace Location.Tests.Units.Locations;

public class LocationServiceTests
{
	public readonly Mock<ILocationRepository> _locationRepositoryMock = new();
	public readonly Mock<IClientService> _clientServiceMock = new();

	[Fact]
	public async Task Create_WhenStartDateBeforeEndDate_ShouldThrowInvalidDateLocationException()
	{
		// Arrange
		var location = LocationBuilder.ALocation
			.WithStartDate(DateTime.MaxValue)
			.WithEndDate(DateTime.MaxValue.AddDays(-1))
			.Build();

		// Act
		async Task CreateAction() => await new LocationService(_locationRepositoryMock.Object, _clientServiceMock.Object).Create(location);

		// Assert
		await Assert.ThrowsAsync<InvalidDateLocationException>(CreateAction);
	}
}
