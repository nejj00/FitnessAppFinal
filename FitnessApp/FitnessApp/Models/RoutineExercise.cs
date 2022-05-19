using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Models
{
    [Table("RoutineExercises")]
    public class RoutineExercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int RoutineId { get; set; }
        public int ExerciseId { get; set; }
        public int Duration { get; set; }
        public int ExerciseOrder { get; set; }
    }
}
