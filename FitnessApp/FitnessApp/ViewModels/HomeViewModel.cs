using FitnessApp.Models;
using FitnessApp.Views;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessApp.ViewModels
{
    public class HomeViewModel :ViewModelBase
    {
        public AsyncCommand GoToProgramPageCommand { get; }
        public AsyncCommand GoToShufflePageCommand { get; }
        public AsyncCommand GoToMorePageCommand { get; }
        public HomeViewModel()
        {
            GoToProgramPageCommand = new AsyncCommand(GoToProgramPage);
            GoToShufflePageCommand = new AsyncCommand(GoToShufflePage);
            GoToMorePageCommand = new AsyncCommand(GoToMorePage);
        }

        private async Task GoToProgramPage()
        {
            await Shell.Current.GoToAsync($"///{nameof(ProgramPage)}");
        }
        private async Task GoToShufflePage()
        {
            await Shell.Current.GoToAsync($"///{nameof(ShufflePage)}");
        }
        private async Task GoToMorePage()
        {
            await Shell.Current.GoToAsync($"///{nameof(MorePage)}");
        }

    }
}
