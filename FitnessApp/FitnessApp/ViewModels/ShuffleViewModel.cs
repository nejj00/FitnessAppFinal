using FitnessApp.Models;
using FitnessApp.Repos;
using FitnessApp.Services;
using FitnessApp.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessApp.ViewModels
{
    public class ShuffleViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Exercise> Exercises { get; set; }
        public ObservableRangeCollection<ExerciseToDo> ExercisesToDo { get; set; }
        public AsyncCommand StartWorkoutCommand { get; }
        public MvvmHelpers.Commands.Command ShuffleCommand { get; }

     
        public ShuffleViewModel()
        {
            Title = "Shuffle";
            StartWorkoutCommand = new AsyncCommand(StartWokout);
            ShuffleCommand = new MvvmHelpers.Commands.Command(ShuffleExercises);

            Exercises = new ObservableRangeCollection<Exercise>();
            ExercisesToDo = new ObservableRangeCollection<ExerciseToDo>();

            ExerciseService exerciseService = new ExerciseService();
            var exercisesDb = exerciseService.GetAllRecords();
            Exercises.AddRange(exercisesDb);
            ShuffleExercises();

        }

        private void ShuffleExercises()
        {
            ExercisesToDo.Clear();
            ExerciseRepo exerciseRepo = new ExerciseRepo();
            ExercisesToDo.AddRange(exerciseRepo.GetShuffleRoutine());
        }

        private async Task StartWokout()
        {
            await Shell.Current.GoToAsync($"{nameof(WourkoutPage)}");
        }

    }
}
