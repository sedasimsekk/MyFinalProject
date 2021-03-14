using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için bir başlangıç
    public interface IResult
    {
        bool Success { get; } //başarılı mı başarısız mı 
        string Message { get; } //döndürmek istediğimiz mesaj 
    }
}
