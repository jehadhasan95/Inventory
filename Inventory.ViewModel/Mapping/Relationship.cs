using Inventory.Models;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Mapping
{
    public static class Relationship
    {
        public static IEnumerable<CustomerTypeListViewModel> ModelToVM(this IEnumerable<CustomerType> customerType)
        {
            List<CustomerTypeListViewModel> list = new List<CustomerTypeListViewModel>();

            foreach (var item in customerType)
            {
                list.Add(new CustomerTypeListViewModel { 
                CustomerTypeId = item.CustomerTypeId,
                CustomerTypeName = item.CustomerTypeName,
                Description = item.Description
                });
            }
            return list;
        }
    }
}
