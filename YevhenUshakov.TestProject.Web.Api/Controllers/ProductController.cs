using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YevhenUshakov.TestProject.Data.Entities;
using YevhenUshakov.TestProject.Model.Services.Abstract;
using YevhenUshakov.TestProject.Web.Api.Model;

namespace YevhenUshakov.TestProject.Web.Api.Controllers
{
    public class ProductController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route(Routes.Product)]
        public ApiResponse<List<Product>> Get()
        {
            List<Product> result = _productService.Get().ToList();
            return new ApiResponse<List<Product>>(result);
        }
    }
}
