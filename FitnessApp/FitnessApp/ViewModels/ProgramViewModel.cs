using FitnessApp.Services;
using FitnessApp.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessApp.Models
{
    public class ProgramViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Routine> Routines { get; set; }
        public AsyncCommand<Routine> SelectedCommand { get; }
        public RoutineService RoutineService;
        public int RoutineWeek;
        public ProgramViewModel()
        {
            Title = "Program";
            SelectedCommand = new AsyncCommand<Routine>(Selected);
            RoutineService = new RoutineService();
            RoutineService routineService = new RoutineService();
            Routines = new ObservableRangeCollection<Routine>();

            //var curTab = Shell.Current.CurrentItem.CurrentItem.CurrentItem.ContentTemplate;
            //var curRoute = Shell.Current.CurrentItem.CurrentItem.CurrentItem.Route;
            //var curTabTitle = Shell.Current.CurrentItem.CurrentItem.CurrentItem.Title;
            //var curItem = Shell.Current.CurrentItem.CurrentItem.CurrentItem;

            Routines.Clear();
            Routines.AddRange(routineService.GetRoutinesForWeek(1));
        }

        Routine selectedRoutine;
        public Routine SelectedRoutine
        {
            get => selectedRoutine;
            set => SetProperty(ref selectedRoutine, value);
        }
        protected async Task Selected(Routine routine)
        {
            if (routine == null || routine.IsRestDay)
                return;

            var route = $"{nameof(ProgramExercisesPage)}?RoutineId={routine.Id}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
