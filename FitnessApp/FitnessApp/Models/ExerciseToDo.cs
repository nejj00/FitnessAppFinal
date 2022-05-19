using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Models
{
    public class ExerciseToDo
    {
        public Exercise Exercise { get; set; }
        public int Countdown { get; set; }
        public bool IsDone { get; set; } = false;
        public ExerciseToDo()
        {
        }
        public ExerciseToDo(Exercise exercise, int countdown, bool isDone = false)
        {
            this.Exercise = exercise;
            this.Countdown = countdown;
            this.IsDone = isDone;
        }
    }
}
