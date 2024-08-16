using Asar.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainModels
{
    public class Sales:BaseEntity
    {
        public int Quentity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PurchasingPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SellingPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
