using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        // overloading ile iki adet constructor kullandık bunlar base sınıfa true (başarılı) olmasını default olarak gönderiyor.
        //base() base sınıfın constructoruna bir şey gönderdik
        //message alan constructor çağırılırsa bize verilen mesajıda gönderiyoruz.
        public SuccessResult(string message):base(true,message)
        {

        }
        public SuccessResult():base(true)
        {

        }
    }
}
