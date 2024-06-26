﻿using Sana.Backend.Domain.Common;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;


namespace Sana.Backend.Infrastructure.GraphQL.Queries
{
    public partial class Query
    {

        public async Task<IEnumerable<Product>> GetProducts([Service] IProductRepository repository)
            => await repository.ToList();
        public async Task<Product> GetProductById([Service] IProductRepository repository, Guid Id)
             => await repository.GetById(Id);

        public async Task<Paginate<Product>> PaginateProductBasic([Service] IProductRepository repository, int page, int lenght)
        => await repository.Paginate(page, lenght);

    }

}
