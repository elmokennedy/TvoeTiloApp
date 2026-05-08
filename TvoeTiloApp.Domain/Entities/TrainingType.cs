namespace TvoeTiloApp.Domain.Entities
{
    public class TrainingType
    {
        public int TrainingTypeId { get; set; }
        public string Name { get; set; }

        public List<CoachProfile> CoachProfiles { get; set; }
        public List<ScheduledTraining> ScheduledTrainings { get; set; }
    }
}
