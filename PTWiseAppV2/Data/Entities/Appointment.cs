using System.ComponentModel.DataAnnotations;

namespace PTWiseAppV2.Data.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public Trainer Trainer { get; set; } = null!;
        public int TrainerId { get; set; }
        public Client Client { get; set; } = null!;
        public int ClientId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentStatus Status { get; set; }

        public ICollection<Workout> Workouts { get; } = new List<Workout>();

    }
}
