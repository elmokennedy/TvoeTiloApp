namespace TvoeTiloApp.Domain.Entities
{
    public class Client
    {
        public int ClientId { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? Email { get; set; }

        public required string PhoneNumber { get; set; }
    }
}
