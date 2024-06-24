using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        private readonly SignalRContext _context;
        public EfBasketDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public GetBasketByTableIDAndProductID GetBasketByTableIDAndProductID(int tableID, int productID)
        {
            var getBasketByTableID = (from b in _context.Baskets
                                      where b.MenuTableID == tableID && b.ProductID == productID
                                      join t in _context.MenuTables
                                      on b.MenuTableID equals t.MenuTableID
                                      join p in _context.Products
                                      on b.ProductID equals p.ProductID
                                      select new GetBasketByTableIDAndProductID
                                      {
                                          BasketID = b.BasketID,
                                          MenuTableID = b.MenuTableID,
                                          ProductID = b.ProductID,
                                          ProductName = p.ProductName,
                                          ProductPrice = p.ProductPrice,
                                          BasketProductCount = b.BasketProductCount,
                                          BasketTotalPrice = b.BasketTotalPrice,

                                      }).FirstOrDefault();

            return getBasketByTableID;
        }

        public List<GetBasketByTableNumber> GetBasketByTableNumber(int id)
        {
            var getBasketByTableNumber = (from b in _context.Baskets
                                          where b.MenuTableID == id
                                          join t in _context.MenuTables
                                          on b.MenuTableID equals t.MenuTableID
                                          join p in _context.Products
                                          on b.ProductID equals p.ProductID
                                          select new GetBasketByTableNumber
                                          {
                                              BasketID = b.BasketID,
                                              MenuTableID = b.MenuTableID,
                                              ProductID = b.ProductID,
                                              ProductName = p.ProductName,
                                              ProductPrice = p.ProductPrice,
                                              BasketProductCount = b.BasketProductCount,
                                              BasketTotalPrice = b.BasketTotalPrice,

                                          }).ToList();
            return getBasketByTableNumber;
        }
    }
}
