
using System.ComponentModel.DataAnnotations.Schema;
using Domain.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace SalesProject.Domain.DomaimModels.Users
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
