

using Asar.Domain.Abstraction;

namespace SalesProject.Domain.DomaimModels.Users
{
    public class ValidationCode : BaseEntity
    {
        public Guid UserId { get; set; }

        public string Code { get; set; } = null!;

        public DateTime GeneratedDate { get; set; }

        public DateTime ExpirationDate { get; set; }

    }
}
