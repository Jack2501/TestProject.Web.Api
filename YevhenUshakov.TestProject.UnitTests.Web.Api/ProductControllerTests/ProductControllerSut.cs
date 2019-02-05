using Moq;
using YevhenUshakov.TestProject.Model.Services.Abstract;
using YevhenUshakov.TestProject.Web.Api.Controllers;

namespace YevhenUshakov.TestProject.UnitTests.Web.Api.ProductControllerTests
{
    public class ProductControllerSut
    {
        public ProductController Instance { get; set; }
        public Mock<IProductService> ProductService { get; set; }

        public ProductControllerSut()
        {
            ProductService = new Mock<IProductService>();
            Instance = new ProductController(ProductService.Object);
        }
    }
}
