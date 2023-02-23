using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVStore.Domain.Entities
{
    public class Membership
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [Column("DiscountPercent", TypeName = "numeric(3,0)")]
        public decimal DiscountPercent { get; set; }
    }
}
