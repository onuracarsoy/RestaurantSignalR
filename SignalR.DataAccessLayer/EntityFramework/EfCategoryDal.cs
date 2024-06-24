using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
		private readonly SignalRContext _context;

		public EfCategoryDal(SignalRContext context) : base(context)
		{
			_context = context;
		}

		public int GetActiveCategoryCount()
		{
			var activeCategoryCount = _context.Categories.Count(x => x.CategoryStatus == true);
			return activeCategoryCount;
		}

		public int GetCategoryCount()
		{
			var categoryCount = _context.Categories.Count();
			return categoryCount;
		}

		public int GetPassiveCategoryCount()
		{
			var passiveCategoryCount = _context.Categories.Count(x => x.CategoryStatus == false);
			return passiveCategoryCount;
		}
	}
}
