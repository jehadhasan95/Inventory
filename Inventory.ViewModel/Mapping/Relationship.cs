using Inventory.Models;
using Inventory.ViewModel.Bill;
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
        public static IEnumerable<CustomerTypeListViewModel> 
            ModelToVM(this IEnumerable<CustomerType> customerType)
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


        public static IEnumerable<CustomerListViewModel>
            ModelToVM(this IEnumerable<Inventory.Models.Customer> customers)
        {
            List<CustomerListViewModel> list = new List<CustomerListViewModel>();

            foreach (var item in customers)
            {
                list.Add(new CustomerListViewModel
                {
                    CustomerTypeId = item.CustomerTypeId,
                    CustomerTypeName = item.CustomerTypeName,
                    Description = item.Description
                });
            }
            return list;
        }

        public static IEnumerable<BillTypeListViewModel>
            ModelToVM(this IEnumerable<Inventory.Models.BillType> billType)
        {
            List<BillTypeListViewModel> list = new List<BillTypeListViewModel>();
            foreach (var item in billType)
            {
                list.Add(new BillTypeListViewModel()
                {
                    BillTypeId=ct.BillTypeId,
                    BillTypeName=ct.BIllTypeName,
                    Description=ct.Description
                });
            }
            return list;
        }



    }
}
