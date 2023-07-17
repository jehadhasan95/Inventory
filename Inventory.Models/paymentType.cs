using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{ 
    public class paymentType
    { 
        public int paymentTypeId { get; set; }
        [Required  ]
        public string paymentTypeName { get; set; }
        public string Description { get; set; }

    }
}
