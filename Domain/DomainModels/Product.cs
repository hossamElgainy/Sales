using Asar.Domain.Abstraction;
using SalesProject.Domain.DomaimModels.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainModels
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PurchasingPrice { get; set; }

        public int Quentity { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public ICollection<Sales> Sales { get; set; } = new HashSet<Sales>();
    }
}
