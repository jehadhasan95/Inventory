using Inventory.Repositories.BillTypeService;
using Inventory.Repositories.Paging;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories.ProductTypeService
{
    public class ProductTypeRepo : IProductTypeRepo
    {
        private ApplicationDbContext _context;

        public ProductTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<ProductTypeListViewModel>> GetAll(int pageSize, int PageNumber)
        {
            var productTypeList = _context.ProductTypes;
            var vm = productTypeList.ModelToVM().AsQueryable();
            return await PaginatedList<ProductTypeListViewModel>.CreateAsync(vm, PageNumber, pageSize);
        }
    }
}
