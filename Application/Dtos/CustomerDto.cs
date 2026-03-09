namespace Application.Dtos;

    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool Activo { get; set; }
    }

