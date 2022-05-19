using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Models
{
    [Table("Routines")]
    public class Routine
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Week { get; set; }
        public int Day { get; set; }
        public bool IsDone { get; set; }
        public bool IsRestDay { get; set; }
    }
}
