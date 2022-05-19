﻿using FitnessApp.Models;
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
    public class ProgramFirstViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Routine> Routines { get; set; }
        public AsyncCommand<Routine> SelectedCommand { get; }
        public ProgramFirstViewModel()
        {
            Title = "Program 1";
            RoutineService  routineService = new RoutineService();
            Routines = new ObservableRangeCollection<Routine>();

            Routines.AddRange(routineService.GetRoutinesForWeek(1));
            SelectedCommand = new AsyncCommand<Routine>(Selected);
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
