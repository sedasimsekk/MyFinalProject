using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //tekrar tekrar add update gibi şeylerin içeriğini doldurmama gerek kalmicak ortak bir basee sınıfı yazıyoruz
    //ve bu sınıf bizim için bir bir entity bir de context olucak bunlar her biri için değişebiliceğinden 
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext:DbContext,new() 
        //ikisi için de farklı bir şey verilmesin diye gerekli generic kısıtları verdik.
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext()) //bellekten hızlı temizleme
            {
                var addedEntity = context.Entry(entity); //veri tabanı ile bağlantıyı kur referansı yakala
                addedEntity.State = EntityState.Added; //durumunu işlemini belirtme gibi düşünülebilir.
                context.SaveChanges(); //ekleme işlemi yapılır.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) //bellekten hızlı temizleme
            {
                var deletedEntity = context.Entry(entity); //veri tabanı ile bağlantıyı kur referansı yakala
                deletedEntity.State = EntityState.Deleted; //durumunu işlemini belirtme gibi düşünülebilir.
                context.SaveChanges(); //silme işlemi yapılır.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); //foreach gibi hepsini tek tek dolaşıp filtreye uyanı getiricek

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                //ternary operatörü kullanarak filterin olduğu ve olmadığı durumlara göre olanı yazdık.
            }
        }

        public void UpDate(TEntity entity)
        {
            using (TContext context = new TContext()) //bellekten hızlı temizleme
            {
                var updatedEntity = context.Entry(entity); //veri tabanı ile bağlantıyı kur referansı yakala
                updatedEntity.State = EntityState.Modified; //durumunu işlemini belirtme gibi düşünülebilir.
                context.SaveChanges(); //güncelleme işlemi yapılır.
            }
        }
    }
}
