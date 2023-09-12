using ELSA.Demo.Workflow.Models.enums;
using System.ComponentModel.DataAnnotations;

namespace ELSA.Demo.Workflow.DataAccess.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public DateTime? RenewedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
