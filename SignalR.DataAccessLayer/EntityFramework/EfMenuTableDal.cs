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
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
		private readonly SignalRContext _context;
        public EfMenuTableDal(SignalRContext context) : base(context)
        {
			_context = context;
        }

		public int GetActiveTableCount()
		{
			var activeTableCount = _context.MenuTables.Where(x => x.TableStatus == true).Count();
			return activeTableCount;
		}

		public int GetPassiveTableCount()
		{
			var passiveTableCount = _context.MenuTables.Where(x => x.TableStatus == false).Count();
			return passiveTableCount;
		}
	}
}
