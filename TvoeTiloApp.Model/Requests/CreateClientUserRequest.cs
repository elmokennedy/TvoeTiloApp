namespace TvoeTiloApp.Model.Requests
{
    public class CreateClientUserRequest
    {
        public string Email { get; set; }
        //public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
