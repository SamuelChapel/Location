using Location.Business.Contracts.Exceptions;
using Location.Business.Contracts.Services;
using Location.Repository.Contracts;

namespace Location.Business;

public class LocationService(ILocationRepository locationRepository, IClientService clientService) : ILocationService
{
	private readonly ILocationRepository _locationRepository = locationRepository;
	private readonly IClientService _clientService = clientService;

	public async Task<Entities.Location> GetById(int id)
	{
		return await _locationRepository.GetById(id) ?? throw new InvalidLocationIdException(id);
	}

	public async Task<IEnumerable<Entities.Location>> GetByClientId(int id)
	{
		_ = _clientService.GetById(id);

		return await _locationRepository.GetByClientId(id);
	}

	public async Task<IEnumerable<Entities.Location>> GetAll()
	{
		return await _locationRepository.GetAll();
	}

	public async Task<int> Create(Entities.Location location)
	{
		if (location.Date_Debut < DateTime.Today || location.Date_Debut > location.Date_Fin)
			throw new InvalidDateLocationException();

		return await _locationRepository.Create(location);
	}

	public async Task<int> Update(Entities.Location location)
	{
		if (location.Date_Debut < DateTime.Today || location.Date_Debut > location.Date_Fin)
			throw new InvalidDateLocationException();

		_ = GetById(location.Id);

		return await _locationRepository.Update(location);
	}

	public async Task<int> Delete(int id)
	{
		return await _locationRepository.Delete(id);
	}
}
