using BVStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVStore.Domain.Models
{
    public class ProductDTO
    {
        public string? Name { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; } 
        public ProductType ProductType { get; set; }
    }
}
