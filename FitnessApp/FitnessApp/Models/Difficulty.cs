using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Models
{
    [Table("Difficulties")]
    public class Difficulty
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string DifficultyName { get; set; }
    }
}
