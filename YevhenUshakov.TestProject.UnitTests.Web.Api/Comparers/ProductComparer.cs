using System;
using System.Collections.Generic;
using YevhenUshakov.TestProject.Data.Entities;

namespace YevhenUshakov.TestProject.UnitTests.Web.Api.Comparers
{
    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (x == null || y == null)
            {
                throw new InvalidOperationException();
            }

            if (x.Name == y.Name &&
                x.ProductType == y.ProductType &&
                x.Price == y.Price &&
                x.Returns == y.Returns)
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
