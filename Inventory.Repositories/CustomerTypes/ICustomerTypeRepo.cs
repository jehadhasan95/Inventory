using Inventory.Repositories.Paging;
using Inventory.ViewModel.Customer;

namespace Inventory.Repositories.CustomerTypes
{
    public interface ICustomerTypeRepo
    {
        Task<PaginatedList<CustomerTypeListViewModel>> GetAll();
    }
}
