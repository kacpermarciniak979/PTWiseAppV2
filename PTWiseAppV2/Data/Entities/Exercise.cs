using PTWiseAppV2.Components.Account.Pages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PTWiseAppV2.Data.Entities
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public int Sets { get; set; }
        // Reps should be string - in case of "to failure", or similar.
        public string? Reps { get; set; }
        public int RestPeriodSeconds { get; set; }
        public Difficulty Difficulty { get; set; }
        [JsonIgnore]
        public Workout Workout { get; set; } = null!;
        public int WorkoutId { get; set; }
    }
}
