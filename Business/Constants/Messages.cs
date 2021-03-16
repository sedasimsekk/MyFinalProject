using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //static class newlenmeden kullanılır.
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi"; //static class olduğu için static field olmalıdır.
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime="Sistem bakımda ";
        public static string ProductsListed="Ürünler Listelendi";
    }
}
