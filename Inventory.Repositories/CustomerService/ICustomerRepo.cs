using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories.CustomerService
{
    public interface ICustomerRepo
    {

        Task<PaginatedList<CustomerListViewModel>> GetAll(int pageSize, int PageNumber);
    }
}
