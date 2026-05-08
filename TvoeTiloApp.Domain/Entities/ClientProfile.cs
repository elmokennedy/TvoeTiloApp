namespace TvoeTiloApp.Domain.Entities
{
    public class ClientProfile
    {
        public int ClientProfileId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public List<ScheduledTraining> ScheduledTrainings { get; set; }
    }
}
