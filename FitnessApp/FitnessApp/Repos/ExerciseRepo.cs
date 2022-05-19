using FitnessApp.Models;
using FitnessApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Repos
{
    public class ExerciseRepo
    {
        public List<ExerciseToDo> exercisesToDo;
        private static Random random = new Random(12345);
        public static List<ExerciseToDo> shuffleRoutine = new List<ExerciseToDo>();
        public ExerciseRepo()
        {
            exercisesToDo = new List<ExerciseToDo>();
        }

        public List<ExerciseToDo> GetExercisesToDoForRoutine(int routineId)
        {
            RoutineExercisesService routineExercisesService = new RoutineExercisesService();
            List<RoutineExercise> routineExercises = routineExercisesService.GetExercisesForRoutine(routineId);
            routineExercises.Sort((re1, re2) => re1.ExerciseOrder.CompareTo(re2.ExerciseOrder));

            foreach(RoutineExercise rtExercise in routineExercises)
            {
                ExerciseService exerciseService = new ExerciseService();
                Exercise exercise = exerciseService.GetRecord(rtExercise.ExerciseId);
                ExerciseToDo exerciseToDo = new ExerciseToDo(exercise, rtExercise.Duration);
                exercisesToDo.Add(exerciseToDo);

                if(exercise.IsSingleSide)
                    exercisesToDo.Add(exerciseToDo);

                if ((exercisesToDo.Count == 3 && !exercise.IsSingleSide) || (exercise.IsSingleSide && exercisesToDo.Count == 4))
                    AddRest();

            }

            return exercisesToDo;
        }

        private void AddRest()
        {
            ExerciseToDo toDoRest = new ExerciseToDo { Exercise = new Exercise { Name = "Rest" }, Countdown = 45 };
            exercisesToDo.Add(toDoRest);
        }

        public List<ExerciseToDo> GetShuffleRoutine()
        {
            ExerciseService exerciseService = new ExerciseService();
            List<Exercise> exercises = exerciseService.GetAllRecords();
            List<Exercise> pickedExercises = new List<Exercise>();
            
            int count = exercises.Count;
            int needed = 6;

            for(int i = 0; i < count; i++)
            {
                if(random.Next(count - i) < needed)
                {
                    pickedExercises.Add(exercises[i]);
                    if (--needed == 0)
                        break;
                }
            }

            foreach(Exercise exercise in pickedExercises)
            {
                ExerciseToDo exerciseToDo = new ExerciseToDo(exercise, 30);
                exercisesToDo.Add(exerciseToDo);

                if (exercise.IsSingleSide)
                {
                    exercisesToDo.Add(exerciseToDo);
                }

                if ((exercisesToDo.Count == 3 || exercisesToDo.Count == 4 && !exercise.IsSingleSide) || (exercise.IsSingleSide && exercisesToDo.Count == 4))
                    AddRest();
            }

            shuffleRoutine.Clear();
            shuffleRoutine = exercisesToDo;

            return exercisesToDo;
        }
    }
}
