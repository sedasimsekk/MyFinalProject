using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
     public interface IEntityRepository<T> where T:class,IEntity,new()
        //her nesne için aynı şeyleri tekrar tekrar tipinden dolayı yazmak yerine bir generic interface ile soyutlayabiliriz.
        //burada T için generic constraint(kısıt) vermiş olduk 
        //yani bize sadece referans tip verebilicek
        //T class olmalı ya bir IEntity olmalı yada onu implement etmiş olmalı
        //new() ile verilen referans tip new'lenebilir olmalı kısmını da ekledik
        //bizim için sistem artık sadece veri tabanı nesneleriyle çalışır hale geldi.
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //çağırıldığı yerde filtreleme yapabiliriz
        T Get(Expression<Func<T, bool>> filter);  //tek bir T veri tipinde bir şey döner filtre zorunlu yanı category göre getir isme göre getir diye ayrı ayrı methodlar yapmamıza gerek kalmadı zaten biz çağırdıgımız yerde istediğimiz filtreyi yazabilicez.

        void Add(T entity);
        void UpDate(T entity);
        void Delete(T entity);
    }
}
