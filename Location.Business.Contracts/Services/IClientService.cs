﻿using Location.Business.Contracts.Services.Base;
using Location.Entities;

namespace Location.Business.Contracts.Services;

public interface IClientService : IGenericReadService<Client, int>, IGenericWriteService<Client, int>
{
}