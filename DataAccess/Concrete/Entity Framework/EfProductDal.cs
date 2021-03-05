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
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext context=new NorthwindContext()) //bellekten hızlı temizleme
            {
                var addedEntity = context.Entry(entity); //veri tabanı ile bağlantıyı kur referansı yakala
                addedEntity.State = EntityState.Added; //durumunu işlemini belirtme gibi düşünülebilir.
                context.SaveChanges(); //ekleme işlemi yapılır.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //bellekten hızlı temizleme
            {
                var deletedEntity = context.Entry(entity); //veri tabanı ile bağlantıyı kur referansı yakala
                deletedEntity.State = EntityState.Deleted; //durumunu işlemini belirtme gibi düşünülebilir.
                context.SaveChanges(); //silme işlemi yapılır.
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); //foreach gibi hepsini tek tek dolaşıp filtreye uyanı getiricek

            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
                //ternary operatörü kullanarak filterin olduğu ve olmadığı durumlara göre olanı yazdık.
            }
        }

        public void UpDate(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //bellekten hızlı temizleme
            {
                var updatedEntity = context.Entry(entity); //veri tabanı ile bağlantıyı kur referansı yakala
                updatedEntity.State = EntityState.Modified; //durumunu işlemini belirtme gibi düşünülebilir.
                context.SaveChanges(); //güncelleme işlemi yapılır.
            }
        }
    }
}
