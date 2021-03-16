using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //bir message bir success bir data içericek
    //bende IResult implemantaasyonu yaptım çünkü bir message bir success için neden kendimi tekrar edeyim
    public interface IDataResult<T>:IResult
    {
        T Data { get;  }
    }
}
