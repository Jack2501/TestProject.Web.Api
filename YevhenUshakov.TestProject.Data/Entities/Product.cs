using YevhenUshakov.TestProject.Data.Enums;

namespace YevhenUshakov.TestProject.Data.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public ProductTypes ProductType { get; set; }
        public decimal Price { get; set; }
        public decimal Returns { get; set; }
    }
}
