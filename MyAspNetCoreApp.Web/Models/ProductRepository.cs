﻿namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
                (new Product { Id = 1, Name = "Kalem1", Price = 100, Stock = 200 }),
            (new Product { Id = 2, Name = "Kalem2", Price = 200, Stock = 300 }),
            (new Product { Id = 3, Name = "Kalem3", Price = 300, Stock = 400 })
        };

        public List<Product> GetAll() => _products;
        public void Add(Product newProduct) => _products.Add(newProduct);
        public void remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == id);
            if (hasProduct == null)
            {
                throw new Exception($"Bu id({id}'ye sahip ürün bulunmamaktadır.");
            }
            _products.Remove(hasProduct);
        }
        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == updateProduct.Id);
            if (hasProduct == null)
            {
                throw new Exception($"Bu id({updateProduct.Id}'ye sahip ürün bulunmamaktadır.");
            }
            hasProduct.Name = updateProduct.Name;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;
            var index = _products.FindIndex(x => x.Id == updateProduct.Id);
            _products[index] = hasProduct;
        }
    }
}
