using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    //NuGet
    public class EfProductDal :EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
        //IProductDal 'ın inherit aldığı her method içi dolu bir biçimde base sınıfta olduğu için biz onu alınca IProductDal için de kızmayı bıraktı
    {
        
    }
}
