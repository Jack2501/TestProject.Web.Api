using System.Linq;
using YevhenUshakov.TestProject.Data.Entities;

namespace YevhenUshakov.TestProject.Data.Repositories.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Get();
    }
}
