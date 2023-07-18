﻿using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inventory.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        [Display(Name = "Purchase Order")]
        public string Name { get; set; }
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [Display(Name = "Vandor")]
        public int VandorId { get; set; }
        public DateTimeOffset DateOfOrder { get; set; }
        public DateTimeOffset DateOfDelivery { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }
        [Display(Name = "Purchase Type")]
        public int PurchaseTypeId { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public ICollection<PurchaseOrderLine> purchaseOrderLines { get; set; }
        = new HashSet<PurchaseOrderLine>();

    }
}
