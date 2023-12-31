﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource
{
   public interface IItemsProvider<T>
    {
        int FetchCount();
        IList<T> FetchRange(int startIndex,int pageCount,out int overallCount);
    }
}
