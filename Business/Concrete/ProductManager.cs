using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal) //bir constructor oluşturduk burası kesinlikle çalışsın diye
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları 
            return _productDal.GetAll(); //yukarıdaki iş kodlarında eğer uygun görülürse yani sağlanıyorsa date access veri erişimi kısmına erişiyoruz ve gerekli şeyleri oradan çekiyoruz


        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
