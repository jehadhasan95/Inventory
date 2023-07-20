﻿using Inventory.Repositories.Paging;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories.CustomerTypes
{
    public class CustomerTypeRepo : ICustomerTypeRepo
    {
        public Task<PaginatedList<CustomerTypeListViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
