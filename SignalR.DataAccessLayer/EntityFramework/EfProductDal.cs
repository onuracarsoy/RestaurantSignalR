using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly SignalRContext _context;

        public EfProductDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

		public int GetActiveProductCount()
		{
			var activeProductCount = _context.Products.Where(p => p.ProductStatus == true).Count();
			return activeProductCount;
		}

		public int GetPassiveProductCount()
		{
			var passiveProductCount = _context.Products.Where(p => p.ProductStatus == false).Count();
            return passiveProductCount;
		}

		public int GetProductCount()
		{
			var productCount = _context.Products.Count();
            return productCount;
		}

   

        public List<GetProductsWithCategoriesDto> GetProductsWithCategories()
        {

            var values = _context.Products
                        .Include(p => p.Category)
                        .Select(p => new GetProductsWithCategoriesDto
                                {
                                       ProductID = p.ProductID,
                                       ProductName = p.ProductName,
                                       ProductDescription = p.ProductDescription,
                                       ProductPrice = p.ProductPrice,
                                       ProductImageUrl = p.ProductImageUrl,
                                       ProductStatus = p.ProductStatus,
                                       CategoryName = p.Category.CategoryName
                                 })
                                 .ToList();
            return values;

        }
    }
}
