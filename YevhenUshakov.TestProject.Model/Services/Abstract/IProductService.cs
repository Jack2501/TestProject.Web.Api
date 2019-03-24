using System;
using System.Collections.Generic;
using YevhenUshakov.TestProject.Data.Entities;

namespace YevhenUshakov.TestProject.Model.Services.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product Get(Guid Id);
        void Create(Product product);
        void Update(Product product);
        void Delete(Guid id);
        void SoftDelete(Guid id);
    }
}
