using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //burada this ile dont repeat olmasını engelledik 
        //yani alttaki Success=success; kod satırını iki kez yazmak yerine böyle yaparak o iki constructorı çalıştırdık.
        //this:bu classı
        public Result(bool success, string message):this(success)  
        {
            Message = message; 
        }
        public Result(bool success) //constructor overloading yapıldı  
        {
            //biz ekrana herhangi bir mesaj yazdırmak istemeyebiliriz bu sayede mesaj gondermediği zaman bu constructor çalışacak.
            Success = success;
        }

        //IResult 'ın somut sınıfını oluşturduk.
        public bool Success { get; }

        public string Message { get; }
    }
}
