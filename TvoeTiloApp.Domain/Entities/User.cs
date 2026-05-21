using TvoeTiloApp.Domain.Enums;

namespace TvoeTiloApp.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public UserRole UserRole { get; set; }

        public CoachProfile? CoachProfile { get; set; }
        public ClientProfile? ClientProfile { get; set; }
    }
}
