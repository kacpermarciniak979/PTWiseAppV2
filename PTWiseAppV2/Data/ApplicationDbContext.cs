using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PTWiseAppV2.Data.Entities;
using System.Reflection.Emit;

namespace PTWiseAppV2.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Appointment>()
               .HasOne(a => a.Trainer)
               .WithMany()
               .HasForeignKey(a => a.TrainerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.Client)
                .WithMany()
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            //Trainers
            builder.Entity<Trainer>().HasData(new Trainer
            {
                Id = 1,
                Title = "Mr",
                FirstName = "John",
                LastName = "Palmer",
                DateOfBirth = new DateTime(1970, 10, 11),
                Email = "johnpalmer@ptwise.com",
                GymName = "PT Wise Gym",
                TelephoneNumber = "1234567890",
                AddressLine1 = "5 Geraldine Road",
                Country = "United Kingdom",
                Postcode = "WR14 3SZ"
            });
            builder.Entity<Trainer>().HasData(new Trainer
            {
                Id = 2,
                Title = "Mr",
                FirstName = "Ben",
                LastName = "Chadwick",
                DateOfBirth = new DateTime(2002, 10, 30),
                Email = "benchadwick@ptwise.com",
                GymName = "PT Wise Gym",
                TelephoneNumber = "07496327386",
                AddressLine1 = "20 Burnout Close",
                Country = "United Kingdom",
                Postcode = "WR14 1KT"
            });

            //Clients
            builder.Entity<Client>().HasData(new Client
            {
                Id = 1,
                Title = "Mr",
                FirstName = "Kacper",
                LastName = "Marciniak",
                DateOfBirth = new DateTime(2003, 01, 06),
                Email = "kacermarciniak@gmail.com",
                TelephoneNumber = "07465321286",
                AddressLine1 = "100 Elgar Road",
                Country = "United Kingdom",
                Postcode = "WR14 3EZ",
                TrainerId = 1

            });
            builder.Entity<Client>().HasData(new Client
            {
                Id = 2,
                Title = "Ms",
                FirstName = "Emily",
                LastName = "Johnson",
                DateOfBirth = new DateTime(1995, 03, 15),
                Email = "emily.johnson@example.com",
                TelephoneNumber = "07894561234",
                AddressLine1 = "25 Oak Street",
                Country = "United Kingdom",
                Postcode = "AB12 3CD",
                TrainerId = 2


            });
            builder.Entity<Client>().HasData(new Client
            {
                Id = 3,
                Title = "Mrs",
                FirstName = "Sophia",
                LastName = "Garcia",
                DateOfBirth = new DateTime(1988, 07, 22),
                Email = "sophia.garcia@example.com",
                TelephoneNumber = "07123456789",
                AddressLine1 = "15 Maple Avenue",
                Country = "United Kingdom",
                Postcode = "XY34 9AB",
                TrainerId = 1


            });
            builder.Entity<Client>().HasData(new Client
            {
                Id = 4,
                Title = "Mr",
                FirstName = "Daniel",
                LastName = "Smith",
                DateOfBirth = new DateTime(1990, 11, 03),
                Email = "daniel.smith@example.com",
                TelephoneNumber = "07654321098",
                AddressLine1 = "7 Pine Street",
                Country = "United Kingdom",
                Postcode = "CD56 8EF",
                TrainerId = 2


            });
            builder.Entity<Client>().HasData(new Client
            {
                Id = 5,
                Title = "Miss",
                FirstName = "Isabella",
                LastName = "Brown",
                DateOfBirth = new DateTime(2001, 05, 20),
                Email = "isabella.brown@example.com",
                TelephoneNumber = "07987654321",
                AddressLine1 = "30 Elm Road",
                Country = "United Kingdom",
                Postcode = "EF67 2GH",
                TrainerId = 1


            });
            builder.Entity<Client>().HasData(new Client
            {
                Id = 6,
                Title = "Mr",
                FirstName = "Oliver",
                LastName = "Davis",
                DateOfBirth = new DateTime(1985, 12, 10),
                Email = "oliver.davis@example.com",
                TelephoneNumber = "07234567890",
                AddressLine1 = "12 Birch Lane",
                Country = "United Kingdom",
                Postcode = "GH45 1IJ",
                TrainerId = 2

            });

            //Appointments
            builder.Entity<Appointment>().HasData(new Appointment
            {
                Id = 1,
                Title = "Session 1",
                StartTime = new DateTime(2023, 11, 28, 12, 30, 0),
                EndTime = new DateTime(2023, 11, 28, 13, 30, 0),
                Status = AppointmentStatus.Completed,
                ClientId = 6,
                TrainerId = 1,
            });
            builder.Entity<Appointment>().HasData(new Appointment
            {
                Id = 2,
                Title = "Session 2",
                StartTime = new DateTime(2023, 11, 28, 15, 0, 0),
                EndTime = new DateTime(2023, 11, 28, 16, 0, 0),
                Status = AppointmentStatus.Active,
                ClientId = 5,
                TrainerId = 1,
            });
            builder.Entity<Appointment>().HasData(new Appointment
            {
                Id = 3,
                Title = "Session 3",
                StartTime = new DateTime(2023, 11, 30, 9, 0, 0),
                EndTime = new DateTime(2023, 11, 30, 10, 0, 0),
                Status = AppointmentStatus.Scheduled,
                ClientId = 4,
                TrainerId = 1,
            });
            builder.Entity<Appointment>().HasData(new Appointment
            {
                Id = 4,
                Title = "Session 4",
                StartTime = new DateTime(2023, 12, 5, 10, 30, 0),
                EndTime = new DateTime(2023, 12, 5, 11, 30, 0),
                Status = AppointmentStatus.Cancelled,
                ClientId = 2,
                TrainerId = 2,
            });

            //Exercises
            builder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 1,
                Name = "Bench Press",
                ExerciseType = ExerciseType.Weightlifting,
                Sets = 4,
                Reps = "6",
                RestPeriodSeconds = 90,
                Difficulty = Difficulty.Beginner,
                WorkoutId = 1
            });

            builder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 2,
                Name = "Tricep Extensions",
                ExerciseType = ExerciseType.Weightlifting,
                Sets = 5,
                Reps = "8",
                RestPeriodSeconds = 60,
                Difficulty = Difficulty.Beginner,
                WorkoutId = 1
            });

            builder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 3,
                Name = "Squat",
                ExerciseType = ExerciseType.Weightlifting,
                Sets = 4,
                Reps = "8",
                RestPeriodSeconds = 120,
                Difficulty = Difficulty.Intermediate,
                WorkoutId = 2
            });

            builder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 4,
                Name = "Deadlift",
                ExerciseType = ExerciseType.Weightlifting,
                Sets = 4,
                Reps = "6",
                RestPeriodSeconds = 120,
                Difficulty = Difficulty.Advanced,
                WorkoutId = 2
            });

            builder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 5,
                Name = "Pull-ups",
                ExerciseType = ExerciseType.Weightlifting,
                Sets = 3,
                Reps = "10",
                RestPeriodSeconds = 60,
                Difficulty = Difficulty.Intermediate,
                WorkoutId = 1
            });

            builder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 6,
                Name = "Shoulder Press",
                ExerciseType = ExerciseType.Weightlifting,
                Sets = 4,
                Reps = "8",
                RestPeriodSeconds = 90,
                Difficulty = Difficulty.Intermediate,
                WorkoutId = 1
            });

            builder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 7,
                Name = "Bicep Curls",
                ExerciseType = ExerciseType.Weightlifting,
                Sets = 3,
                Reps = "10",
                RestPeriodSeconds = 45,
                Difficulty = Difficulty.Beginner,
                WorkoutId = 2
            });

            builder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 8,
                Name = "Lunges",
                ExerciseType = ExerciseType.Weightlifting,
                Sets = 3,
                Reps = "12",
                RestPeriodSeconds = 60,
                Difficulty = Difficulty.Intermediate,
                WorkoutId = 1
            });

            //Workouts
            builder.Entity<Workout>().HasData(new Workout
            {
                Id = 1,
                Name = "Bombaclaat Belly Blast",
                Date = DateTime.Now,
                AppointmentId = 1,
                DurationMins = 60,
            });

            builder.Entity<Workout>().HasData(new Workout
            {
                Id = 2,
                Name = "Marcin's Muscle Maker",
                Date = DateTime.Now,
                AppointmentId = 2,
                DurationMins = 60,
            });
        }
    }

    
}
