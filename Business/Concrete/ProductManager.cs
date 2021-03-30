using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //business codes-iş kodları yazacağız buraya eklemesi için 
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded); //bir IResult gönderdik
        }
        //base Result sınıf sayesinde IResult da SuccessResultın referansını tutabildi.

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları 

            //mesela sistemin şu saatten sonra ürün listelemesini istemiyorsam böyle bir şey yapabilirim
            if (DateTime.Now.Hour==22)//simdiki saat sorgusu
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed); //yukarıdaki iş kodlarında eğer uygun görülürse yani sağlanıyorsa date access veri erişimi kısmına erişiyoruz ve gerekli şeyleri oradan çekiyoruz


        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
