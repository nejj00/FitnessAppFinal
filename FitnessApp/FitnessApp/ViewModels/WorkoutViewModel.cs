using FitnessApp.Models;
using FitnessApp.Repos;
using FitnessApp.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.UI.Views;
using Command = MvvmHelpers.Commands.Command;

namespace FitnessApp.ViewModels
{
    public class WorkoutViewModel : ViewModelBase, IQueryAttributable
    {
        public static int countSeconds;
        private bool isWorkoutActive = false;
        public ObservableRangeCollection<ExerciseToDo> oExercisesToDo { get; set; }

        public MvvmHelpers.Commands.Command<ExerciseToDo> CarouselItemChangedCommand { get; }
        public MvvmHelpers.Commands.Command<ExerciseToDo> ButtonPressedCommand { get; }
        public MvvmHelpers.Commands.Command<ExerciseToDo> ImagePressedCommand { get; }
        public WorkoutViewModel()
        {
            Title = "Workout";

            oExercisesToDo = new ObservableRangeCollection<ExerciseToDo>();

            CarouselItemChangedCommand = new MvvmHelpers.Commands.Command<ExerciseToDo>(CasrouselItemChanged);
            ButtonPressedCommand = new MvvmHelpers.Commands.Command<ExerciseToDo>(ButtonPressed);
            ImagePressedCommand = new MvvmHelpers.Commands.Command<ExerciseToDo>(ImagePressed);
        }

        private void ImagePressed(ExerciseToDo exercise)
        {
            if (exercise == null)
                return;

            App.Current.MainPage.Navigation.ShowPopup(new VideoPopUp(exercise.Exercise.VideoLink));
        }

        void ButtonPressed(ExerciseToDo exerciseToDo)
        {
            if(isWorkoutActive)
            {
                isWorkoutActive = false;
            }
            else if (!isWorkoutActive && countSeconds > 0)
            {
                isWorkoutActive = true;
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    if (isWorkoutActive)
                    {
                        countSeconds--;
                        Countdown = $"{countSeconds}";
                    }

                    if (countSeconds <= 0)
                    {
                        isWorkoutActive = false;
                        exerciseToDo.IsDone = true;
                    }

                    if (countSeconds <= 0 && exerciseToDo.Exercise.Name == oExercisesToDo[oExercisesToDo.Count - 1].Exercise.Name && AllExercisesAreDone())
                        GoBackToProgramPage();

                    return isWorkoutActive;
                });
            }
            

        }

        private bool AllExercisesAreDone()
        {
            foreach(ExerciseToDo exercise in oExercisesToDo)
            {
                if (!exercise.IsDone)
                    return false;
            }

            return true;
        }

        async void GoBackToProgramPage()
        {
            await Shell.Current.GoToAsync($"../../");
        }

        void CasrouselItemChanged(ExerciseToDo exerciseToDo)
        {
            if (exerciseToDo == null)
                return;

            if (exerciseToDo.IsDone)
                return;

            countSeconds = oExercisesToDo[oExercisesToDo.IndexOf(exerciseToDo)].Countdown;
            Countdown = $"{countSeconds}";
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {

            if(query.Count <= 0)
            {
                oExercisesToDo.AddRange(ExerciseRepo.shuffleRoutine);
            }
            else
            {
                string routineId = HttpUtility.UrlEncode(query["RoutineId"]);
                LoadRoutineExercises(int.Parse(routineId));
            }
        }

        private void LoadRoutineExercises(int routineId)
        {
            if (oExercisesToDo.Count > 0)
                return;

            ExerciseRepo exerciseRepo = new ExerciseRepo();
            oExercisesToDo.AddRange(exerciseRepo.GetExercisesToDoForRoutine(routineId));
        }

        public string countdown = countSeconds.ToString();
        public string Countdown
        {
            get => countdown;
            set => SetProperty(ref countdown, value);
        }

    }
}
