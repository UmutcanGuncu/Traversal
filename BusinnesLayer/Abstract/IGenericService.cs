﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TAdd(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);
        List<T> TGetList();
        T TGetById(int id);
        
    }
}
