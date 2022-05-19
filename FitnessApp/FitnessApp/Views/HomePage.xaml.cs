using FitnessApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            // TODO version control 
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("FitnessApp.Resources.Datasource.WorkoutApp.db"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);

                    File.WriteAllBytes(ExerciseService.DbPath, memoryStream.ToArray());
                }
            }
        }
    }
}