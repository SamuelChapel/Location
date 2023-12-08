using Location.Business;
using Location.Business.Contracts;
using Location.Controllers;
using Location.Repository.Contracts.Repositories;
using Location.Repository.Repositories;
using Location.Repository.Services;
using System.Data.SqlClient;
using Unity;

namespace Location.ViewConsole.Extensions;

public static class ServiceCollection
{
    public static IUnityContainer AddServices(this IUnityContainer container)
    {
        container.RegisterType<ClientController>();

        container.RegisterType<IClientService, ClientService>();

        container.RegisterType<IClientRepository, ClientRepositoryADO>();
        container.RegisterType<ISqlCommandHandler<SqlCommand, int>, SqlCommandNonQueryHandler>();
        container.RegisterType<ISqlCommandHandler<SqlCommand, SqlDataReader>, SqlCommandHandler>();
        return container;
    }
}
