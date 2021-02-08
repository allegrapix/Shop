﻿using System.Collections.Generic;
using System.Linq;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.InMemory
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository()
            : base(InMemoryDatabase.Products)
        {
        }

        protected override int GetIdFor(Product entity)
        {
            return entity.Id;
        }

        public IEnumerable<ProductWithReservations> GetAvailable()
        {
            return Collection
                .Where(x => x.Quantity > 0)
                .Select(x => new ProductWithReservations
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    ReservationCount = InMemoryDatabase.Sales.Count(z => z.Product == x && z.State != SaleState.Done && z.State != SaleState.Canceled)
                });
        }
    }
}