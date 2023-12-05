using System.ComponentModel.DataAnnotations;

namespace PTWiseAppV2.Data.Entities
{
    public class Workout
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public Appointment Appointment { get; set; } = null!;
        public int AppointmentId { get; set; }
        public int DurationMins { get; set; }

        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
