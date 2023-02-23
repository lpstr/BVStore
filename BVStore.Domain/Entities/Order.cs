using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVStore.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [Required]
        [Column("DateCreated", TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }
        [Column("DateUpdated", TypeName = "datetime2")]
        [AllowNull]
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public Customer Customer { get; set; }
        public virtual IList<OrderProduct> Products { get; set; }
        [Required]
        [Column("TotalPrice", TypeName = "numeric(18,2)")]
        public decimal TotalPrice { get; set; }
    }
}
