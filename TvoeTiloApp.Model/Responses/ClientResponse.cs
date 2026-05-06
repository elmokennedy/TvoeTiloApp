namespace TvoeTiloApp.Model.Responses
{
    public class ClientResponse
    {
        public int ClientId { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }
    }
}
