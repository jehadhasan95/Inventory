using Inventory.Repositories.Paging;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories.CustomerService
{
    public class CustomerRepo : ICustomerRepo
    {
        private ApplicationDbContext _context;

        public CustomerRepo(ApplicationDbContext context)
        {
            _context = context;

        public async Task<PaginatedList<CustomerListViewModel>> GetAll(int pageSize, int PageNumber)
        {
                var customerList = _context.Customers;
                var vm = customerList.ModelToVM().AsQueryable();
                return await PaginatedList<CustomerListViewModel>.CreateAsync(vm, PageNumber, pageSize);


        }
    }
}
