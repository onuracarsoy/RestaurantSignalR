﻿using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBasketService :  IGenericService<Basket>
    {

        List<GetBasketByTableNumber> TGetBasketByTableNumber(int id);
        GetBasketByTableIDAndProductID TGetBasketByTableIDAndProductID(int tableID, int productID);
    }
}