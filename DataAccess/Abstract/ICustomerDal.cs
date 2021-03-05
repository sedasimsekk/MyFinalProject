using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICustomerDal:IEntityRepository<Customer> //sisteme yeni bir şey eklendiğinde hemen bu hale getirebildik yaptığımız soyutlama sayesinde 
    {

    }
}
