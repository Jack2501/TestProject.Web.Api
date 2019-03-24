using System.Linq;
using YevhenUshakov.TestProject.Data.Entities;
using YevhenUshakov.TestProject.Data.Repositories.Abstract;

namespace YevhenUshakov.TestProject.Data.Repositories.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext dataContext): base(dataContext)
        {
            
        }
    }
}
