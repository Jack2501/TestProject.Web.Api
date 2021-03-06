﻿using System.Collections.Generic;
using System.Linq;
using YevhenUshakov.TestProject.Data.Entities;
using YevhenUshakov.TestProject.Data.Enums;
using YevhenUshakov.TestProject.Data.Repositories.Abstract;

namespace YevhenUshakov.TestProject.Data.Repositories.Concrete
{
    public class StaticProductRepository: IProductRepository
    {
        public IQueryable<Product> Get()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "name1",
                    ProductType = ProductTypes.ProductType1,
                    Price = 10,
                    Returns = 0.1m
                },
                new Product
                {
                    Name = "name2",
                    ProductType = ProductTypes.ProductType2,
                    Price = 20,
                    Returns = 0.2m
                },
                new Product
                {
                    Name = "name3",
                    ProductType = ProductTypes.ProductType3,
                    Price = 30,
                    Returns = 0.3m
                },
                new Product
                {
                    Name = "name4",
                    ProductType = ProductTypes.ProductType4,
                    Price = 40,
                    Returns = 0.4m
                },
                new Product
                {
                    Name = "name5",
                    ProductType = ProductTypes.ProductType5,
                    Price = 50,
                    Returns = 0.5m
                },
                new Product
                {
                    Name = "name6",
                    ProductType = ProductTypes.ProductType6,
                    Price = 60,
                    Returns = 0.6m
                },
                new Product
                {
                    Name = "name7",
                    ProductType = ProductTypes.ProductType7,
                    Price = 70,
                    Returns = 0.7m
                },
                new Product
                {
                    Name = "name8",
                    ProductType = ProductTypes.ProductType8,
                    Price = 80,
                    Returns = 0.8m
                },
                new Product
                {
                    Name = "name9",
                    ProductType = ProductTypes.ProductType9,
                    Price = 90,
                    Returns = 0.9m
                },
                new Product
                {
                    Name = "name10",
                    ProductType = ProductTypes.ProductType10,
                    Price = 1000,
                    Returns = 0.95m
                }
            }.AsQueryable();
        }

        public DataContext Context => throw new System.NotImplementedException();

        public void Create(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public void DetachAll()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Product> GetReadonly()
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
