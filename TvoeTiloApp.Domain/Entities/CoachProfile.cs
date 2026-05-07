namespace TvoeTiloApp.Domain.Entities
{
    public class CoachProfile
    {
        public int CoachProfileId { get; set; }
        public string Summary { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public List<TrainingType> TrainingTypes { get; set; }
    }
}
