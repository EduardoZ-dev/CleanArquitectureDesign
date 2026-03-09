using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Customer : EntityBase
    {
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool Activo { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
