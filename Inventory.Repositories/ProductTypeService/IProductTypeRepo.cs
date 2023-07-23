using Inventory.Repositories.BillTypeService;
using Inventory.Repositories.Paging;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories.ProductTypeService
{
    public interface IProductTypeRepo
    {
        Task<PaginatedList<ProductTypeListViewModel>> GetAll(int pageSize, int PageNumber);
    }
}
