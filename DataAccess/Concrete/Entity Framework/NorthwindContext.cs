using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    //context:db tabloları ile proje classlarını bağlamak 
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;DataBase=Northwind;Trusted_Connection=true");
            //yerini belirttik hangi veri tabanı olduğunu belirttik 
            //kullanıcı adı ve şifre gerektirmeyenlerde true olarak kullanırız gerçek sistemde kullanıcı adı ve şifre vardır.
        }

        //şimdi de db tabloları ile nesnelerimizi eşleştireceğiz.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }

    }

