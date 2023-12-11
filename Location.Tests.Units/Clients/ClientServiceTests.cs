global using Xunit;
using Location.Business;
using Location.Business.Contracts.Exceptions;
using Location.Entities.Entities;
using Location.Repository.Contracts;
using Location.Tests.Common.Builders;
using Moq;

namespace Location.Tests.Units.Clients;

public class ClientServiceTests
{
	public readonly Mock<IClientRepository> _clientRepositoryMock = new();

	[Theory]
	[InlineData(1)]
	public async Task GetById_WhenValidId_ShouldReturnClient(int id)
	{
		// Arrange
		var client = ClientBuilder.AClient.WithId(id).Build();
		_clientRepositoryMock.Setup(cr => cr.GetById(id)).ReturnsAsync(client);
		var clientService = new ClientService(_clientRepositoryMock.Object);

		// Act
		var result = await clientService.GetById(id);

		// Assert
		Assert.Equal(id, result.Id);
	}

	[Fact]
	public async Task GetById_WhenInvalidId_ShouldThrowInvalidClientIdException()
	{
		// Arrange
		var client = ClientBuilder.AClient.Build();
		_clientRepositoryMock.Setup(cr => cr.GetById(client.Id)).ReturnsAsync((Client?)null);
		var clientService = new ClientService(_clientRepositoryMock.Object);

		// Act
		Task GetByIdAction() => clientService.GetById(client.Id);

		// Assert
		await Assert.ThrowsAsync<InvalidClientIdException>(GetByIdAction);
	}

	[Theory]
	[InlineData(0)]
	[InlineData(1)]
	[InlineData(5)]
	public async Task GetAll_ShouldReturnClients(int clientCount)
	{
		// Arrange
		_clientRepositoryMock
			.Setup(cr => cr.GetAll())
			.ReturnsAsync(Enumerable.Range(0, clientCount)
				.Select(i => ClientBuilder.AClient.WithId(i).Build()));
		var clientService = new ClientService(_clientRepositoryMock.Object);

		// Act
		var clients = (await clientService.GetAll()).ToList();

		// Assert
		Assert.Equal(clientCount, clients.Count);
		Assert.All(clients, c => Assert.True(typeof(Client).IsEquivalentTo(c.GetType())));
	}
}
