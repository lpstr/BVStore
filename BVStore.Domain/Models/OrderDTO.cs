using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVStore.Domain.Models
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<ProductDTO> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
