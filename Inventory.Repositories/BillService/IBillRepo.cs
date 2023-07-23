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
    public interface IBillRepo
    {
        Task<PaginatedList<BillListViewModel>> GetAll(int pageSize, int PageNumber);
    }
}
