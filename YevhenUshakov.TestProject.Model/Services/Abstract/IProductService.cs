using System.Collections.Generic;
using YevhenUshakov.TestProject.Data.Entities;

namespace YevhenUshakov.TestProject.Model.Services.Abstract
{
    public interface IProductService
    {
        List<Product> Get();
    }
}
