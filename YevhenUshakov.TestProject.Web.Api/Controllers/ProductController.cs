using System;
using System.Collections.Generic;
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
        [Route(Routes.Products)]
        public ApiResponse<List<Product>> GetAll()
        {
            List<Product> result = _productService.GetAll();
            return new ApiResponse<List<Product>>(result);
        }

        [HttpGet]
        [Route(Routes.Product)]
        public ApiResponse<Product> Get(Guid id)
        {
            Product result = _productService.Get(id);
            return new ApiResponse<Product>(result);
        }

        [HttpPost]
        [Route(Routes.Products)]
        public ApiResponse Create([FromBody]Product product)
        {
            _productService.Create(product);
            return new ApiResponse();
        }

        [HttpPut]
        [Route(Routes.Products)]
        public ApiResponse Update([FromBody]Product product)
        {
            _productService.Update(product);
            return new ApiResponse();
        }

        [HttpDelete]
        [Route(Routes.Product)]
        public ApiResponse Delete(Guid id)
        {
            _productService.Delete(id);
            return new ApiResponse();
        }
    }
}
