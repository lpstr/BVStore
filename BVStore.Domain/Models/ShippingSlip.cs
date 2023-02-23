using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVStore.Domain.Models
{
    public class ShippingSlip
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public int OrderId { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
