using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgramPage : ContentPage
    {
        public ProgramPage()
        {
            InitializeComponent();

            BindingContext = new ProgramViewModel();
        }

        //async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    await Shell.Current.GoToAsync($"{nameof(ProgramExercisesPage)}");
        //}
    }
}