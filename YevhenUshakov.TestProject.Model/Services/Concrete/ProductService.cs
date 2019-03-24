using System;
using System.Collections.Generic;
using System.Linq;
using YevhenUshakov.TestProject.Data.Entities;
using YevhenUshakov.TestProject.Data.Repositories.Abstract;
using YevhenUshakov.TestProject.Model.Exceptions;
using YevhenUshakov.TestProject.Model.Services.Abstract;

namespace YevhenUshakov.TestProject.Model.Services.Concrete
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
           _productRepository = productRepository;
        }

        public Product Get(Guid id)
        {
            var product = _productRepository.Get().FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return product;
            }

            throw new BusinessException(-1, "Product not found");
        }

        public List<Product> GetAll()
        {
            var resultList = _productRepository.Get().ToList();
            return resultList;
        }

        public void Create(Product product)
        {
            _productRepository.Create(product);
            _productRepository.SaveChanges();
        }

        public void Update(Product product)
        {
            var prod = _productRepository.Get().FirstOrDefault(x => x.Id == product.Id);
            if (prod != null)
            {
                prod.Name = product.Name;
                prod.ProductType = product.ProductType;
                prod.Price = product.Price;
                prod.Returns = product.Returns;
                prod.IsDeleted = product.IsDeleted;

                _productRepository.Update(prod);
                _productRepository.SaveChanges();
            }
            else
            {
                throw new BusinessException(-1, "Product not found");
            }
        }
        public void Delete(Guid id)
        {
            var product = _productRepository.Get().FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _productRepository.Delete(product);
                _productRepository.SaveChanges();
            }
            else
            {
                throw new BusinessException(-1, "Product not found");
            }
        }
        public void SoftDelete(Guid id)
        {
            var product = _productRepository.Get().FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                product.IsDeleted = true;
                _productRepository.Update(product);
                _productRepository.SaveChanges();
            }
            else
            {
                throw new BusinessException(-1, "Product not found");
            }
        }
    }
}
