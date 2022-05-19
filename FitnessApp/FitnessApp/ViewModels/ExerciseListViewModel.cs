using FitnessApp.Models;
using FitnessApp.Services;
using FitnessApp.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;

namespace FitnessApp.ViewModels
{
    class ExerciseListViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Exercise> Exercises { get; set; }
        public AsyncCommand<Exercise> SelectedCommand { get; }
        public ExerciseListViewModel()
        {
            Title = "Exercise List";

            SelectedCommand = new AsyncCommand<Exercise>(Selected);

            ExerciseService exerciseService = new ExerciseService();
            Exercises = new ObservableRangeCollection<Exercise>();

            Exercises.AddRange(exerciseService.GetAllRecords());
        }

        Exercise selectedExercise;
        public Exercise SelectedExercise
        {
            get => selectedExercise;
            set => SetProperty(ref selectedExercise, value);
        }

        protected async Task Selected(Exercise exercise)
        {

            if (exercise == null)
                return;

            await App.Current.MainPage.Navigation.ShowPopupAsync(new VideoPopUp(exercise.VideoLink));
        }
    }
}
