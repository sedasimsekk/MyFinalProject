using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        { 
            //Oracle,Sql,Server,Postgres,MangoDb gelmiş gibi simule ediyoruz.
            _products = new List<Product> { 
              new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=10},
              new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=10},
              new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=10},
              new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=10},
              new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=10},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //1.YOL
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p; //silmek istediğimizin referansına eriştik bu sayede 
            //    }
            //    _products.Remove(productToDelete); //referans ile o istediğimiz ürünü silebiliriz.

                 //2.YOL
                //LİNQ-language ıntegrated querry -Entegre dil sorgulama
                //LİNQ ile yukarıda yazdıgımız işlevin aynısını burada tekrar yazacagız 
                Product productToDelete =_products.SingleOrDefault(_products=>_products.ProductId == product.ProductId);
               _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //burada where methodu ile buna göre olanlar nerede hepsini al dedik ve tolist ile bunları liste yapıp çağırıldığı yere gönderdik.
            return _products.Where(_products => _products.CategoryId == categoryId).ToList();
            //bu sayede bizden istenen şeye göre filtreledik bunu yanına && || bunlar ile daha da farklı koşullara göre alabiliriz.
        }

        public void UpDate(Product product)
        {
            //Gönderdiğim ürün id'sine sahip listedeki urunu bul
            Product productToUpDate = _products.SingleOrDefault(_products => _products.ProductId == product.ProductId);
            //ve bulduğumuz referansın guncellemesını yaptık.
            productToUpDate.ProductName = product.ProductName;
            productToUpDate.CategoryId = product.CategoryId;
            productToUpDate.UnitPrice = product.UnitPrice;
            productToUpDate.UnitsInStock = product.UnitsInStock;
        }
    }

}
