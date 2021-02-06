﻿using System.Collections.Generic;
using RepositoryPattern.WithRepository.Domain;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.DataAccess.InMemory
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(List<Product> collection)
            : base(collection)
        {
        }

        public Product Get(int id)
        {
            return Collection.Find(x => x.Id == id);
        }

        public void Remove(int id)
        {
            Collection.RemoveAll(x => x.Id == id);
        }
    }
}