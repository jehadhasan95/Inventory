using Inventory.Repositories.Paging;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories.BillTypeService
{
    public class BillTypeRepo : IBillTypeRepo
    {
        private ApplicationDbContext _context;

        public BillTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<BillTypeListViewModel>> GetAll(int pageSize, int PageNumber)
        {
            var billTypes = _context.BillTypes;
            IQueryable vm = billTypes.ModelToVM().AsQueryable();
            return await PaginatedList<BillTypeListViewModel>.CreateAsync(vm, PageNumber, pageSize);

        }
    }
}
