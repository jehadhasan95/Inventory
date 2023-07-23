using Inventory.Models;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Product;
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
        
            
          public static IEnumerable<CustomerListViewModel>
             ModelToVM(this IEnumerable<Inventory.Models.Customer> customers)
            



        public static IEnumerable<ProductTypeListViewModel>
            ModelToVM(this IEnumerable<Inventory.ProductType> producType)
        {
            List<ProductTypeListViewModel> list = new List<ProductTypeListViewModel>();
            foreach (var item in producType)
            {
                list.Add(new ProductTypeListViewModel()
                {
                    ProductTypeID=ct.ProductTypeId,
                    ProductTypeName=ct.ProductTypeName,
                    Description=ct.Description,


                });
            }
            return list;
        }




    }
}
