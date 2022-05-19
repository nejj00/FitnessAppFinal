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
using System.Web;
using Xamarin.Forms;

namespace FitnessApp.ViewModels
{
    public class ProgramExerciseViewModel : ViewModelBase, IQueryAttributable
    {
        public string RoutineId { get; set; }
        public AsyncCommand StartWorkoutCommand { get; }
        public ObservableRangeCollection<ExerciseToDo> ExercisesToDo { get; set; }
        public ProgramExerciseViewModel()
        {
            Title = "Exercises";

            string id = "";
            if (RoutineId != null)
                id = RoutineId;

            StartWorkoutCommand = new AsyncCommand(StartWokout);

            ExercisesToDo = new ObservableRangeCollection<ExerciseToDo>();
        }

        private async Task StartWokout()
        {
            await Shell.Current.GoToAsync($"{nameof(WourkoutPage)}?RoutineId={RoutineId}");
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            RoutineId = HttpUtility.UrlEncode(query["RoutineId"]);
            LoadRoutineExercises(int.Parse(RoutineId));
        }

        private void LoadRoutineExercises(int routineId)
        {
            if (ExercisesToDo.Count > 0)
                return;

            ExerciseRepo exerciseRepo = new ExerciseRepo();
            ExercisesToDo.AddRange(exerciseRepo.GetExercisesToDoForRoutine(routineId));
        }
    }
}
