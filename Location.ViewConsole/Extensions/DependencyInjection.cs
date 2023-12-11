using Location.Business;
using Location.Business.Contracts.Services;
using Location.Controllers;
using Location.Repository.Contracts;
using Location.Repository.Database.Context;
using Location.Repository.Repositories;
using Unity;

namespace Location.ViewConsole.Extensions;

public static class DependencyInjection
{
    public static IUnityContainer AddServices(this IUnityContainer container)
    {
        container.RegisterType<LocationConsole>();
        container.RegisterType<ClientConsole>();

        container.RegisterType<ClientController>();
        container.RegisterType<LocationController>();

        container.RegisterType<IClientService, ClientService>();
        container.RegisterType<ILocationService, LocationService>();

        //container.RegisterType<IClientRepository, ClientRepositoryADO>();
        //container.RegisterType<ILocationRepository, LocationRepositoryADO>();
        container.RegisterType<IClientRepository, ClientRepositoryEF>();
        container.RegisterType<ILocationRepository, LocationRepositoryEF>();
        container.RegisterType<LocationContext>();

        return container;
    }
}
