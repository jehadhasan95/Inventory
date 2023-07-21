using Inventory.Repositories.BillTypeService;
using Inventory.Repositories.Paging;
using Inventory.ViewModel.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories.BillService
{
    internal class BillRipo : IBillRepo
    {
        private ApplicationDbContext _context;

        public BillRipo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<BillListViewModel>> GetAll(int pageSize, int PageNumber)
        {
            var bills = _context.Bills;
            IQueryable vm = bills.ModelToVM().AsQueryable();
            return await PaginatedList<BillListViewModel>.CreateAsync(vm, PageNumber, pageSize);
        }
    }
}   
