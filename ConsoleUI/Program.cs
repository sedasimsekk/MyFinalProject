using Business.Concrete;
using DataAccess.Concrete.Entity_Framework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //DTO- Data Transformation Object 
             ProductTest(); //artık yapıyı bir extract method haline getirdik.
            //CategoryTest();  //burayı da bir extract method haline getirdik.
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            if(result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.CategoryName);
                }
            }
           
        }
    }
}
