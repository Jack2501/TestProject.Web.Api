using System.Collections.Generic;
using System.Linq;
using YevhenUshakov.TestProject.Data.Entities;
using YevhenUshakov.TestProject.Data.Repositories.Abstract;
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
        public List<Product> Get()
        {
            return _productRepository.Get().ToList();
        }
    }
}
