using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    internal class BillType
    {

        public int BillYypeId { get; set; }
        [Required]
        public string BillTypeName { get; set; }
        public string Description { get; set; }

    }
}
