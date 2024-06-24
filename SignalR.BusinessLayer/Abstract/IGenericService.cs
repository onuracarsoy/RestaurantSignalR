﻿using SignalR.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TAdd(T entity);

        void TUpdate(T entity);

        void TDelete(T entity);

        List<T> TGetListAll();

        T TGetByID(int id);
    }
}
