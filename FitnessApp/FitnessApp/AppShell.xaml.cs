using FitnessApp.ViewModels;
using FitnessApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FitnessApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ProgramExercisesPage), typeof(ProgramExercisesPage));
            Routing.RegisterRoute(nameof(WourkoutPage), typeof(WourkoutPage));
            Routing.RegisterRoute(nameof(ExerciseListPage), typeof(ExerciseListPage));
        }

    }
}
