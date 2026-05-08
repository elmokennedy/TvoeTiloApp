namespace TvoeTiloApp.Domain.Entities
{
    public class ScheduledTraining
    {
        public int ScheduledTrainingId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public int TrainingTypeId { get; set; }

        public TrainingType TrainingType { get; set; }
        public List<ClientProfile> ClientProfiles { get; set; }
    }
}
