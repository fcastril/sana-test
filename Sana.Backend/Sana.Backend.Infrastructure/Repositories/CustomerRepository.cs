﻿using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;
using Sana.Backend.Domain.Port.Base;
using Sana.Backend.Infrastructure.Repositories.Base;

namespace Sana.Backend.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, IRepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IMainContext mainContext) : base(mainContext)
        {

        }
    }
}