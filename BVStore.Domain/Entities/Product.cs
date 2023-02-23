using BVStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVStore.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("Price", TypeName = "numeric(18,2)")]
        public decimal Price { get; set; }
        public virtual IList<OrderProduct> Orders { get; set; }
        public ProductType ProductType { get; set; }
    }
}
