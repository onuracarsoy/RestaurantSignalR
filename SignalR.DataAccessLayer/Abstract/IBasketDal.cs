using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {

        List<GetBasketByTableNumber> GetBasketByTableNumber (int id);
        GetBasketByTableIDAndProductID GetBasketByTableIDAndProductID(int tableID,int productID);
    }
}
