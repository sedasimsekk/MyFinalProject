using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //result base sınıf içeriisndeki içi dolu methodlar kullanılabilir,inherit ettik
    //IDataResult bir interface içerisinde imzası olan methodlar burada doldurulmalı ,implement ettik
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success,string message):base(success,message)
        {
            Data = data;
        }
        public DataResult(T data,bool success):base(success) //mesaj olmasın istediğimiz
        {
            Data = data;
        }
        public T Data { get; }
    }
}
