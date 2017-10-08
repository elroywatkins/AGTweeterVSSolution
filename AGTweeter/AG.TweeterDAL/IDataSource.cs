using System;
using System.Collections.Generic;
using System.Text;

namespace AG.TweeterDAL
{
    public interface IDataSource
    {
        IDictionary<int,string> GetData();        
    }
}
