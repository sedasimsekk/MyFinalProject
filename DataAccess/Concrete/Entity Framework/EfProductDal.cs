using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    //NuGet
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    //IProductDal 'ın inherit aldığı her method içi dolu bir biçimde base sınıfta olduğu için biz onu alınca IProductDal için de kızmayı bıraktı
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context=new NorthwindContext()) //belleği hızlı temizleme
            {
                //Dto-ilişkisel verileri getirdik çağırılan yere gönderdik.
                var result = from p in context.Products join c in context.Categories on p.ProductId equals c.CategoryId select new ProductDetailDto 
                { ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock };
                return result.ToList(); //liste dondrumesini istemiştik

            }
        }
    }
}
