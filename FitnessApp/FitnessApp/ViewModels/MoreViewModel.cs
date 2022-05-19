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
    public class MoreViewModel : BaseViewModel
    {
        public AsyncCommand OpenExerciseListCommand { get; }
        public MoreViewModel()
        {
            Title = "More";

            OpenExerciseListCommand = new AsyncCommand(OpenExerciseList);

        }

        private async Task OpenExerciseList()
        {
            await Shell.Current.GoToAsync($"{nameof(ExerciseListPage)}");
        }
    }
}
