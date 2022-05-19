using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Models
{
    [Table("Exercises")]
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DifficultyId { get; set; }
        public bool IsSingleSide { get; set; }
        public string VideoLink { get; set; }
        public string ExerciseImage { get; set; }
    }
}
